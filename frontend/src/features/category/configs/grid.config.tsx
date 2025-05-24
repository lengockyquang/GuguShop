import { Space } from 'antd';
import { Category } from '../../../domain/category';


export const CategoryColumnsConfig = [
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
        render: (item: Category) => (
            <Space size="middle">
                <a>Invite {item.name}</a>
                <a>Delete</a>
            </Space>
        ),
    }
]