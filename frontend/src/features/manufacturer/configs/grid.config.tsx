import { Space } from "antd";
import { Manufacturer } from "../../../domain/manufacturer";

interface Props{
    openEditModal: Function
}

export const ManufacturerColumnsConfig = (props: Props) => [
    {
        title: 'Mã',
        dataIndex: 'code',
        key: 'code',
    }, {
        title: 'Tên',
        dataIndex: 'name',
        key: 'name',
    },
    {
        title: 'Hành động',
        key: 'action',
        render: (item: Manufacturer) => (
            <Space size="middle">
                <a onClick={()=>{props.openEditModal();}} >Invite {item.name}</a>
                <a>Delete</a>
            </Space>
        ),
    },

]