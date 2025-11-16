using GymApp_backend.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RefreshTokenCleanupService : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RefreshTokenCleanupService> _logger;
    private Timer? _timer;
    private bool _isRunning = false;

    public RefreshTokenCleanupService(IServiceProvider serviceProvider, ILogger<RefreshTokenCleanupService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("RefreshTokenCleanupService started.");
        _timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromHours(1));

        return Task.CompletedTask;
    }

    private void TimerCallback(object? state)
    {
        if (_isRunning) return;

        _isRunning = true;
        DoWorkAsync().ContinueWith(t => _isRunning = false);
    }

    private async Task DoWorkAsync()
    {
        _logger.LogInformation("Running refresh token cleanup...");

        using (var scope = _serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            try
            {
                var expiredTokens = await db.RefreshTokens
                    .Where(t => t.ExpiresAt <= DateTime.UtcNow
                        || (t.RevokedAt != null && t.RevokedAt <= DateTime.UtcNow.AddDays(-1)))
                    .ToListAsync();

                if (expiredTokens.Count > 0)
                {
                    db.RefreshTokens.RemoveRange(expiredTokens);
                    await db.SaveChangesAsync();
                    _logger.LogInformation($"Deleted {expiredTokens.Count} expired refresh tokens.");
                }
                else
                {
                    _logger.LogInformation("No expired refresh tokens found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cleaning up expired refresh tokens.");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("RefreshTokenCleanupService stopped.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
