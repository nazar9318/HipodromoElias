import React, { useState, useEffect } from 'react';
import ReservationService from '../services/ReservationService';
import ReservationForm from '../components/ReservationForm';
import ReservationList from '../components/ReservationList';
import '../styles/ReservationPage.css';

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

    return (
        <div className="container">
            <div className="form-container">
                <h1>Formulario de Reservaciones</h1>
                <ReservationForm cargarReservas={cargarReservas} cargarListaEspera={cargarListaEspera} />
            </div>

            <div className="lists-container">
                <div className="list">
                    <h2>Lista de Reservas</h2>
                    <ReservationList reservas={reservas} />
                </div>
                <div className="list">
                    <h2>Lista de Espera</h2>
                    <ReservationList reservas={listaEspera} />
                </div>
            </div>
        </div>
    );
};

export default ReservationPage;
