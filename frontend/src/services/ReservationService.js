import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/reservas';

class ReservationService {

    async crearReserva(numeroCliente, categoriaCliente, fechaReserva, cantidadPersonas) {
        const response = await axios.post(`${baseUrl}`, {
            numeroCliente: numeroCliente,
            categoriaCliente: categoriaCliente,
            fechaReserva: fechaReserva,
            cantidadPersonas: cantidadPersonas
        });
        return response.data;
    }
    
    async agregarAListaEspera(numeroCliente, categoriaCliente, cantidadPersonas) {
        const response = await axios.post(`${baseUrl}/lista-espera`, { numeroCliente, categoriaCliente, cantidadPersonas });
        return response.data;
    }

    async obtenerReservas() {
        const response = await axios.get(`${baseUrl}`);
        return response.data;
    }

    async obtenerListaEspera() {
        const response = await axios.get(`${baseUrl}/lista-espera`);
        return response.data;
    }
}

export default new ReservationService();
