import axios from 'axios';

const baseUrl = 'http://localhost:5000/api/reservas';

class ReservationService {
    async crearReserva(numeroCliente, fechaReserva, cantidadPersonas) {
        try {
            const response = await axios.post(`${baseUrl}`, {
                numeroCliente: numeroCliente,
                fechaReserva: fechaReserva,
                cantidadPersonas: cantidadPersonas,
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
    
    async agregarAListaEspera(numeroCliente, fechaReserva, cantidadPersonas) {
        const response = await axios.post(`${baseUrl}/lista-espera`, {
            numeroCliente,
            fechaReserva,
            cantidadPersonas
        });
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

    async eliminarReserva(id) {
        const response = await axios.delete(`${baseUrl}/${id}`);
        return response.data;
    }

    async login(nombre, numero) {
        console.log('Datos a enviar:', nombre, numero);
        const response = await axios.post(`${baseUrl}/login`, {
            nombreLogin: nombre,
            numeroCliente: numero,
        });
        return response.data;
    }
}

export default new ReservationService();
