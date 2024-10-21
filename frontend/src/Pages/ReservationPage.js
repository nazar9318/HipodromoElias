import React, { useState, useEffect } from 'react';
import ReservationService from '../services/ReservationService';
import ReservationForm from '../components/ReservationForm';
import ReservationList from '../components/ReservationList';

const ReservationPage = () => {
    const [reservas, setReservas] = useState([]);
    const [listaEspera, setListaEspera] = useState([]);

    useEffect(() => {
        cargarReservas();
        cargarListaEspera();
    }, []);

    const cargarReservas = async () => {
        const reservasData = await ReservationService.obtenerReservas();
        setReservas(reservasData);
    };

    const cargarListaEspera = async () => {
        const listaEsperaData = await ReservationService.obtenerListaEspera();
        setListaEspera(listaEsperaData);
    };

    const handleNuevaReserva = async (numPersonas, categoria) => {
        try {
            const reservaData = await ReservationService.crearReserva(numPersonas, categoria);
            cargarReservas();
        } catch (error) {
            if (error.mensaje === "No hay mesas disponibles, ¿quieres agregar a la lista de espera?") {
                const agregar = window.confirm("No hay mesas disponibles. ¿Deseas unirte a la lista de espera?");
                if (agregar) {
                    await ReservationService.agregarAListaEspera(numPersonas, categoria);
                    cargarListaEspera();
                }
            }
        }
    };

    return (
        <div>
            <h1>Reservaciones</h1>
            <ReservationForm onNuevaReserva={handleNuevaReserva} />
            <h2>Lista de Reservas</h2>
            <ReservationList reservas={reservas} />
            <h2>Lista de Espera</h2>
            <ReservationList reservas={listaEspera} />
        </div>
    );
};

export default ReservationPage;
