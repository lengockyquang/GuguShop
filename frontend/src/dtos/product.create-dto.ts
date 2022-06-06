export interface ProductCreateDto {
    code: string;
    name: string;
    manufacturerId: string;
    categoryId: string;
    tagIds: string[];
}