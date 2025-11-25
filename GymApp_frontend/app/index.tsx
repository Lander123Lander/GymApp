import { useRouter } from "expo-router";
import * as SecureStore from "expo-secure-store"; // or AsyncStorage
import { useEffect, useState } from "react";
import { Button, Text, View } from "react-native";

export default function Index() {
    const router = useRouter();
    const [checkingAuth, setCheckingAuth] = useState(true);

    useEffect(() => {
        async function checkAuth() {
            try {
                const token = await SecureStore.getItemAsync("accessToken");
                if (!token) {
                    router.replace("/welcome");
                }
            } catch (e) {
                console.error("Error checking auth status:", e);
            } finally {
                setCheckingAuth(false);
            }
        }

        checkAuth();
    }, []);

    const onLogout = async () => {
        try {
            await SecureStore.deleteItemAsync("accessToken");
            await SecureStore.deleteItemAsync("refreshToken"); // if you store this key
            router.replace("/welcome");
        } catch (e) {
            console.error("Error during logout:", e);
        }
    };

    if (checkingAuth) {
        return (
            <View
                style={{
                    flex: 1,
                    justifyContent: "center",
                    alignItems: "center",
                }}
            >
                <Text>Loading...</Text>
            </View>
        );
    }

    return (
        <View
            style={{
                flex: 1,
                justifyContent: "center",
                alignItems: "center",
                gap: 16,
            }}
        >
            <Text>feed</Text>
            <Button title="Logout" onPress={onLogout} />
        </View>
    );
}
