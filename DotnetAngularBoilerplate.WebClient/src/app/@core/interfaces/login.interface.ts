export interface ILoginDetails {
  username: string;
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface ILoginResponse {
  token: string;
  userId: string;
}

