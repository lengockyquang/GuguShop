import { Button, Form, Input, notification } from 'antd'
import React from 'react'
import axios from 'axios';
import _ from 'lodash';

interface ProductCreateDto {
    code: string;
    name: string;
}

function ProductCreateForm() {

    const onFinish = (values: ProductCreateDto) => {
        const response = axios.post('/api/product/create', values)
        const statusCode = _.get(response, 'status');
        if(statusCode === 200){
            notification.success({
                message:'Thông báo',
                description: 'Tạo mới thành công !'
            });
        }
        else{
            notification.error({
                message:'Thông báo',
                description:'Có lỗi xảy ra !'
            })
        }
    }

    return (
        <div style={{marginBottom: 10}}>
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                initialValues={{ remember: true }}
                onFinish={onFinish}
                //onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    label="Mã sản phẩm"
                    name="code"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    label="Tên sản phẩm"
                    name="name"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit">
                        Tạo mới
                    </Button>
                </Form.Item>
            </Form>

        </div>
    )
}

export default ProductCreateForm