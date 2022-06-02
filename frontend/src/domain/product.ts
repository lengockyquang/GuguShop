import { Category } from './category';
import { Manufacturer } from './manufacturer';
export interface Product {
    name: string;
    id: string;
    code: string;
    manufacturerId: string;
    manufacturer: Manufacturer;
    categoryId: string;
    category: Category;
}