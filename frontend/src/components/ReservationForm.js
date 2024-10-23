import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import WaitlistForm from './WaitlistForm';
import '../styles/ReservationForm.css';

const ReservationForm = ({ cargarReservas, cargarListaEspera }) => {
    const [numCliente, setNumCliente] = useState('');
    const [numPersonas, setNumPersonas] = useState('');
    const [categoria, setCategoria] = useState('');
    const [mensaje, setMensaje] = useState('');
    const [agregarAListaEspera, setAgregarAListaEspera] = useState(false);

    const manejarReserva = async (e) => {
        e.preventDefault();
        try {
            const resultado = await ReservationService.crearReserva(numCliente, categoria, new Date().toISOString(), numPersonas);
            if (resultado.exito) {
                setMensaje(`Reserva confirmada en la mesa ${resultado.numeroMesa}`);
            }
            else {
                setAgregarAListaEspera(resultado.preguntaListaEspera);
            }
            cargarReservas();
        } catch (error) {
            setMensaje(error.mensaje);
        }
        cargarReservas();
        cargarListaEspera();
    };

    return (
        <div>
            <form onSubmit={manejarReserva}>
                <div>
                    <label>Número de Cliente:</label>
                    <input 
                        style={{width: '96%'}}
                        type="number" 
                        value={numCliente} 
                        onChange={(e) => setNumCliente(e.target.value)}
                        min={1}
                    />
                </div>
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
                        value={numPersonas} 
                        onChange={(e) => setNumPersonas(e.target.value)} 
                        min={1}
                    />
                </div>
                <div>
                    <label>Categoría:</label>
                    <select style={{width: '99%'}} value={categoria} onChange={(e) => setCategoria(e.target.value)} required>
                        <option value="">Seleccionar</option>
                        <option value="Classic">Classic</option>
                        <option value="Gold">Gold</option>
                        <option value="Platinum">Platinum</option>
                        <option value="Diamond">Diamond</option>
                    </select>
                </div>
                <button type="submit">Reservar</button>
                {mensaje && <p>{mensaje}</p>}
            </form>

            {agregarAListaEspera && <WaitlistForm numPersonas={numPersonas} categoria={categoria} setAgregarAListaEspera={setAgregarAListaEspera} />}
        </div>
    );
};

export default ReservationForm;
