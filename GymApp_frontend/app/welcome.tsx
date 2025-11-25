import { useTheme } from "@react-navigation/native";
import { useRouter } from "expo-router";
import { View, Text, TouchableOpacity } from "react-native";
import { useAppTheme } from "./theme/AppThemeContext";
import { Button } from "@/components/button";

export default function Welcome() {
    const router = useRouter();
    const colors = useAppTheme();

    return (
        <View
            className="flex-1 justify-center items-center px-6"
            style={{ backgroundColor: colors.bg1 }}
        >
            <Text
                className="text-5xl font-bold mb-12 text-center"
                style={{ color: colors.text1 }}
            >
                Welcome!
            </Text>

            <Text
                className="text-base text-center mb-2"
                style={{ color: colors.text2 }}
            >
                Don’t have an account yet?
            </Text>
            <Button label="Create account" variant="primary" />

            <Text
                className="text-base text-center mb-2 mt-2"
                style={{ color: colors.text2 }}
            >
                Already have an account?
            </Text>
            <Button
                label="Log in"
                onPress={() => router.push("/login")}
                variant="ghost"
            />
        </View>
    );
}
