import { Button, Form, Input } from 'antd'
import { EyeInvisibleOutlined, EyeTwoTone } from '@ant-design/icons';
import React from 'react'
import { LoginForm } from '../domain/ums/login-form';
import { login } from '../services/identity.service';
import { displayErrorNotify, displaySuccessNotify } from '../utils/common';
import {useDispatch} from 'react-redux';
import { loginEvent } from '../redux/identitySlice';

interface Props {
    callback?: () => void;
}

function Login(props: Props) {
    const dispatch = useDispatch();
    const [form] = Form.useForm();

    const onFinish = async (values: LoginForm) => {
        console.log(values);
        const loginResponse = await login(values);
        if(loginResponse.status === 200){
            displaySuccessNotify();
            dispatch(loginEvent("test-username"));
        }
        else{
            displayErrorNotify();
        }
        props.callback?.();
    }

    return (
        <div className='login-form'>
            <Form
                form={form}
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                initialValues={{ remember: true }}
                onFinish={onFinish}
                autoComplete="off"
            >
                <Form.Item
                    labelAlign='left'
                    label="Username"
                    name="userName"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input 
                        placeholder='Nhập username'
                    />
                </Form.Item>
                <Form.Item
                    labelAlign='left'
                    label="Mật khẩu"
                    name="password"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input.Password
                        iconRender={visible => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)}
                        placeholder="Nhập mật khẩu"
                    />
                </Form.Item>
                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit">
                        Đăng nhập
                    </Button>
                </Form.Item>
            </Form>
        </div>
    )
}

export default Login