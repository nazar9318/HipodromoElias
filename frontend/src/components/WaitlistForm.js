import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import Modal from './Modal';
import '../styles/WaitListForm.css';

const WaitlistForm = ({ numCliente, numPersonas, fecha, setAgregarAListaEspera }) => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const manejarListaEspera = async () => {
        await ReservationService.agregarAListaEspera(numCliente, fecha, numPersonas);
        setIsModalOpen(true);
    };

    const onClose = () => {
        setIsModalOpen(false);
        setAgregarAListaEspera(false);;
    }

    return (
        <div>
            <p>No hay mesas disponibles. ¿Desea ser agregado a la lista de espera?</p>
            <button onClick={manejarListaEspera}>Agregar a la lista de espera</button>
            <button onClick={() => setAgregarAListaEspera(false)}>Cancelar</button>
            <Modal
                isOpen={isModalOpen}
                onClose={() => onClose()}
                message={'Ha sido agregado a la lista de espera.'}
            />
        </div>
    );
};

export default WaitlistForm;
