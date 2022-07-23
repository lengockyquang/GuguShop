import axios from 'axios';

export const okStatusCode = 200;

const identityApiPrefix = '/api/identity';
export const checkLoginAsync = async () => {
    return await axios.get(`${identityApiPrefix}/check-login`);
}

export const loginAsync = async (loginForm) => {
    return await axios.post(`${identityApiPrefix}/login`, loginForm);
}

export const logoutAsync = async () => {
    return await axios.get(`${identityApiPrefix}/sign-out`);
}