import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/reservas';

class ReservationService {

    async crearReserva(numPersonas, categoria) {
        const response = await axios.post(`${baseUrl}`, { numPersonas, categoria });
        return response.data;
    }

    async agregarAListaEspera(numPersonas, categoria) {
        const response = await axios.post(`${baseUrl}/waitlist`, { numPersonas, categoria });
        return response.data;
    }

    async obtenerReservas() {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    }

    async obtenerListaEspera() {
        const response = await axios.get(`${baseUrl}/waitlist`);
        return response.data;
    }
}

export default new ReservationService();
