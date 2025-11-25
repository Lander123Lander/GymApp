import { authService } from "@/services/authService";
import { useRouter } from "expo-router";
import { useState } from "react";
import { Alert, Text, TextInput, TouchableOpacity, View } from "react-native";
import { useAppTheme } from "./theme/AppThemeContext";
import { Button } from "@/components/button";

export default function Login() {
    const router = useRouter();
    const colors = useAppTheme();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);

    const onLogin = async () => {
        setLoading(true);
        try {
            await authService.login(email, password);
            Alert.alert("Success", "Logged in!");
            router.replace("/");
        } catch (error) {
            Alert.alert(
                "Login failed",
                error instanceof Error ? error.message : String(error)
            );
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return (
            <View
                className="flex-1 justify-center items-center"
                style={{ backgroundColor: colors.bg1 }}
            >
                <Text style={{ color: colors.text1 }}>Loading...</Text>
            </View>
        );
    }

    return (
        <View
            className="flex-1 justify-center items-center px-5"
            style={{ backgroundColor: colors.bg1 }}
        >
            <Text className="text-3xl font-bold mb-8" style={{ color: colors.text1 }}>Login</Text>

            <TextInput
                className="w-full h-12 px-4 mb-4 rounded-xl border"
                style={{ color: colors.text1, borderColor: colors.bg4 }}
                placeholder="Email"
                placeholderTextColor={colors.text2}
                keyboardType="email-address"
                autoCapitalize="none"
                onChangeText={setEmail}
                value={email}
            />

            <TextInput
                className="w-full h-12 px-4 mb-4 rounded-xl border"
                style={{ color: colors.text1, borderColor: colors.bg4 }}
                placeholder="Password"
                placeholderTextColor={colors.text2}
                secureTextEntry
                onChangeText={setPassword}
                value={password}
                autoCapitalize="none"
            />
            <Button label="Log in" onPress={onLogin} variant="primary" />
        </View>
    );
}
