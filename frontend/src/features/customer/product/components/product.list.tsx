import React, { useEffect, useRef, useState } from 'react'
import _ from 'lodash';
import { Product } from '../../../../domain/product';
import ProductCreateForm from './product.create-form';
import { Button, notification } from 'antd';
import { loadProduct } from '../../../../services/product.service';
import ApplicationModal, { ApplicationModalRef } from '../../../../components/ApplicationModal';

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

    const openCreateForm = () =>{
        createProductModalRef.current?.onOpen();
    }

    const renderProductItem = (product: Product, index: number) => {
        return (
            <div key={index}>
                Name: {product.name} <br />
                Category: {product.category.name} <br />
                Manufacturer: {product.manufacturer.name} <br />
                <hr />
            </div>
        )
    }

    const renderProductList = () => {
        return _.map(products, (productItem: Product, index: number) => {
            return renderProductItem(productItem, index);
        });
    }

    const renderCreateProductModal = () =>{
        return (
            <ApplicationModal
                ref={createProductModalRef}
                title='Tạo mới'
                content={<ProductCreateForm
                    onReload={loadProductList}
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
            {renderProductList()}
            {renderCreateProductModal()}
        </div>
    )
}

export default ProductList;
