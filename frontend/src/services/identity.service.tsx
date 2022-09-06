import { LoginForm } from "../domain/ums/login-form";
import { RegisterForm } from "../domain/ums/register-form";
import { getConfiguredAxiosInstance } from "../utils/common";

export const okStatusCode = 200;
export const badRequestStatusCode = 400;
const axiosInstance = getConfiguredAxiosInstance();

export const loginAsync = async (loginForm: LoginForm) => axiosInstance.post('/api/identity/login', loginForm);
export const logoutAsync = async () => axiosInstance.get('/api/identity/logout');
export const checkLoginAsync = async() => axiosInstance.get('/api/identity/check-login');
export const register = async (registerForm: RegisterForm) => axiosInstance.post('/api/identity/register', registerForm);