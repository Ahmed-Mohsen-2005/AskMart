export interface LoginRequest {
  email: string;
  password: string;
  userType: 'user' | 'amin';
}