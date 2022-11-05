import axios from "axios";
import { ManufacturerCreateDto } from "../dtos/manufacturer.create-dto";

export const loadManufacturerCombo =  async () => await axios.get('/api/manufacturers/combo');
export const loadManufacturers = async () => await axios.get('/api/manufacturers');
export const createManufacturer = async (values: ManufacturerCreateDto) => await axios.post('/api/manufacturers', values);
