import React from 'react'
import {useSelector} from 'react-redux';
import {Outlet} from 'react-router-dom';
import { identitySelector } from '../redux/selector';
import Forbidden from './Forbidden';

function ProtectedRoute() {
    const {isAuthenticated} = useSelector(identitySelector);
    return isAuthenticated ? (
        <Outlet/>
    ) : <Forbidden />
}

export default ProtectedRoute