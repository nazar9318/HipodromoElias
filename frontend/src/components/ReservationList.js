import React from 'react';
import '../styles/List.css';
import { useAuth } from '../AuthContext/AuthContext';

const ReservationList = ({ reservas, eliminarReserva }) => {
    const { clienteId } = useAuth();
    const formatearFecha = (fechaISO) => {
        const fecha = new Date(fechaISO);
        const dia = String(fecha.getDate()).padStart(2, '0');
        const mes = String(fecha.getMonth() + 1).padStart(2, '0');
        const anio = fecha.getFullYear();
        return `${dia}/${mes}/${anio}`;
    };

    return (
        <ul>
            {reservas.map((reserva) => (
                <li key={reserva.id}>
                    Cliente: {reserva.nombreCliente},
                    Categoria: {reserva.categoriaCliente},
                    Mesa {reserva.numeroMesa ? reserva.numeroMesa : 'En espera'},
                    Fecha: {formatearFecha(reserva.fechaReserva)}
                    {(reserva.numeroCliente === clienteId || clienteId == 0) && (
                        <button onClick={() => eliminarReserva(reserva.id)}>Eliminar</button>
                    )}
                </li>
            ))}
        </ul>
    );
};

export default ReservationList;
