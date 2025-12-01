export type User = {
  userID: string;
  username: string;
};

export type Post = {
  postID: number;
  title: string;
  description: string;
  isPrivate: boolean;
  postType: number;
  createdAt: string;
  user: User;
};
