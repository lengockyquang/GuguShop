import axios from "axios";
import { LoginForm } from "../domain/ums/login-form";
import { RegisterForm } from "../domain/ums/register-form";

export const okStatusCode = 200;
export const loginAsync = async (loginForm: LoginForm) => axios.post('/api/identity/login', loginForm);
export const logoutAsync = async () => axios.get('/api/identity/logout');
export const checkLoginAsync = async() => axios.get('/api/identity/check-login');
export const register = async (registerForm: RegisterForm) => axios.post('/api/identity/register', registerForm);