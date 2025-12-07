import AuthWrapper from "@/components/authWrapper";
import BottomNav from "@/components/bottomNav";
import { Text, View } from "react-native";

export default function Create() {
    return (
        <AuthWrapper>
            <View className="flex-1 bg-white">
                <View className="flex-1 justify-center items-center">
                    <Text className="mb-4">Create</Text>
                </View>
                <BottomNav />
            </View>
        </AuthWrapper>
    );
}
