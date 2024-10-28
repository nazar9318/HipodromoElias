import React, { useEffect, useState } from 'react';
import ClientService from '../services/ClientService';
import '../styles/List.css';

const ClientList = () => {
    const [clientes, setClientes] = useState([]);

    useEffect(() => {
        obtenerClientes();
    }, []);

    const obtenerClientes = async () => {
        const ClientesData = await ClientService.obtenerClientes();
        setClientes(ClientesData);
    };

    return (
        <div>
            <h1>Clientes</h1>
            <button onClick={obtenerClientes}>Consultar Clientes</button>

            <h2>Clientes Disponibles</h2>
            {clientes.length === 0 ? (
                <p>No hay clientes disponibles</p>
            ) : (
                <ul>
                    {clientes.map((cliente) => (
                        <li key={cliente.nombre}>
                            Cliente: {cliente.nombre} - Categoria: {cliente.categoria}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default ClientList;
