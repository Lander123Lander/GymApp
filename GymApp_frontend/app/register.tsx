import RegisterUnit from "@/components/register/registerUnit";
import React, { useState } from "react";
import { View, Text, TextInput, Button, TouchableOpacity } from "react-native";
import useAppTheme from "./context/AppThemeContext";

export default function RegistrationForm() {
    const colors = useAppTheme();

    const [step, setStep] = React.useState(1);

    const [unit, setUnit] = useState<"kg" | "lbs">("kg");

    const goNext = () => setStep((s) => s + 1);
    const goBack = () => setStep((s) => s - 1);

    return (
        <View style={{ backgroundColor: colors.bg1 }} className="flex-1 justify-center items-center px-6">
            {step === 1 && (
                <RegisterUnit unit={unit} setUnit={setUnit} goNext={goNext} />
            )}
        </View>
    );
}
