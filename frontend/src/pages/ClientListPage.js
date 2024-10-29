import React, { useEffect, useState } from 'react';
import ClientService from '../services/ClientService';
import List from '../components/List';
import '../styles/List.css';

const ClientListPage = () => {
    const [clientes, setClientes] = useState([]);

    useEffect(() => {
        obtenerClientes();
    }, []);

    const obtenerClientes = async () => {
        const ClientesData = await ClientService.obtenerClientes();
        setClientes(ClientesData);
    };

    const columns = ['Nombre', 'Categoría'];
    const data = clientes.map((cliente) => ({
        nombre: cliente.nombre,
        prioridad: cliente.categoria
    }));

    return (
        <div>
            <h1>Clientes</h1>
            {clientes.length === 0 ? (
                <p>No hay clientes disponibles</p>
            ) : (
                <List columns={columns} data={data} />
            )}
        </div>
    );
};

export default ClientListPage;
