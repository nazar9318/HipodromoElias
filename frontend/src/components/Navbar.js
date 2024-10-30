import React from 'react';
import LogoutButton from './LogoutButton';
import { Link } from 'react-router-dom';
import { useAuth } from '../AuthContext/AuthContext';
import '../styles/Navbar.css';

const Navbar = () => {
	const { clienteId } = useAuth();
    return (
        <div className="nav">
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
				<Link to="/mesas" className="button">
					Lista de Mesas
				</Link>
				{clienteId === 0 && (
					<>
						<Link to="/categorias" className="button">
							Lista de Categorias
						</Link>
						<Link to="/clientes" className="button">
							Lista de Clientes
						</Link>
					</>
				)}
				<LogoutButton />					
			</div>
		</div>
    );
};

export default Navbar;
