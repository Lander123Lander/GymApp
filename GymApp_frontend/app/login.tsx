import { authService } from "@/services/authService";
import { useRouter } from "expo-router";
import { useState } from "react";
import {
    ActivityIndicator,
    Alert,
    Text,
    TextInput,
    TouchableOpacity,
    View,
} from "react-native";
import { useAppTheme } from "./theme/AppThemeContext";
import { Button } from "@/components/button";
import { SafeAreaView } from "react-native-safe-area-context";
import { LoadingIndicator } from "@/components/loadingIndicator";

export default function Login() {
    const router = useRouter();
    const colors = useAppTheme();

    const [emailOrUsername, setEmailOrUsername] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    const onLogin = async () => {
        if (!emailOrUsername && !password) {
            setErrorMessage("Please enter your email/username and password.");
            return;
        }
        if (!emailOrUsername) {
            setErrorMessage("Please enter your email/username.");
            return;
        }
        if (!password) {
            setErrorMessage("Please enter your password.");
            return;
        }

        setLoading(true);
        try {
            await authService.login(emailOrUsername, password);
            Alert.alert("Success", "Logged in!");
            router.replace("/");
        } catch (error) {
            const message =
                error instanceof Error
                    ? error.message
                    : "Login failed. Please try again.";
            setErrorMessage(message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <SafeAreaView
            className="flex-1 justify-center items-center px-6"
            style={{ backgroundColor: colors.bg1, position: "relative" }}
        >
            <Text
                className="text-4xl font-bold mb-20"
                style={{ color: colors.text1 }}
            >
                Log in
            </Text>
            <View className="w-full">
                <Text
                    className="text-lg font-bold mb-2"
                    style={{ color: colors.text1 }}
                >
                    Email / Username
                </Text>
                <TextInput
                    className="w-full h-14 px-4 mb-4 rounded-md border"
                    style={{ color: colors.text1, borderColor: colors.bg4 }}
                    placeholder="Email / username"
                    placeholderTextColor={colors.text2}
                    keyboardType="email-address"
                    autoCapitalize="none"
                    onChangeText={setEmailOrUsername}
                    value={emailOrUsername}
                />
            </View>
            <View className="w-full">
                <Text
                    className="text-lg font-bold mb-2"
                    style={{ color: colors.text1 }}
                >
                    Password
                </Text>
                <TextInput
                    className="w-full h-14 px-4 mb-2 rounded-md border"
                    style={{ color: colors.text1, borderColor: colors.bg4 }}
                    placeholder="Password"
                    placeholderTextColor={colors.text2}
                    secureTextEntry
                    onChangeText={setPassword}
                    value={password}
                    autoCapitalize="none"
                />
            </View>

            <Text
                className="w-full text-sm text-center mb-5"
                style={{ color: colors.error }}
            >
                {errorMessage}
            </Text>
            <Button label="Log in" onPress={onLogin} variant="primary" />

            {loading && (
                <LoadingIndicator />
            )}
        </SafeAreaView>
    );
}
