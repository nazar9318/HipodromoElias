import React, { useEffect, useState } from 'react';
import ReservationList from '../components/ReservationList';
import ReservationService from '../services/ReservationService';

const WaitListPage = () => {
    const [listaEspera, setListaEspera] = useState([]);

    useEffect(() => {
        cargarListaEspera();
    }, []);

    const cargarListaEspera = async () => {
        const listaEsperaData = await ReservationService.obtenerListaEspera();
        setListaEspera(listaEsperaData);
    };

    return (
        <div className="list">
            <h2>Lista de Reservas</h2>
            <ReservationList reservas={listaEspera} />
        </div>
    );
}

export default WaitListPage;
