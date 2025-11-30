import useAppTheme from "@/app/theme/AppThemeContext";
import React, { useState } from "react";
import { View, TouchableOpacity } from "react-native";
import { MaterialIcons } from "@expo/vector-icons";

export default function BottomNav() {
    const colors = useAppTheme();
    const [activeTab, setActiveTab] = useState("Home");

    const tabs: { name: string; icon: "home" | "search" | "person" }[] = [
        { name: "Home", icon: "home" },
        { name: "Search", icon: "search" },
        { name: "Profile", icon: "person" },
    ];

    return (
        <View className="flex-row py-6" style={{ backgroundColor: colors.bg1 }}>
            {tabs.map((tab) => {
                const isActive = activeTab === tab.name;
                return (
                    <TouchableOpacity
                        key={tab.name}
                        className="flex-1 justify-center items-center"
                        style={{
                            backgroundColor: colors.bg1,
                        }}
                        onPress={() => setActiveTab(tab.name)}
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
