import BottomNav from "@/components/bottomNav";
import { Button } from "@/components/button";
import { useRouter } from "expo-router";
import { Text, View } from "react-native";
import * as SecureStore from "expo-secure-store";

export default function Profile() {
    const router = useRouter();

    const onLogout = async () => {
        try {
            await SecureStore.deleteItemAsync("accessToken");
            await SecureStore.deleteItemAsync("refreshToken");
            router.replace("/welcome");
        } catch (e) {
            console.error("Error during logout:", e);
        }
    };

    return (
        <View className="flex-1 bg-white">
            <View className="flex-1 justify-center items-center">
                <Text className="mb-4">Profile</Text>
                <Button label="Logout" onPress={onLogout} />
            </View>
            <BottomNav />
        </View>
    );
}
