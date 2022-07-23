import { notification } from 'antd';

export function notificationError(message) {
    notification.error({
        message: 'Error',
        description: message
    })
}

export function notificationSuccess(message) {
    notification.success({
        message: 'Success',
        description: message
    })
}