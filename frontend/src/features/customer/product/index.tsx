import React from 'react'
import { Navigate, Route } from 'react-router-dom'

function CustomerProductRoute() {
    return (
        <React.Fragment>
            <Route path={"/home"} element={<Navigate to="/home/product" />} />
        </React.Fragment>
    )
}

export default CustomerProductRoute
