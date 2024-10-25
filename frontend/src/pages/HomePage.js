import React from 'react';
import { Link } from 'react-router-dom';
import '../styles/HomePage.css';

const HomePage = () => {
	return (
		<div className="home-container">
			<h1>Bienvenido al Sistema de Reservas del Hipódromo</h1>
			<p>Seleccione una opción para continuar:</p>
			<div className="home-buttons">
				<Link to="/reservations" className="button">
					Formulario de Reserva
				</Link>
				<Link to="/reservation-list" className="button">
					Lista de Reservas
				</Link>
				<Link to="/waitlist" className="button">
					Lista de Espera
				</Link>
			</div>
		</div>
	);
};

export default HomePage;
