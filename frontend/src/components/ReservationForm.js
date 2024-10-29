import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import WaitlistForm from './WaitlistForm';
import InputForm from './InputForm';
import { useAuth } from '../AuthContext/AuthContext';
import '../styles/ReservationForm.css';

const ReservationForm = () => {
    const [numCliente, setNumCliente] = useState('');
    const [numPersonas, setNumPersonas] = useState('');
    const [fecha, setFecha] = useState('');
    const [mensaje, setMensaje] = useState('');
    const [agregarAListaEspera, setAgregarAListaEspera] = useState(false);
    const { clienteId } = useAuth();

    const manejarReserva = async (e) => {
        e.preventDefault();
        try {
            const resultado = await ReservationService.crearReserva(clienteId == 0 ? numCliente : clienteId, fecha, numPersonas);
            if (resultado.exito) {
                setMensaje(`Reserva confirmada en la mesa ${resultado.numeroMesa}`);
            }
            else {
                setAgregarAListaEspera(resultado.preguntaListaEspera);
            }
        } catch (error) {
            setMensaje(error.mensaje);
        }
    };

    return (
        <div>
            <form onSubmit={manejarReserva}>
                {clienteId == 0 &&
                    <InputForm label="Número de Cliente:" type="number" value={numCliente} onChange={setNumCliente} min={1} />
                }
                <InputForm label="Número de Personas:" type="number" value={numPersonas} onChange={setNumPersonas} min={1} />
                <InputForm label="Fecha de Reserva:" type="date" value={fecha} onChange={setFecha} min={1} />
                <button type="submit">Reservar</button>
                {mensaje && <p>{mensaje}</p>}
            </form>

            {agregarAListaEspera && <WaitlistForm
                numCliente={numCliente}
                numPersonas={numPersonas}
                setAgregarAListaEspera={setAgregarAListaEspera}
                fecha={fecha}
            />}
        </div>
    );
};

export default ReservationForm;
