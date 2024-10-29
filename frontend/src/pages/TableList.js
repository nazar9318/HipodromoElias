import React, { useEffect, useState } from 'react';
import TableService from '../services/TableService';
import List from '../components/List';
import InputForm from '../components/InputForm';
import '../styles/ReservationForm.css';
import '../styles/List.css';
import '../styles/MesaList.css';

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

    const columns = ['Número de Mesa', 'Capacidad Total', 'Personas Ocupando'];
    const data = mesas.map((mesa) => ({
        numeroMesa: mesa.numeroMesa,
        capacidadTotal: mesa.capacidadTotal,
        personasOcupando: mesa.personasOcupando
    }));

    return (
        <div>
            <form onSubmit={(e) => { e.preventDefault(); obtenerMesas(); }} style={{ display: 'flex', flexDirection: 'column', gap: '15px', width: '50%', justifySelf: 'center' }}>
                <h1>Disponibilidad de Mesas</h1>
                <InputForm 
                    label="Fecha (opcional):" 
                    type="date" 
                    value={fecha} 
                    onChange={handleFechaChange} 
                    min={1} 
                />
                <button type="submit">Consultar Mesas</button>
            </form>
            <h2>Mesas Disponibles</h2>
            {mesas.length === 0 ? (
                <p>No hay mesas disponibles para la fecha seleccionada.</p>
            ) : (
                <List columns={columns} data={data} />
            )}
        </div>
    );
};

export default TableList;
