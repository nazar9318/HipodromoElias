import React, { useEffect, useState } from 'react';
import ReservationList from '../components/ReservationList';
import ReservationService from '../services/ReservationService';

const ReservasPage = () => {
    const [reservas, setReservas] = useState([]);

    useEffect(() => {
        cargarReservas();
    }, []);

    const cargarReservas = async () => {
        const reservasData = await ReservationService.obtenerReservas();
        setReservas(reservasData);
    };

    const eliminarReserva = async (id) => {
        const exito = await ReservationService.eliminarReserva(id);
        if (exito) {
            cargarReservas();
        }
    };

    return (
        <div className="list">
            <h2>Lista de Reservas</h2>
            <ReservationList reservas={reservas} eliminarReserva={eliminarReserva} />
        </div>
    );
}

export default ReservasPage;
