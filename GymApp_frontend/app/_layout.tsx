import { StatusBar } from "expo-status-bar";
import "react-native-reanimated";
import "../style/global.css";
import { Slot } from "expo-router";
import { DarkTheme } from "@/style/AppTheme";
import {
    SafeAreaProvider,
    useSafeAreaInsets,
} from "react-native-safe-area-context";
import React, { useEffect } from "react";
import useAppTheme, { AppThemeProvider } from "./theme/AppThemeContext";
import * as NavigationBar from "expo-navigation-bar";
import { View } from "react-native";

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
                <AppContainer>
                    <Slot />
                    <StatusBar style="auto" />
                </AppContainer>
            </AppThemeProvider>
        </SafeAreaProvider>
    );
}
