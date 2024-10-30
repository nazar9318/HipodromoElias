import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import WaitlistForm from './WaitlistForm';
import InputForm from './InputForm';
import Modal from './Modal';
import { useAuth } from '../AuthContext/AuthContext';

const ReservationForm = () => {
    const [numCliente, setNumCliente] = useState('');
    const [numPersonas, setNumPersonas] = useState('');
    const [fecha, setFecha] = useState('');
    const [mensaje, setMensaje] = useState('');
    const [agregarAListaEspera, setAgregarAListaEspera] = useState(false);
    const { clienteId } = useAuth();
    const [isModalOpen, setIsModalOpen] = useState(false);

    const handleNumeroChange = (event) => {
        setNumCliente(event.target.value);
    };

    const handleCantidadChange = (event) => {
        setNumPersonas(event.target.value);
    };

    const handleFechaChange = (event) => {
        setFecha(event.target.value);
    };

    const manejarReserva = async (e) => {
        e.preventDefault();
        try {
            const resultado = await ReservationService.crearReserva(clienteId == 0 ? numCliente : clienteId, fecha, numPersonas);
            if (resultado.exito) {
                setMensaje(`¡Reserva confirmada en la mesa ${resultado.numeroMesa}!`);
                setIsModalOpen(true);
            }
            else {
                setAgregarAListaEspera(resultado.preguntaListaEspera);
            }
        } catch (error) {
            setMensaje(error.message);
            setIsModalOpen(true);
        }
    };

    return (
        <div>
            <form onSubmit={manejarReserva}>
                {clienteId == 0 &&
                    <InputForm label="Número de Cliente:" type="number" value={numCliente} onChange={handleNumeroChange} min={1} />
                }
                <InputForm label="Número de Personas:" type="number" value={numPersonas} onChange={handleCantidadChange} min={1} />
                <InputForm label="Fecha de Reserva:" type="date" value={fecha} onChange={handleFechaChange} min={1} />
                <button type="submit">Reservar</button>
            </form>

            {agregarAListaEspera && <WaitlistForm
                numCliente={numCliente}
                numPersonas={numPersonas}
                setAgregarAListaEspera={setAgregarAListaEspera}
                fecha={fecha}
            />}
            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                message={mensaje}
            />
        </div>
    );
};

export default ReservationForm;
