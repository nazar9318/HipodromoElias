import React from 'react';

const ReservationList = ({ reservas }) => {
    return (
        <ul>
            {reservas.map((reserva) => (
                <li key={reserva.id}>
                    Cliente {reserva.numeroCliente}, Mesa {reserva.numeroMesa ? reserva.numeroMesa : 'En espera'}
                </li>
            ))}
        </ul>
    );
};

export default ReservationList;
