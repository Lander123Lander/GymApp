import { api } from "./apiClient";
import * as SecureStore from "expo-secure-store";

const login = async (emailOrUsername: string, password: string) => {
    const data = await api.fetchWithoutAuth("/Auth/login", {
        method: "POST",
        body: JSON.stringify({ emailOrUsername, password }),
    });

    if (data.accessToken) {
        await SecureStore.setItemAsync("accessToken", data.accessToken);
    }
    if (data.refreshToken) {
        await SecureStore.setItemAsync("refreshToken", data.refreshToken);
    }

    return data;
};

export const authService = {
    login,
};
