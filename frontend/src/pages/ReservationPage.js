import React from 'react';
import ReservationForm from '../components/ReservationForm';
import '../styles/ReservationPage.css';

const ReservationPage = () => {
    return (
        <div className="container">
            <div className="form-container">
                <h1>Formulario de Reservaciones</h1>
                <ReservationForm/>
            </div>
        </div>
    );
};

export default ReservationPage;
