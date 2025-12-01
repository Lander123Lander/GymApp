import * as SecureStore from "expo-secure-store";

const getPosts = async () => {
    const token = await SecureStore.getItemAsync("accessToken");

    if (!token) {
        throw new Error("No access token found");
    }

    const response = await fetch(
        `${process.env.EXPO_PUBLIC_API_URL}/Post/user`,
        {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`,
            },
        }
    );

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || "Something went wrong.");
    }

    return response.json();
};

export const postService = {
    getPosts,
};
