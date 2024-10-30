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
                throw this.handleApiError(error, 'Error en el inicio de sesión');
            } else {
                throw this.handleApiError(error, 'Error en el inicio de sesión');
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
        try {
            const response = await axios.post(`${baseUrl}/login`, {
                nombreLogin: nombre,
                numeroCliente: numero,
            });
            return response.data;
        } catch (error) {
            throw this.handleApiError(error, 'Error en el inicio de sesión');
        }
    }

    handleApiError(error, defaultMessage) {
        if (error.response && error.response.data && error.response.data.error) {
            return new Error(error.response.data.error);
        } else {
            return new Error(defaultMessage || 'Ha ocurrido un error.');
        }
    }
}

export default new ReservationService();
