// app/welcome.tsx
import { useRouter } from "expo-router";
import { Button, Text, View } from "react-native";

export default function Welcome() {
    const router = useRouter();

    return (
        <View
            style={{ flex: 1, justifyContent: "center", alignItems: "center" }}
        >
            <Text>Welcome Screen</Text>

            <Button title="Go to Login" onPress={() => router.push("/login")} />
        </View>
    );
}
