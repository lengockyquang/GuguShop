import axios from "axios";
import { ProductCreateDto } from "../dtos/product.create-dto";

export const createProduct = async (values: ProductCreateDto) => await axios.post('/api/products', values);
export const loadProduct =  async () => await axios.get('/api/products');
export const loadHomepageProducts = async () => await axios('/api/products/home-page');