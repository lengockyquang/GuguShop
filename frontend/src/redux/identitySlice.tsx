import { createSlice } from "@reduxjs/toolkit";

export const identitySlice =  createSlice({
    name: 'identity',
    initialState: {
        isAuthenticated: false,
        userName: null
    },
    reducers: {
        loginEvent: (state: any, action: any) => {
            // redux toolkit đã tự clone một state mới, vì vậy có thể thao tác trực tiếp
            state.isAuthenticated = true;
            state.userName = action.payload;
        },
        logoutEvent: (state: any, action: any) => {
            state.isAuthenticated = false;
            state.userName = null;
        }
    }
});

export const { loginEvent, logoutEvent } = identitySlice.actions;
