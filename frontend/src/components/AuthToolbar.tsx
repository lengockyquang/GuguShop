import { Button } from 'antd'
import { useRef } from 'react'
import { useSelector } from 'react-redux'
import { identitySelector } from '../redux/selector'
import ApplicationModal, { ApplicationModalRef } from './ApplicationModal'
import Login from './Login'

function AuthToolbar() {
    const identityInfo = useSelector(identitySelector);
    const loginModalRef = useRef<ApplicationModalRef>(null);

    const openLoginForm = () => {
        loginModalRef.current?.onOpen();
    }

    const renderLoginFormModal = () => {
        return (
            <ApplicationModal
                ref={loginModalRef}
                title='Đăng nhập'
                content={
                    <Login
                        callback={() => console.log("Login callback !")}
                    />
                }
                maskClosable={false}
            />
        )
    }
    if (identityInfo.isAuthenticated) {
        return (
            <div className='auth-toolbar'>
                {'Đã đăng nhập'}
            </div>
        );
    }
    return (
        <div className='auth-toolbar'>
            <Button type="primary" onClick={openLoginForm}>
                Đăng nhập
            </Button>
            {renderLoginFormModal()}
        </div>
    )
}

export default AuthToolbar