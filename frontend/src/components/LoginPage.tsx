import { Button, Checkbox, Form, Input } from 'antd';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { setAuth } from '../redux/identitySlice';
import {  loginAsync, okStatusCode } from '../services/identity.service';
import { displayErrorNotify } from '../utils/common';
function LoginPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const onSubmit = async (values: any) => {
        const response = await loginAsync(values);
        if(response.status !== okStatusCode)
        {
            displayErrorNotify("Please contact your administrator !");
        }
        else
        {
            const data = response.data;
            if(!data.succeeded)
            {
                displayErrorNotify("Please recheck your login info and try again !");
            }
            else
            {
                dispatch(setAuth({
                    isAuthenticated: data.isAuthenticated,
                    userName: data.userName
                }));
                navigate('/');
                // eslint-disable-next-line no-undef
                window.location.reload();
            }
        }
    };

    return (
        <div className='login'>
            <h2>Login</h2>
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                initialValues={{ remember: true }}
                onFinish={onSubmit}
                autoComplete="off"
            >
                <Form.Item
                    label="Username"
                    name="userName"
                    rules={[{ required: true, message: 'Please input your username!' }]}
                >
                    <Input style={{ width: 300 }} />
                </Form.Item>

                <Form.Item
                    label="Password"
                    name="password"
                    rules={[{ required: true, message: 'Please input your password!' }]}
                >
                    <Input.Password style={{ width: 300 }} />
                </Form.Item>

                <Form.Item name="rememberMe" valuePropName="checked" wrapperCol={{ offset: 8, span: 16 }}>
                    <Checkbox>Remember me</Checkbox>
                </Form.Item>

                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit">
                        Login
                    </Button>
                </Form.Item>
            </Form>
        </div>
    )
}

export default LoginPage