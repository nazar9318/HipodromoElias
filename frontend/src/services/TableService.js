import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/mesas';

class TableService {
    async obtenerMesas(fecha = null) {
        const formattedDate = fecha ? fecha.split('-').join('-') : null;
        const url = formattedDate ? `${baseUrl}/disponibles?fecha=${formattedDate}` : `${baseUrl}/disponibles`;
        const response = await axios.get(url);
        return response.data;
    }
}

export default new TableService();
