import axios from "axios";
import { CategoryCreateDto } from "../dtos/category.create-dto";

export const loadCategoryCombo =  async () => await axios.get('/api/categories/combo');
export const loadCategories = async () => await axios.get('/api/categories');
export const createCategory = async (values: CategoryCreateDto) => await axios.post('/api/categories', values);
