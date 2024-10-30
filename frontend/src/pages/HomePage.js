import React, { useEffect, useState } from 'react';
import logo from '../assets/icon.png';
import image1 from '../assets/tucson5.jpg';
import image2 from '../assets/tucson4.jpg';
import image3 from '../assets/tucson-palermo-1200x675.jpg';
import { useAuth } from '../AuthContext/AuthContext';
import '../styles/HomePage.css';

const images = [
    image1,
    image2,
    image3,
];

const horarios = [
    { dia: 'Lunes a Viernes', horario: '10:00 AM - 10:00 PM' },
    { dia: 'Sábado', horario: '11:00 AM - 11:00 PM' },
    { dia: 'Domingo', horario: 'Cerrado' },
];

const HomePage = () => {
    const { nombreUsuario } = useAuth();
    /*const [currentImageIndex, setCurrentImageIndex] = useState(0);

    useEffect(() => {
        const intervalId = setInterval(() => {
            setCurrentImageIndex((prevIndex) => (prevIndex + 1) % images.length);
        }, 3000);

        return () => clearInterval(intervalId);
    }, []);*/

	return (
		<div className="home-container">
            <h1>¡Hola {nombreUsuario}!</h1>
            <h1>Gracias por elegirnos, ahora podrá reservar para usted y sus conocidos una mesa para los horarios disponibles</h1>
            <h1>Recuerde que hay un sólo horario, y que en cualquier momento puede consultar la disponibilidad de las mesas para la fecha en la que quiera reservar.
                Si no hay disponibilidad para la fecha que desea, puede solicitar quedar en lista de espera.</h1>
            <h1>¡Disfrute!</h1>
            <div className="info-container">
                <div className="horarios">
                    <h3>Horarios del Restaurante</h3>
                    <ul>
                        {horarios.map((horario, index) => (
                            <li key={index}>{horario.dia}: {horario.horario}</li>
                        ))}
                    </ul>
                </div>
                <div className="logo">
                    <img src={logo} alt="Logo" />
                </div>
                <div className="ubicacion">
                    <h3>Ubicación</h3>
                    <p>Av. del Libertador 4241</p>

                    <p>(Acceso por Tribuna Nueva)</p>

                    <p>Buenos Aires</p>
                </div>
            </div>
		</div>
	);
};

export default HomePage;
