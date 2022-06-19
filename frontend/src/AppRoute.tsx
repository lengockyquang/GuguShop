import React from 'react'
import { Navigate, Route, Routes } from 'react-router-dom';
import AuthToolbar from './components/AuthToolbar';
import NotFound from './components/NotFound';
import CustomerProductRoute from './features/customer/product';

function AppRoute() {
    return (
        <React.Fragment>
            <AuthToolbar/>
            <Routes>
                <Route path={'/'} element={<Navigate to={"/home"} />} />
                <Route path={"/home"}>
                    {CustomerProductRoute()}
                </Route>
                <Route path={'*'} element={<NotFound />} />
            </Routes>
        </React.Fragment>
    )
}

export default AppRoute
