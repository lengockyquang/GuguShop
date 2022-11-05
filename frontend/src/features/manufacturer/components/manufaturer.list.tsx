import { Button } from 'antd';
import React, { useRef } from 'react'
import ApplicationModal, { ApplicationModalRef } from '../../../components/ApplicationModal';
import useTable from '../../../hooks/useTable';
import { loadManufacturers } from '../../../services/manufacturer.service';
import { ManufacturerColumnsConfig } from '../configs/grid.config';
import ManufacturerCreateForm from './manufacturer.create-form';

function ManufacturerList() {
  const createModalRef = useRef<ApplicationModalRef>(null);
    const [renderTable, loadData] = useTable({
        api: loadManufacturers,
        columns: ManufacturerColumnsConfig
    });

    const openCreateForm = () => {
      createModalRef.current?.onOpen();
    }

    const renderCreateModal = () => {
        return (
            <ApplicationModal
                ref={createModalRef}
                title='Tạo mới'
                content={<ManufacturerCreateForm
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

export default ManufacturerList