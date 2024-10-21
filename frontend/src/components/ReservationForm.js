import React, { useState } from 'react';
import ReservationService from '../services/ReservationService';
import WaitlistForm from './WaitlistForm';

const ReservationForm = () => {
    const [numPersonas, setNumPersonas] = useState('');
    const [categoria, setCategoria] = useState('');
    const [mensaje, setMensaje] = useState('');
    const [agregarAListaEspera, setAgregarAListaEspera] = useState(false);

    const manejarReserva = async (e) => {
        e.preventDefault();
        try {
            const resultado = await ReservationService.crearReserva(numPersonas, categoria);
            setMensaje(`Reserva confirmada en la mesa ${resultado.numeroMesa}`);
        } catch (error) {
            setAgregarAListaEspera(true);
        }
    };

    return (
        <div>
            <form onSubmit={manejarReserva}>
                <div>
                    <label>Número de Personas:</label>
                    <input type="number" value={numPersonas} onChange={(e) => setNumPersonas(e.target.value)} required />
                </div>
                <div>
                    <label>Categoría:</label>
                    <select value={categoria} onChange={(e) => setCategoria(e.target.value)} required>
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
