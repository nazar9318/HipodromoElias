import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../AuthContext/AuthContext';
import ReservationService from '../services/ReservationService';
import '../styles/Login.css';

const LoginPage = () => {
    const { setClienteId } = useAuth();
    const [nombreUsuario, setNombreUsuario] = useState('');
    const [numeroUsuario, setNumeroUsuario] = useState('');
    const navigate = useNavigate();

    const handleLogin = async () => {
        const exito = await ReservationService.login(nombreUsuario, numeroUsuario);
        if (exito) {
            setClienteId(exito.clienteId);
            navigate('/home');
        } else {
            alert("Por favor ingrese nombre y número de usuario válidos");
        }
    };

    return (
        <div className="login-screen">
            <h2>Iniciar Sesión</h2>
            <div className="login-form">
                <input
                    type="text"
                    placeholder="Nombre de usuario"
                    value={nombreUsuario}
                    onChange={(e) => setNombreUsuario(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="Número de usuario"
                    value={numeroUsuario}
                    onChange={(e) => setNumeroUsuario(e.target.value)}
                />
                <button onClick={handleLogin}>Ingresar</button>
            </div>
        </div>
    );
};

export default LoginPage;
