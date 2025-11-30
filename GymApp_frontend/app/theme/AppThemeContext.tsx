import { AppTheme } from "@/style/AppTheme";
import { createContext, useContext } from "react";

const AppThemeContext = createContext<AppTheme | undefined>(undefined);

export default function useAppTheme() {
    const ctx = useContext(AppThemeContext);
    if (!ctx) {
        throw new Error("useAppTheme must be used inside <AppThemeProvider>");
    }
    return ctx;
};

export const AppThemeProvider = AppThemeContext.Provider;
