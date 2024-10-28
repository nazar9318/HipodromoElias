import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/categorias';

class CategoryService {
    async obtenerCategorias() {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    }
}

export default new CategoryService();
