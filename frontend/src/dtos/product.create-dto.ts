import { RcFile, UploadChangeParam, UploadFile } from 'antd/lib/upload/interface';
export interface ProductCreateDto {
    code: string;
    name: string;
    manufacturerId: string;
    categoryId: string;
    tagIds: string[];
    imageRc: UploadChangeParam<UploadFile>;
    image: File;
}
