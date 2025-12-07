import { createContext, useContext, useEffect, useState } from "react";
import * as SecureStore from "expo-secure-store";
import { authService } from "@/services/authService";

type AuthContextType = {
    user: any | null;
    loading: boolean;
    login: (email: string, password: string) => Promise<void>;
    logout: () => Promise<void>;
};

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: React.ReactNode }) {
    const [user, setUser] = useState<any | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadUser = async () => {
            const token = await SecureStore.getItemAsync("accessToken");

            if (token) {
                try {
                    const profile = await authService.getProfile();
                    setUser(profile);
                } catch {
                    await SecureStore.deleteItemAsync("accessToken");
                    await SecureStore.deleteItemAsync("refreshToken");
                    setUser(null);
                }
            }

            setLoading(false);
        };

        loadUser();
    }, []);

    const login = async (email: string, password: string) => {
        console.log("AuthContext login called");

        const data = await authService.login(email, password);
        console.log(data);

        if (data.accessToken) {
            await SecureStore.setItemAsync("accessToken", data.accessToken);
        }
        if (data.refreshToken) {
            await SecureStore.setItemAsync("refreshToken", data.refreshToken);
        }

        const profile = await authService.getProfile();
        setUser(profile);
    };

    const logout = async () => {
        await SecureStore.deleteItemAsync("accessToken");
        await SecureStore.deleteItemAsync("refreshToken");
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, loading, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
}

export function useAuth() {
    const ctx = useContext(AuthContext);
    if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
    return ctx;
}
