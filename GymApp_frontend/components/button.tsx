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
    variant?: "primary" | "ghost";
    label: string;
    onPress?: (event: GestureResponderEvent) => void;
    disabled?: boolean;
    style?: ViewStyle | ViewStyle[];
    textStyle?: TextStyle | TextStyle[];
};

export function Button({
    variant = "primary",
    label,
    onPress,
    disabled = false,
    style,
    textStyle,
}: ButtonProps) {
    const colors = useAppTheme();
    
    return (
        <TouchableOpacity
            className={`rounded-md py-4 mb-2 w-full ${variant === "ghost" && "border"}`}
            onPress={onPress}
            disabled={disabled}
            style={[
                disabled && { opacity: 0.6 },
                style,
                variant == "primary" ? { backgroundColor: colors.primary } : { borderColor: colors.primary }
            ]}
        >
            <Text
                className="text-lg font-semibold text-center"
                style={[
                    { color: colors.text1 },
                    textStyle,
                ]}
            >
                {label}
            </Text>
        </TouchableOpacity>
    );
}
