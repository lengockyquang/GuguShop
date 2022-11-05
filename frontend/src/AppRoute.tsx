import { Button } from 'antd';
import React from 'react'
import { Routes, Route, useNavigate } from 'react-router-dom';
import HomePage from './components/HomePage';
import LoginPage from './components/LoginPage';
import NotFound from './components/NotFound';
import ProtectedRoute from './components/ProtectedRoute';
import CategoryList from './features/category/components/category.list';
import ManufacturerList from './features/manufacturer/components/manufaturer.list';
import ProductList from './features/product/components/product.list';
const AppRoute = () => {
    const navigate = useNavigate();
    return (
        <>
            <div className='menu'>
                <Button className='menu-item' onClick={() => navigate("/")} >Home</Button>
                <Button className='menu-item' onClick={() => navigate("/products")} >Products</Button>
                <Button className='menu-item' onClick={() => navigate("/categories")} >Categories</Button>
                <Button className='menu-item' onClick={() => navigate("/manufacturers")} >Manufacturers</Button>
            </div>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route element={<ProtectedRoute />}>
                    <Route path="/products" element={<ProductList />} />
                    <Route path="/categories" element={<CategoryList />} />
                    <Route path="/manufacturers" element={<ManufacturerList />} />
                </Route>
                <Route path="*" element={<NotFound />} />
            </Routes>
        </>

    )
}

export default AppRoute;