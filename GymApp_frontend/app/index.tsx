import BottomNav from "@/components/bottomNav";
import { LoadingIndicator } from "@/components/loadingIndicator";
import { useRouter } from "expo-router";
import * as SecureStore from "expo-secure-store"; // or AsyncStorage
import { useEffect, useState } from "react";
import { Button, Text, View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

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
            <SafeAreaView
                style={{
                    flex: 1,
                    justifyContent: "center",
                    alignItems: "center",
                }}
            >
                <LoadingIndicator />
            </SafeAreaView>
        );
    }

    return (
        <SafeAreaView className="flex-1 bg-white">
            <View className="flex-1 justify-center items-center">
                <Text className="mb-4">feed</Text>
                <Button title="Logout" onPress={onLogout} />
            </View>

            <BottomNav />
        </SafeAreaView>
    );
}
