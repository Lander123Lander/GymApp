import { View, Text } from "react-native";
import { Button } from "../button";
import useAppTheme from "@/app/context/AppThemeContext";
import { MaterialIcons } from "@expo/vector-icons";

type GenderOption = "m" | "f" | "x" | "u" | undefined;

export default function RegisterGender({
    gender,
    setGender,
    goNext,
}: {
    gender: GenderOption;
    setGender: (gender: GenderOption) => void;
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
                    What's your gender?
                </Text>
                <Text
                    className="text-lg text-center"
                    style={{ color: colors.text2 }}
                >
                    This will be used to calibrate your statistics.
                </Text>
                <Text
                    className="text-lg mb-14 text-center"
                    style={{ color: colors.text2 }}
                >
                    This can be changed at any time.
                </Text>

                <GenderButton
                    genderValue="m"
                    selectedGender={gender}
                    setGender={setGender}
                    iconName="man"
                    label="Male"
                />
                <GenderButton
                    genderValue="f"
                    selectedGender={gender}
                    setGender={setGender}
                    iconName="woman"
                    label="Female"
                />
                <GenderButton
                    genderValue="x"
                    selectedGender={gender}
                    setGender={setGender}
                    iconName="more-horiz"
                    label="Other"
                />
                <GenderButton
                    genderValue="u"
                    selectedGender={gender}
                    setGender={setGender}
                    iconName="clear"
                    label="Prefer not to say"
                />
            </View>

            <Button onPress={goNext} disabled={!gender}>Continue</Button>
        </View>
    );
}

function GenderButton({
    genderValue,
    selectedGender,
    setGender,
    iconName,
    label,
}: {
    genderValue: GenderOption;
    selectedGender: GenderOption;
    setGender: (gender: GenderOption) => void;
    iconName: React.ComponentProps<typeof MaterialIcons>["name"];
    label: string;
}) {
    const colors = useAppTheme();
    const isSelected = genderValue === selectedGender;

    return (
        <Button
            onPress={() => setGender(genderValue)}
            variant={isSelected ? "active" : "inactive"}
            className="h-32"
        >
            <View className="justify-center items-center">
                <MaterialIcons
                    name={iconName}
                    size={28}
                    color={isSelected ? colors.bg1 : colors.text2}
                />
                <Text
                    className="font-bold text-2xl"
                    style={{ color: isSelected ? colors.bg1 : colors.text2 }}
                >
                    {label}
                </Text>
            </View>
        </Button>
    );
}
