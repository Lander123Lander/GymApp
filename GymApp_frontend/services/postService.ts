import { api } from "./apiClient";

const getPosts = async () => {
    return api.fetchWithAuth("/Post/user", {
        method: "GET",
    });
};

export const postService = {
    getPosts,
};
