import * as SecureStore from "expo-secure-store";

const login = async (emailOrUsername: string, password: string) => {
    const response = await fetch(`${process.env.EXPO_PUBLIC_API_URL}/Auth/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ emailOrUsername, password }),
    });

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || "Something went wrong.");
    }

    const data = await response.json();

    // Store tokens securely
    if (data.accessToken) {
        await SecureStore.setItemAsync("accessToken", data.accessToken);
    }
    if (data.refreshToken) {
        await SecureStore.setItemAsync("refreshToken", data.refreshToken);
    }
};

export const authService = {
    login,
};
