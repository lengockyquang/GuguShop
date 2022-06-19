import { Button } from 'antd'
import React, { useRef } from 'react'
import ApplicationModal, { ApplicationModalRef } from './ApplicationModal'
import Login from './Login'

function AuthToolbar() {
    const loginModalRef = useRef<ApplicationModalRef>(null);

    const openLoginForm =() => {
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