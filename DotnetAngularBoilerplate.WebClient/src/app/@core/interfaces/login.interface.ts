export interface ILoginDetails {
  username: string;
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface ILoginResponse {
  token: string;
  userId: string;
  firstName: string;
  lastName: string;
  expiresOn: string;
}

export interface IRegisterUserDetails {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password: string;
}

export interface IRegisterUserResponse {
  isRegistered: boolean;
  message: string;
}