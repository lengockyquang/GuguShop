import { Button, Form, Input, notification, Select } from 'antd'
import _ from 'lodash';
import { useEffect, useState } from 'react';
import { Combo } from '../../../domain/combo';
import { ProductCreateDto } from '../../../dtos/product.create-dto';
import { loadCategoryCombo } from '../../../services/category.service';
import { loadManufacturerCombo } from '../../../services/manufacturer.service';
import { createProduct } from '../../../services/product.service';
import { displayErrorNotify, displaySuccessNotify } from '../../../utils/common';
const { Option } = Select;

interface Props {
    onReload: () => void;
}

function ProductCreateForm(props: Props) {
    const [form] = Form.useForm();
    const [categories, setCategories] = useState([]);
    const [manufacturers, setManufacturers] = useState([]);

    useEffect(() => {
        loadCategoryOptions();
        loadManufacturerOptions();
    }, [])

    const loadCategoryOptions = async () => {
        const response = await loadCategoryCombo();
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            const data = _.get(response, 'data', []);
            setCategories(data);
        }
        else {
            notification.error({
                message: 'Thông báo',
                description: 'Có lỗi xảy ra !'
            })
        }
    }

    const loadManufacturerOptions = async () => {
        const response = await loadManufacturerCombo();
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            const data = _.get(response, 'data', []);
            setManufacturers(data);
        }
        else {
            notification.error({
                message: 'Thông báo',
                description: 'Có lỗi xảy ra !'
            })
        }
    }

    const onFinish = async (values: ProductCreateDto) => {
        const response = await createProduct(values);
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            props.onReload();
            displaySuccessNotify("Tạo mới thành công !");
            form.resetFields();
        }
        else {
            displayErrorNotify();
        }
    }

    const onChangeCategory = (value: string) => {
        form.setFieldsValue({ categoryId: value });
    };

    const onChangeManufacturer = (value: string) =>{
        form.setFieldsValue({ manufacturerId: value });
    }

    const renderCategoryOptions = () => {
        return _.map(categories, (category: Combo, index: number) => {
            return (
                <Option key={index} value={category.value}>{category.label}</Option>
            )
        })
    }

    const renderManufacturerOptions = () =>{
        return _.map(manufacturers, (category: Combo, index: number) => {
            return (
                <Option key={index} value={category.value}>{category.label}</Option>
            )
        })
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
                    label="Mã sản phẩm"
                    name="code"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    labelAlign='left'
                    label="Tên sản phẩm"
                    name="name"
                    rules={[{ required: true, message: 'Giá trị bắt buộc !' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    labelAlign='left'
                    name="categoryId"
                    label="Loại sản phẩm"
                    rules={[{ required: true, message: 'Giá trị bắt buộc' }]}
                >
                    <Select
                        virtual={true}
                        placeholder="Chọn loại sản phẩm"
                        onChange={onChangeCategory}
                        allowClear
                    >
                        {renderCategoryOptions()}
                    </Select>
                </Form.Item>
                <Form.Item
                    labelAlign='left'
                    name="manufacturerId"
                    label="Nhà sản xuất"
                    rules={[{ required: true, message: 'Giá trị bắt buộc' }]}
                >
                    <Select
                        virtual={true}
                        placeholder="Chọn loại nhà sản xuất"
                        onChange={onChangeManufacturer}
                        allowClear
                    >
                        {renderManufacturerOptions()}
                    </Select>
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