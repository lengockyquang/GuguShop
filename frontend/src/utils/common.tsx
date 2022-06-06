import { notification } from "antd"

export const displaySuccessNotify = (message?: string) => {
    notification.success({
        message:'Thành công',
        description:message || 'Thao tác thành công !'
    })
}

export const displayErrorNotify = (errorMessage?: string) => {
    notification.success({
        message:'Thất bại',
        description: errorMessage || 'Có lỗi xảy ra !'
    })
}