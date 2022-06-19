import { configureStore } from '@reduxjs/toolkit';
import { identitySlice } from './identitySlice';


const store = configureStore({
    reducer: {
        identity: identitySlice.reducer
    }
});

export default store;