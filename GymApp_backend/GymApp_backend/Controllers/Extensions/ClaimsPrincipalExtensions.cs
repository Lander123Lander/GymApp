using System.Security.Claims;

namespace GymApp_backend.Controllers
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Try to get "sub" claim first, fall back to NameIdentifier
            var userId = user.FindFirst("sub")?.Value
                ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new ApplicationException("User ID claim not found.");

            return Guid.TryParse(userId, out var guid)
            ? guid
            : throw new ApplicationException("User ID claim is not a valid Guid.");
        }
    }
}
