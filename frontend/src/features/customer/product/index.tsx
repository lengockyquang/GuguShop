import React from 'react'
import { Navigate, Route } from 'react-router-dom'
import ProtectedRoute from '../../../components/ProtectedRoute'
import ProductList from './components/product.list'

function CustomerProductRoute() {
    return (
        <React.Fragment>
            <Route path={"/home"} element={<Navigate to="/home/product" />} />
            <Route path={"/home/product"} element={
                <ProtectedRoute children={<ProductList />} />
            } />
        </React.Fragment>
    )
}

export default CustomerProductRoute
