import { StatusBar } from "expo-status-bar";
import "react-native-reanimated";
import "../style/global.css";
import { Slot } from "expo-router";
import { DarkTheme } from "@/style/AppTheme";
import {
    SafeAreaProvider,
    useSafeAreaInsets,
} from "react-native-safe-area-context";
import React from "react";
import useAppTheme, { AppThemeProvider } from "./context/AppThemeContext";
import { View } from "react-native";
import { AuthProvider } from "./context/AuthContext";

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
    return (
        <SafeAreaProvider>
            <AppThemeProvider value={DarkTheme}>
                <AuthProvider>
                    <AppContainer>
                        <Slot />
                        <StatusBar style="auto" />
                    </AppContainer>
                </AuthProvider>
            </AppThemeProvider>
        </SafeAreaProvider>
    );
}
