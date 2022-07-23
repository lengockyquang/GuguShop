import React from 'react'
import { Routes, Route } from 'react-router-dom';
import HomePage from './components/homePage';
import LoginPage from './components/loginPage';
import NotFound from './components/notFound';
import PrivatePage from './components/privatePage';
import ProtectedRoute from './components/protectedRoute';
const AppRoute = () => {
    return (
        <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route element={<ProtectedRoute />}>
                <Route path="/private" element={<PrivatePage />} />
            </Route>
            <Route path="*" element={<NotFound />} />
        </Routes>
    )
}

export default AppRoute;