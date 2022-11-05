import { Button, Form, Input } from 'antd'
import _ from 'lodash';
import { CategoryCreateDto } from '../../../dtos/category.create-dto';
import { createCategory } from '../../../services/category.service';
import { displayErrorNotify, displaySuccessNotify } from '../../../utils/common';

interface Props {
    onReload: () => void;
}

function CategoryCreateForm(props: Props) {
    const [form] = Form.useForm();
    const onFinish = async (values: CategoryCreateDto) => {
        const response = await createCategory(values);
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            props.onReload();
            displaySuccessNotify("Created successfully !");
        }
        else {
            displayErrorNotify();
        }
    }

    return (
        <div style={{ marginBottom: 10 }}>
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
                    label="Mã"
                    name="code"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    labelAlign='left'
                    label="Tên"
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

export default CategoryCreateForm