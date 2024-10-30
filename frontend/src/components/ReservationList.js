import React, { useEffect } from 'react';
import List from '../components/List';
import '../styles/Table.css';
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

    const columns = ['Cliente', 'Categoría', 'Mesa', 'Fecha', 'Acciones'];
    const data = reservas.map((reserva) => ({
        Cliente: reserva.nombreCliente,
        Categoria: reserva.categoriaCliente,
        Mesa: reserva.numeroMesa ? reserva.numeroMesa : 'En espera',
        Fecha: formatearFecha(reserva.fechaReserva),
        Acciones: <button
            style={{
                backgroundColor: reserva.numeroCliente === clienteId || clienteId === 0 ? 'red' : 'gray',
                cursor: reserva.numeroCliente === clienteId || clienteId === 0 ? 'pointer' : 'not-allowed',
            }}
            disabled={reserva.numeroCliente !== clienteId && clienteId !== 0}
            onClick={() => eliminarReserva(reserva.id)}>Eliminar</button>
    }));

    useEffect(() => {
        const reloadCount = sessionStorage.getItem('reloadCount');
        if (reloadCount < 1) {
            sessionStorage.setItem('reloadCount', String(reloadCount + 1));
            window.location.reload();
        } else {
            sessionStorage.removeItem('reloadCount');
        }
    }, []);

    return (
        <div>
            <List columns={columns} data={data} />
        </div>
    );
};

export default ReservationList;
