import useAppTheme from "@/app/context/AppThemeContext";
import { ActivityIndicator, View } from "react-native";

export function LoadingIndicator() {
    const colors = useAppTheme();
    return (
        <View
            className="justify-center items-center"
            style={{
                backgroundColor: "rgba(0,0,0,0.2)",
                position: "absolute",
                inset: 0,
            }}
        >
            <ActivityIndicator size="large" color={colors.text1} />
        </View>
    );
}
