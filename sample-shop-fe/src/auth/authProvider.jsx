import { Button } from 'antd';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setAuth } from '../app/identitySlice';
import { identitySelector } from '../app/selector';
import { checkLoginAsync, logoutAsync, okStatusCode } from '../services/identity.service';
import { notificationError } from '../utils/common';

function AuthProvider(props) {
    const identityInfo = useSelector(identitySelector);
    const dispatch = useDispatch();
    useEffect(() => {
        const request = checkLoginAsync();
        request.then(response => {
            if (response.status === okStatusCode) {
                const data = response.data
                dispatch(setAuth({
                    isAuthenticated: data.isAuthenticated,
                    userName: data.userName
                }))
            }
        })
    }, []);

    const goToLogin = () => {
        // eslint-disable-next-line no-undef
        window.location.href = "/login"
    }

    const logout = async () => {
        const response = await logoutAsync();
        if (response.status === okStatusCode) {
            // eslint-disable-next-line no-undef
            window.location.href = "/"
        }
        else {
            notificationError("Can not logout. Please contact your administrator !");
        }
    }

    const renderAuthToolbar = () => {
        const { isAuthenticated } = identityInfo;
        return (
            <div className='auth-toolbar' style={{ height: 30 }}>
                <div className='left-side' style={{ float: 'left'}}>
                    <span style={{fontWeight: 700, fontSize: 16}} >{identityInfo.isAuthenticated && 'Hello ' + identityInfo.userName}</span>
                </div>
                <div className='right-side' style={{ float: 'right' }}>
                    {!isAuthenticated ? (
                        <Button onClick={goToLogin} >Login</Button>
                    ) : <Button onClick={logout} >Logout</Button>}
                </div>
            </div>
        )
    }

    return (
        <div className='auth-wrapper'>
            {renderAuthToolbar()}
            <hr />
            {props.children}
        </div>
    )
}


export default AuthProvider