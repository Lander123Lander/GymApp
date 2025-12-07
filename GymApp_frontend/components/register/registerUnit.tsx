import { View, Text } from "react-native";
import { Button } from "../button";
import useAppTheme from "@/app/context/AppThemeContext";

export default function RegisterUnit({
    unit,
    setUnit,
    goNext,
}: {
    unit: "kg" | "lbs";
    setUnit: (unit: "kg" | "lbs") => void;
    goNext: () => void;
}) {
    const colors = useAppTheme();

    return (
        <View className="w-full flex-1 justify-between">
            <View className="flex-1 justify-center">
                <Text
                    className="text-4xl font-bold text-center"
                    style={{ color: colors.text1 }}
                >
                    What units of measure do you use?
                </Text>
                <Text
                    className="text-lg mb-20 text-center"
                    style={{ color: colors.text2 }}
                >
                    This can be changed at any time.
                </Text>
                <View className="flex-row gap-2">
                    <View className="flex-1">
                        <Button
                            onPress={() => setUnit("kg")}
                            variant={unit === "kg" ? "active" : "inactive"}
                            className="h-40"
                        >
                            <Text
                                className="font-bold text-2xl"
                                style={{
                                    color:
                                        unit === "kg"
                                            ? colors.bg1
                                            : colors.text2,
                                }}
                            >
                                Kilograms
                            </Text>
                        </Button>
                    </View>
                    <View className="flex-1">
                        <Button
                            onPress={() => setUnit("lbs")}
                            variant={unit === "lbs" ? "active" : "inactive"}
                            className="h-40"
                        >
                            <Text
                                className="font-bold text-2xl"
                                style={{
                                    color:
                                        unit === "lbs"
                                            ? colors.bg1
                                            : colors.text2,
                                }}
                            >
                                Pounds
                            </Text>
                        </Button>
                    </View>
                </View>
            </View>

            <Button onPress={goNext}>Continue</Button>
        </View>
    );
}
