import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import WaitlistForm from './WaitlistForm';
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
                    <div>
                        <label>Número de Cliente:</label>
                        <input
                            style={{ width: '96%' }}
                            type="number"
                            value={numCliente}
                            onChange={(e) => setNumCliente(e.target.value)}
                            min={1}
                        />
                    </div>
                }
                <div>
                    <label>Número de Personas:</label>
                    <input 
                        style={{width: '96%'}}
                        type="number" 
                        value={numPersonas} 
                        onChange={(e) => setNumPersonas(e.target.value)} 
                        min={1}
                    />
                </div>
                <div>
                    <label>Fecha de Reserva:</label>
                    <input 
                        style={{width: '96%'}}
                        type="date" 
                        value={fecha}
                        onChange={(e) => setFecha(e.target.value)}
                        min={1}
                    />
                </div>
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
