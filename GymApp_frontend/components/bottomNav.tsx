import useAppTheme from "@/app/theme/AppThemeContext";
import React, { useState } from "react";
import { View, Text, TouchableOpacity, StyleSheet } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";


export default function BottomNav() {
  const colors = useAppTheme();
  const [activeTab, setActiveTab] = useState("Home");

  const tabs = [
    { name: "Home" },
    { name: "Search" },
    { name: "Profile" },
  ];

  return (
    <SafeAreaView
      style={{
        backgroundColor: colors.bg1,
        borderTopColor: colors.bg4,
        borderTopWidth: 1,
      }}
    >
      <View style={styles.bottomNav}>
        {tabs.map((tab) => (
          <TouchableOpacity
            key={tab.name}
            style={[
              styles.tabButton,
              {
                backgroundColor: activeTab === tab.name ? colors.primary : colors.bg1,
              },
            ]}
            onPress={() => setActiveTab(tab.name)}
          >
            <Text
              style={{
                color: activeTab === tab.name ? colors.text1 : colors.text2,
                fontWeight: activeTab === tab.name ? "bold" : "normal",
                fontSize: 16,
              }}
            >
              {tab.name}
            </Text>
          </TouchableOpacity>
        ))}
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  bottomNav: {
    flexDirection: "row",
    height: 60,
  },
  tabButton: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
});
