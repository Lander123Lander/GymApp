import { api } from "./apiClient";
import * as SecureStore from "expo-secure-store";

const login = async (emailOrUsername: string, password: string) => {
    return await api.fetchWithoutAuth("/Auth/login", {
        method: "POST",
        body: JSON.stringify({ emailOrUsername, password }),
    });
};

const getProfile = async () => {
    return await api.fetchWithAuth("/Auth/me");
};

export const authService = {
    login,
    getProfile,
};
