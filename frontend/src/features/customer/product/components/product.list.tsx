import React, { useEffect, useState } from 'react'
import _ from 'lodash';
import { Product } from '../../../../domain/product';
import ProductCreateForm from './product.create-form';
import { notification } from 'antd';
import { loadProduct } from '../../../../services/product.service';

function ProductList() {

    const [products, setProducts] = useState<Array<Product>>([]);

    useEffect(()=>{
        loadProductList();
    },[]);

    const loadProductList = async () =>{
        const response = await loadProduct();
        const statusCode = _.get(response, 'status');
        if(statusCode === 200){
            const data = _.get(response, 'data', []);
            setProducts(data);
        }
        else{
            notification.error({
                message:'Thông báo',
                description:'Có lỗi xảy ra !'
            })
        }
    };

    const renderProductItem = (product: Product, index: number) =>{
        return (
            <div key={index}>
                Name: {product.name} <br/>
                Category: {product.category.name} <br/>
                Manufacturer: {product.manufacturer.name} <br/>
                <hr/>
            </div>
        )
    }

    const renderProductList = () => {
        return _.map(products, (productItem: Product, index: number)=>{
            return renderProductItem(productItem, index);
        });
    }

    return (
        <div style={{padding: 10}}>
            <ProductCreateForm
                onReload={loadProductList}
            />
            {renderProductList()}
        </div>
    )
}

export default ProductList;
