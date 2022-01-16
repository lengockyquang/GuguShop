import React from 'react'
import { Navigate, Route, Routes } from 'react-router-dom';
import NotFound from './components/NotFound';
import CustomerProductRoute from './features/customer/product';

function AppRoute() {
    return (
        <React.Fragment>
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