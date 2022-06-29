import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import _ from "lodash";
import { checkUserAuthInfo } from "../services/identity.service";

export const identitySlice = createSlice({
    name: 'identity',
    initialState: {
        isAuthenticated: false,
        userName: ''
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
    },
    extraReducers: (builder) => {
        builder.addCase(checkLoginAsync.fulfilled, (state, action) => {
            state.isAuthenticated = action.payload.isAuthenticated;
            state.userName = action.payload.userName;
        });
    }
});

export const checkLoginAsync = createAsyncThunk(
    'identity/checkLogin',
    async () => {
        const response = await checkUserAuthInfo();
        const data = _.get(response, 'data');
        return {
            isAuthenticated: response.status === 200 && _.get(data, 'isAuthenticated', false),
            userName: _.get(data, 'userName')
        };
    }
)

export const { loginEvent, logoutEvent } = identitySlice.actions;
