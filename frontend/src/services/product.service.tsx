import axios from "axios";
import { ProductCreateDto } from "../dtos/product.create-dto";

export const createProduct = async (values: ProductCreateDto) => await axios.post('/api/product/create', values);
export const loadProduct =  async () => await axios.get('/api/product/index');