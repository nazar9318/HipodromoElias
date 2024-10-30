import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../AuthContext/AuthContext';
import ReservationService from '../services/ReservationService';
import Modal from '../components/Modal';
import '../styles/Login.css';

const LoginPage = () => {
    const { login } = useAuth();
    const [nombreUsuario, setNombreUsuario] = useState('');
    const [numeroUsuario, setNumeroUsuario] = useState('');
    const [isModalOpen, setIsModalOpen] = useState(false);
    const navigate = useNavigate();

    const handleLogin = async () => {
        const exito = await ReservationService.login(nombreUsuario, numeroUsuario);
        if (exito) {
            login(numeroUsuario, nombreUsuario);
            navigate('/home');
        } else {
            setIsModalOpen(true);
        }
    };

    return (
        <div className="login-screen">
            <h2>¡Bienvenido al Sistema de Reservas del Restaurante Tucson!</h2>
            <h1>Por favor, ingrese sus credenciales para reservar o ver sus reservas</h1>
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
            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                message={"Por favor ingrese nombre y número de usuario válidos"}
            />
        </div>
    );
};

export default LoginPage;
