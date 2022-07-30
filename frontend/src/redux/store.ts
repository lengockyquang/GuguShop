import { configureStore } from '@reduxjs/toolkit'
import identityReducer from './identitySlice';
export const store = configureStore({
  reducer: {
    identity: identityReducer
  },
});