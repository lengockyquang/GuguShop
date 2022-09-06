import { notification } from "antd"
import axios, { AxiosInstance } from "axios";
import { badRequestStatusCode } from "../services/identity.service";

export const getConfiguredAxiosInstance = (): AxiosInstance =>{
    const axiosInstance = axios.create();
    // Add a response interceptor
    axiosInstance.interceptors.response.use((response: any) => {
        // Any status code that lie within the range of 2xx cause this function to trigger
        // Do something with response data
        return response;
    }, (error: any) => {
        // Any status codes that falls outside the range of 2xx cause this function to trigger
        // Do something with response error
        const status = error.response.status;
        if(status === badRequestStatusCode)
        {
            const data = error.response.data;
            displayErrorNotify(data);
        }
        return Promise.reject(error);
    });
    return axiosInstance;
}

export const displaySuccessNotify = (message?: string) => {
    notification.success({
        message:'Success',
        description:message || 'Action success'
    })
}

export const displayErrorNotify = (errorMessage?: string) => {
    notification.error({
        message:'Error',
        description: errorMessage || 'Error occurred'
    })
}