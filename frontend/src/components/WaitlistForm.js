import React from 'react';
import ReservationService from '../services/ReservationService';

const WaitlistForm = ({ numPersonas, categoria, setAgregarAListaEspera }) => {
    const manejarListaEspera = async () => {
        await ReservationService.agregarAListaEspera(numPersonas, categoria);
        alert('Ha sido agregado a la lista de espera.');
        setAgregarAListaEspera(false);
    };

    return (
        <div>
            <p>No hay mesas disponibles. ¿Desea ser agregado a la lista de espera?</p>
            <button onClick={manejarListaEspera}>Agregar a la lista de espera</button>
            <button onClick={() => setAgregarAListaEspera(false)}>Cancelar</button>
        </div>
    );
};

export default WaitlistForm;
