import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/clientes';

class ClientService {
    async obtenerClientes() {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    }
}

export default new ClientService();
