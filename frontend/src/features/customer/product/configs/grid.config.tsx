import { Category } from "../../../../domain/category";
import { Manufacturer } from "../../../../domain/manufacturer";

export const ProductListColumnsConfig =[{
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
},]