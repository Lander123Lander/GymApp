import BottomNav from "@/components/bottomNav";
import { postService } from "@/services/postService";
import { Post } from "@/types/types";
import { useEffect, useState } from "react";
import { Text, View } from "react-native";

export default function Index() {
    const [posts, setPosts] = useState<Post[]>([]);

    useEffect(() => {
        // Any initialization logic can go here
        const fetchPosts = async () => {
            try {
                const posts = await postService.getPosts();
                setPosts(posts);
                console.log("Fetched posts:", posts);
            } catch (error) {
                console.error("Failed to fetch posts:", error);
            }
        };

        fetchPosts();
    }, []);

    return (
        <View className="flex-1 bg-white">
            <View className="flex-1 justify-center items-center">
                <Text className="mb-4">feed</Text>
                <Text className="mb-4">{posts.length}</Text>
                {posts.map((post) => (
                    <View key={post.postID} className="mb-4 p-4 border border-gray-300 rounded-lg w-full">
                        <Text className="font-bold text-lg mb-2">{post.title}</Text>
                        <Text className="text-gray-700">{post.description}</Text>
                    </View>
                ))}
            </View>

            <BottomNav />
        </View>
    );
}
