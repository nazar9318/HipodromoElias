import React, { useEffect, useState } from 'react';
import TableService from '../services/TableService';
import '../styles/List.css';

const TableList = () => {
    const [mesas, setMesas] = useState([]);
    const [fecha, setFecha] = useState('');

    useEffect(() => {
        obtenerMesas();
    }, []);

    const obtenerMesas = async () => {
        const MesasData = await TableService.obtenerMesas(fecha);
        setMesas(MesasData);
    };

    const handleFechaChange = (event) => {
        setFecha(event.target.value);
    };

    return (
        <div>
            <h1>Disponibilidad de Mesas</h1>
            <label htmlFor="fecha">Fecha (opcional):</label>
            <input
                type="date"
                id="fecha"
                value={fecha}
                onChange={handleFechaChange}
            />
            <button onClick={obtenerMesas}>Consultar Mesas</button>

            <h2>Mesas Disponibles</h2>
            {mesas.length === 0 ? (
                <p>No hay mesas disponibles para la fecha seleccionada.</p>
            ) : (
                <ul>
                    {mesas.map((mesa) => (
                        <li key={mesa.numeroMesa}>
                            Mesa {mesa.numeroMesa} - Capacidad: {mesa.capacidadTotal} - Ocupadas: {mesa.personasOcupando}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default TableList;
