import { useEffect } from "react";
import { View, ActivityIndicator } from "react-native";
import { Redirect, useRouter } from "expo-router";
import { useAuth } from "@/app/context/AuthContext";

export default function AuthWrapper({
    children,
}: {
    children: React.ReactNode;
}) {
    const { user, loading } = useAuth();

    if (loading) {
        return (
            <View className="flex-1 justify-center items-center">
                <ActivityIndicator size="large" />
            </View>
        );
    }

    if (!user) return <Redirect href="/welcome" />;

    return <>{children}</>;
}
