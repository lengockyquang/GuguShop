import React, { useEffect, useRef, useState } from 'react'
import _ from 'lodash';
import { Product } from '../../../../domain/product';
import ProductCreateForm from './product.create-form';
import { Button, notification, Table } from 'antd';
import { loadProduct } from '../../../../services/product.service';
import ApplicationModal, { ApplicationModalRef } from '../../../../components/ApplicationModal';
import { Manufacturer } from '../../../../domain/manufacturer';
import { Category } from '../../../../domain/category';

function ProductList() {
    const [products, setProducts] = useState<Array<Product>>([]);
    const createProductModalRef = useRef<ApplicationModalRef>(null);
    useEffect(() => {
        loadProductList();
    }, []);

    const loadProductList = async () => {
        const response = await loadProduct();
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            const data = _.get(response, 'data', []);
            setProducts(data);
        }
        else {
            notification.error({
                message: 'Thông báo',
                description: 'Có lỗi xảy ra !'
            })
        }
    };

    const openCreateForm = () => {
        createProductModalRef.current?.onOpen();
    }

    const renderProductTable = () => {
        const columns = [
            {
                title: 'Tên sản phẩm',
                dataIndex: 'name',
                key: 'name',
            },
            {
                title: 'Nhà sản xuất',
                dataIndex: 'manufacturer',
                key: 'manufacturer',
                render: (item: Manufacturer) => item?.name
            },
            {
                title: 'Loại',
                dataIndex: 'category',
                key:'category',
                render: (item: Category) => item?.name
            },
        ];
        return (
            <Table dataSource={products} columns={columns} />
        )
    }

    const renderCreateProductModal = () => {
        return (
            <ApplicationModal
                ref={createProductModalRef}
                title='Tạo mới'
                content={<ProductCreateForm
                    onReload={async () => {
                        createProductModalRef.current?.onClose();
                        await loadProductList();
                    }}
                />}
                maskClosable={false}
            />
        )
    }

    return (
        <div style={{ padding: 10 }}>
            <Button type="primary" onClick={openCreateForm}>
                Tạo mới
            </Button>
            {renderProductTable()}
            {renderCreateProductModal()}
        </div>
    )
}

export default ProductList;
