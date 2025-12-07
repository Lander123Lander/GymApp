import { useRouter } from "expo-router";
import { View, Text } from "react-native";
import useAppTheme from "./context/AppThemeContext";
import { Button } from "@/components/button";

export default function Welcome() {
    const router = useRouter();
    const colors = useAppTheme();

    return (
        <View
            className="flex-1 justify-center items-center px-6 gap-6"
            style={{ backgroundColor: colors.bg1 }}
        >
            <Text
                className="text-5xl font-bold mb-12"
                style={{ color: colors.text1 }}
            >
                Welcome!
            </Text>

            <View className="justify-center w-full mb-4">
                <Text
                    className="text-base text-center mb-2"
                    style={{ color: colors.text2 }}
                >
                    Don’t have an account yet?
                </Text>
                <Button
                    onPress={() => router.push("/register")}
                    variant="primary"
                >
                    Create account
                </Button>
            </View>

            <View className="justify-center w-full mb-4">
                <Text
                    className="text-base text-center mb-2 mt-2"
                    style={{ color: colors.text2 }}
                >
                    Already have an account?
                </Text>
                <Button onPress={() => router.push("/login")} variant="ghost">
                    Log in
                </Button>
            </View>
        </View>
    );
}
