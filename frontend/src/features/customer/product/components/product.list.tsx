import React, {  useRef } from 'react'
import ProductCreateForm from './product.create-form';
import { Button} from 'antd';
import { loadProduct } from '../../../../services/product.service';
import ApplicationModal, { ApplicationModalRef } from '../../../../components/ApplicationModal';
import useTable from '../../../../hooks/useTable';
import { ProductListColumnsConfig } from '../configs/grid.config';

function ProductList() {
    const createProductModalRef = useRef<ApplicationModalRef>(null);
    const [renderTable, loadData] = useTable({
        api: loadProduct,
        columns: ProductListColumnsConfig
    });

    const openCreateForm = () => {
        createProductModalRef.current?.onOpen();
    }

    const renderCreateProductModal = () => {
        return (
            <ApplicationModal
                ref={createProductModalRef}
                title='Tạo mới'
                content={<ProductCreateForm
                    onReload={async () => {
                        createProductModalRef.current?.onClose();
                        await loadData();
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
            {renderTable()}
            {renderCreateProductModal()}
        </div>
    )
}

export default ProductList;
