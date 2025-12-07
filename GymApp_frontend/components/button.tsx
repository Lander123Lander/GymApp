import React from "react";
import {
    TouchableOpacity,
    Text,
    ViewStyle,
    TextStyle,
    GestureResponderEvent,
} from "react-native";
import useAppTheme from "../app/context/AppThemeContext";

type ButtonProps = {
    variant?: "primary" | "ghost" | "active" | "inactive";
    children: React.ReactNode;
    onPress?: (event: GestureResponderEvent) => void;
    disabled?: boolean;
    className?: string;
    textClassName?: string;
};

export function Button({
    variant = "primary",
    children,
    onPress,
    disabled = false,
    className,
    textClassName,
}: ButtonProps) {
    const colors = useAppTheme();

    let backgroundColor: string | undefined;
    let borderColor: string | undefined;
    let textColor: string | undefined;

    switch (variant) {
        case "primary":
            backgroundColor = colors.primary;
            borderColor = undefined;
            textColor = colors.text1;
            break;
        case "ghost":
            backgroundColor = undefined;
            borderColor = colors.primary;
            textColor = colors.text1;
            break;
        case "active":
            backgroundColor = colors.text1;
            borderColor = undefined;
            textColor = colors.bg1;
            break;
        case "inactive":
            backgroundColor = colors.bg4;
            borderColor = undefined;
            textColor = colors.text2;
            break;
    }

    return (
        <TouchableOpacity
            className={`justify-center items-center rounded-md py-4 mb-2 w-full ${
                variant === "ghost" && "border"
            } ${className}`}
            onPress={onPress}
            disabled={disabled}
            style={[
                disabled && { opacity: 0.6 },
                backgroundColor && { backgroundColor },
                borderColor && { borderColor, borderWidth: 1 },
            ]}
        >
            <Text
                className={`justify-center items-center text-lg font-semibold text-center ${textClassName}`}
                style={{ color: textColor }}
            >
                {children}
            </Text>
        </TouchableOpacity>
    );
}
