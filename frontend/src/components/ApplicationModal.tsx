import { Modal } from 'antd'
import React, { useImperativeHandle, useState } from 'react'

interface Props {
    title: string;
    content: JSX.Element,
    maskClosable?: boolean;
    className?: string;
}

export type ApplicationModalRef = {
    onOpen: () => void;
    onClose: () => void;
}

const ApplicationModal = React.forwardRef((props: Props, ref) => {
    const [isModalVisible, setIsModalVisible] = useState<boolean>(false);
    useImperativeHandle(ref, () => ({
        onOpen,
        onClose
    }));

    const onOpen = () => setIsModalVisible(true);
    const onClose = () => setIsModalVisible(false);

    return (
        <Modal
            className={props.className}
            title={props.title} 
            visible={isModalVisible} 
            onCancel={onClose}
            maskClosable={props.maskClosable}
            footer={null}
        >
            {props.content}
        </Modal>
    )
})

export default ApplicationModal