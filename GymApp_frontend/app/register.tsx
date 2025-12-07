import RegisterUnit from "@/components/register/registerUnit";
import React, { useEffect, useState } from "react";
import {
    View,
    Text,
    TextInput,
    Button,
    TouchableOpacity,
    BackHandler,
    Alert,
} from "react-native";
import useAppTheme from "./context/AppThemeContext";
import RegisterGender from "@/components/register/registerGender";

export default function RegistrationForm() {
    const colors = useAppTheme();

    const [step, setStep] = React.useState(1);

    const [unit, setUnit] = useState<"kg" | "lbs">("kg");
    const [gender, setGender] = useState<"m" | "f" | "x" | "u" | undefined>(undefined);

    useEffect(() => {
        const onBackPress = () => {
            if (step > 1) {
                goBack();
                return true;
            }
        };

        const subscription = BackHandler.addEventListener(
            "hardwareBackPress",
            onBackPress
        );

        return () => {
            subscription.remove();
        };
    }, [step]);

    const goNext = () => setStep((s) => s + 1);
    const goBack = () => setStep((s) => s - 1);

    return (
        <View
            style={{ backgroundColor: colors.bg1 }}
            className="flex-1 justify-center items-center px-6"
        >
            {step === 1 && (
                <RegisterUnit unit={unit} setUnit={setUnit} goNext={goNext} />
            )}
            {step === 2 && (
                <RegisterGender gender={gender} setGender={setGender} goNext={goNext} />
            )}
        </View>
    );
}
