export interface SignupRequest {
  username: string;
  email: string;
  password: string;
  confirmpassword: string;
  userType: 'user' | 'amin';
}