import { Button } from 'antd';
import React, { useRef } from 'react'
import ApplicationModal, { ApplicationModalRef } from '../../../../components/ApplicationModal';
import useTable from '../../../../hooks/useTable';
import { loadCategories } from '../../../../services/category.service';
import { CategoryColumnsConfig } from '../configs/grid.config';
import CategoryCreateForm from './category.create-form';

function CategoryList() {
  const createModalRef = useRef<ApplicationModalRef>(null);
    const [renderTable, loadData] = useTable({
        api: loadCategories,
        columns: CategoryColumnsConfig
    });

    const openCreateForm = () => {
      createModalRef.current?.onOpen();
    }

    const renderCreateModal = () => {
        return (
            <ApplicationModal
                ref={createModalRef}
                title='Tạo mới'
                content={<CategoryCreateForm
                    onReload={async () => {
                        createModalRef.current?.onClose();
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
            {renderCreateModal()}
        </div>
    )
}

export default CategoryList