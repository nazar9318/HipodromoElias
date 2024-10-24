import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/reservas';

class ReservationService {
    async crearReserva(numeroCliente, categoriaCliente, fechaReserva, cantidadPersonas) {
        try {
            const response = await axios.post(`${baseUrl}`, {
                numeroCliente: numeroCliente,
                categoriaCliente: categoriaCliente,
                fechaReserva: fechaReserva,
                cantidadPersonas: cantidadPersonas
            });
            return response.data;
        } catch (error) {
            if (error.response) {
                const errorMessage = error.response.data.split(':')[1].split('\n')[0].trim();
                console.error('Error al crear la reserva:', error.response.data.error);
                alert(`Error: ${errorMessage}`);
            } else {
                console.error('Error al crear la reserva:', error.message);
                alert(`Error: ${error.message}`);
            }
        }
    };
    
    async agregarAListaEspera(numeroCliente, categoriaCliente, fechaReserva, cantidadPersonas) {
        const response = await axios.post(`${baseUrl}/lista-espera`, { numeroCliente, categoriaCliente, fechaReserva, cantidadPersonas });
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
