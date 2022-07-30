import React from 'react'
import { Routes, Route } from 'react-router-dom';
import HomePage from './components/HomePage';
import LoginPage from './components/LoginPage';
import NotFound from './components/NotFound';
import ProtectedRoute from './components/ProtectedRoute';
import ProductList from './features/customer/product/components/product.list';
const AppRoute = () => {
    return (
        <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route element={<ProtectedRoute />}>
                <Route path="/private" element={<ProductList />} />
            </Route>
            <Route path="*" element={<NotFound />} />
        </Routes>
    )
}

export default AppRoute;