import { StatusBar } from "expo-status-bar";
import "react-native-reanimated";
import "../style/global.css";
import { Slot } from "expo-router";
import { DarkTheme } from "@/style/AppTheme";
import { SafeAreaProvider } from "react-native-safe-area-context";
import React from "react";
import { AppThemeProvider } from "./theme/AppThemeContext";

export default function RootLayout() {
    return (
        <SafeAreaProvider>
            <AppThemeProvider value={DarkTheme}>
                <Slot />
                <StatusBar style="auto" />
            </AppThemeProvider>
        </SafeAreaProvider>
    );
}
