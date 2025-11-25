import { StatusBar } from "expo-status-bar";
import "react-native-reanimated";
import "../style/global.css";
import { Slot } from "expo-router";
import { AppThemeProvider } from "./theme/AppThemeContext";
import { DarkTheme } from "@/style/AppTheme";

export default function RootLayout() {
    return (
        <AppThemeProvider value={DarkTheme}>
            <Slot />
            <StatusBar style="auto" />
        </AppThemeProvider>
    );
}
