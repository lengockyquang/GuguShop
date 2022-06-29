import axios from "axios";

export const loadCategoryCombo =  async () => await axios.get('/api/categories/combo');