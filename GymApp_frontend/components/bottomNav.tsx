import useAppTheme from "@/app/context/AppThemeContext";
import React from "react";
import { View, TouchableOpacity } from "react-native";
import { MaterialIcons } from "@expo/vector-icons";
import { useRouter, usePathname } from "expo-router";

type TabRoute = "/" | "/create" | "/profile";

export default function BottomNav() {
    const colors = useAppTheme();
    const router = useRouter();
    const pathname = usePathname();

    const tabs: {
        name: string;
        icon: "home" | "add" | "person";
        route: TabRoute;
    }[] = [
        { name: "Home", icon: "home", route: "/" },
        { name: "Create", icon: "add", route: "/create" },
        { name: "Profile", icon: "person", route: "/profile" },
    ];

    const onTabPress = (route: TabRoute) => {
        if (pathname !== route) {
            router.replace(route);
        }
    };

    return (
        <View className="flex-row py-6" style={{ backgroundColor: colors.bg1 }}>
            {tabs.map((tab) => {
                const isActive = pathname === tab.route;
                return (
                    <TouchableOpacity
                        key={tab.name}
                        className="flex-1 justify-center items-center"
                        style={{ backgroundColor: colors.bg1 }}
                        onPress={() => onTabPress(tab.route)}
                    >
                        <MaterialIcons
                            name={tab.icon}
                            size={28}
                            color={isActive ? colors.primary : colors.text2}
                        />
                    </TouchableOpacity>
                );
            })}
        </View>
    );
}
