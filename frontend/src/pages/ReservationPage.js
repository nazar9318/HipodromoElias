import React from 'react';
import { useNavigate } from 'react-router-dom';
import ReservationForm from '../components/ReservationForm';
import '../styles/ReservationPage.css';

const ReservationPage = () => {
    const navigate = useNavigate();

    const irAListaReservas = () => {
        navigate('/reservation-list');
    };

    const irAListaEspera = () => {
        navigate('/waitlist');
    };

    return (
        <div className="container">
            <div className="form-container">
                <h1>Formulario de Reservaciones</h1>
                <ReservationForm/>
            </div>

            <div className="button-container">
                <button onClick={irAListaReservas}>Ver Lista de Reservas</button>
                <button onClick={irAListaEspera}>Ver Lista de Espera</button>
            </div>
        </div>
    );
};

export default ReservationPage;
