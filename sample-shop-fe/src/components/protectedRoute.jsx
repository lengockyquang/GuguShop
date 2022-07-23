import React from 'react'
import { identitySelector } from '../app/selector';
import {useSelector} from 'react-redux';
import {Outlet} from 'react-router-dom';
import Forbidden from './forbidden';

function ProtectedRoute() {
    const identityInfo = useSelector(identitySelector);
    const {isAuthenticated} = identityInfo;
    return isAuthenticated ? (
        <Outlet/>
    ) : <Forbidden />
}

export default ProtectedRoute