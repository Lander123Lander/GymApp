import { StatusBar } from "expo-status-bar";
import "react-native-reanimated";
import "../style/global.css";
import { Slot, useRouter } from "expo-router";
import { DarkTheme } from "@/style/AppTheme";
import {
    SafeAreaProvider,
    useSafeAreaInsets,
} from "react-native-safe-area-context";
import React, { useEffect, useState } from "react";
import useAppTheme, { AppThemeProvider } from "./theme/AppThemeContext";
import { View } from "react-native";
import * as SecureStore from "expo-secure-store";

function AppContainer({ children }: any) {
    const insets = useSafeAreaInsets();
    const colors = useAppTheme();

    return (
        <View style={{ flex: 1, backgroundColor: colors.bg1 }}>
            {children}
            <View
                style={{ height: insets.bottom, backgroundColor: colors.bg1 }}
            />
        </View>
    );
}

export default function RootLayout() {
    const router = useRouter();
    const [checkingAuth, setCheckingAuth] = useState(true);

    useEffect(() => {
        async function checkAuth() {
            try {
                const token = await SecureStore.getItemAsync("accessToken");

                if (!token) {
                    router.replace("/welcome");
                }
            } catch (e) {
                console.error("Auth check failed:", e);
                router.replace("/welcome");
            } finally {
                setCheckingAuth(false);
            }
        }

        checkAuth();
    }, []);

    return (
        <SafeAreaProvider>
            <AppThemeProvider value={DarkTheme}>
                <AppContainer>
                    <Slot />
                    <StatusBar style="auto" />
                </AppContainer>
            </AppThemeProvider>
        </SafeAreaProvider>
    );
}
