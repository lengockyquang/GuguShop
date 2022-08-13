import { notification, Table } from 'antd';
import { AxiosResponse } from 'axios';
import _ from 'lodash';
import { useEffect, useState } from 'react'

interface Props {
    api: () => Promise<AxiosResponse>;
    columns: Array<Record<string, any>>;
}

function useTable(props: Props) {
    const [data, setData] = useState();
    
    useEffect(() => {
        loadData();
    }, []);

    const loadData = async () => {
        const response = await props.api();
        const statusCode = _.get(response, 'status');
        if (statusCode === 200) {
            const data = _.get(response, 'data', []);
            setData(data);
        }
        else {
            notification.error({
                message: 'Thông báo',
                description: 'Có lỗi xảy ra !'
            })
        }
    };

    const renderTable = () =>{
        return (
            <div className='table-wrapper'>
                <Table dataSource={data} columns={props.columns} />
            </div>
        )
    }

    return [
        renderTable,
        loadData
    ]
}

export default useTable