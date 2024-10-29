import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/LogoutButton.css';

const LogoutButton = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        navigate('/');
    };

    return (
        <button className="logout-button" onClick={handleLogout}>
            Logout
        </button>
    );
};

export default LogoutButton;
