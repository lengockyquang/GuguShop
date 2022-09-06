import { Button } from 'antd';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setAuth } from '../redux/identitySlice';
import { identitySelector } from '../redux/selector';
import { checkLoginAsync, logoutAsync, okStatusCode } from '../services/identity.service';
import { displayErrorNotify } from '../utils/common';
import Loading from './Loading';

function AuthProvider(props: any) {
    const identityInfo: any = useSelector<any>(identitySelector);
    const dispatch = useDispatch();
    const [loading, setLoading] = useState<boolean>(true);
    useEffect(() => {
        const request = checkLoginAsync();
        request.then((response: any) => {
            if (response.status === okStatusCode) {
                const data = response.data
                dispatch(setAuth({
                    isAuthenticated: data.isAuthenticated,
                    userName: data.userName
                }))
            }
        })
        .catch((error) => {
            console.log(error)
            displayErrorNotify("Error occurred");
        })
        .finally(() => {
            setTimeout(()=>{
                setLoading(false);
            }, 500)
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
            displayErrorNotify("Can not logout. Please contact your administrator !");
        }
    }

    const renderAuthToolbar = () => {
        return (
            <div className='auth-toolbar' style={{ height: 30 }}>
                <div className='left-side' style={{ float: 'left'}}>
                    <span style={{fontWeight: 700, fontSize: 16}} >{identityInfo.isAuthenticated && 'Hello ' + identityInfo.userName}</span>
                </div>
                <div className='right-side' style={{ float: 'right' }}>
                    {!identityInfo.isAuthenticated ? (
                        <Button onClick={goToLogin} >Login</Button>
                    ) : <Button onClick={logout} >Logout</Button>}
                </div>
            </div>
        )
    }

    return (
        <div className='auth-wrapper'>
            <Loading loading={loading} />
            {renderAuthToolbar()}
            <hr />
            {props.children}
        </div>
    )
}


export default AuthProvider