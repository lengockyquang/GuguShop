import { Button, Form, Input } from 'antd'
import _ from 'lodash';
import { ProductCreateDto } from '../../../../dtos/product.create-dto';
import { createProduct } from '../../../../services/product.service';
import { displayErrorNotify, displaySuccessNotify } from '../../../../utils/common';

interface Props {
    onReload: () => void;
}

function ProductCreateForm(props: Props) {
    const onFinish = async (values: ProductCreateDto) => {
        values.manufacturerId = '8FC79312-1A72-4B09-F6C2-08DA1721C052';
        values.categoryId = '64857661-C03B-4B45-7DE6-08DA3B3B00EF';
        values.tagIds = [
            '9F912BE0-CA81-4B14-A6E4-08DA3B3A6739'
        ];

        const response = await createProduct(values);
        const statusCode = _.get(response, 'status');
        if(statusCode === 200){
            props.onReload();
            displaySuccessNotify("Tạo mới thành công !");
        }
        else{
            displayErrorNotify();
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