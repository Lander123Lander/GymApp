import * as SecureStore from "expo-secure-store";

const API_URL = process.env.EXPO_PUBLIC_API_URL || "";


async function refresh() {
    console.log("Refreshing token...");

    const refreshToken = await SecureStore.getItemAsync("refreshToken");
    if (!refreshToken) {
        throw new Error("No refresh token found");
    }

    const response = await fetch(`${API_URL}/Auth/refresh`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ refreshToken }),
    });

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || "Something went wrong during token refresh.");
    }

    const data = await response.json();

    console.log("Token refreshed successfully.");

    if (data.accessToken) {
        await SecureStore.setItemAsync("accessToken", data.accessToken);
    }
    if (data.refreshToken) {
        await SecureStore.setItemAsync("refreshToken", data.refreshToken);
    }

    return data.accessToken;
}

async function fetchWithAuth(url: string, options: RequestInit = {}) {
    let accessToken = await SecureStore.getItemAsync("accessToken");
    if (!accessToken) {
        console.error(`No access token found for FETCH ${url}`);
        return;
    } 

    const headers = new Headers(options.headers);
    headers.set("Authorization", `Bearer ${accessToken}`);
    headers.set("Content-Type", "application/json");

    let response = await fetch(API_URL + url, { ...options, headers });

    if (response.status === 401) {
        try {
            accessToken = await refresh();

            headers.set("Authorization", `Bearer ${accessToken}`);
            response = await fetch(API_URL + url, { ...options, headers });
        } catch (e) {
            throw e;
        }
    }

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || "Something went wrong.");
    }

    return response.json();
}

async function fetchWithoutAuth(url: string, options: RequestInit = {}) {
  const headers = new Headers(options.headers);
  headers.set("Content-Type", "application/json");

  console.log(API_URL + url);

  const response = await fetch(API_URL + url, { ...options, headers });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Something went wrong.");
  }

  return response.json();
}

export const api = {
    fetchWithAuth,
    fetchWithoutAuth,
};
