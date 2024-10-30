import React, { createContext, useContext, useState, useEffect } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [nombreUsuario, setNombreUsuario] = useState('');
    const [clienteId, setClienteId] = useState(() => {
        const storedClienteId = localStorage.getItem('clienteId');
        return storedClienteId !== null ? parseInt(storedClienteId, 10) : -1;
    });

    const login = (id, nombre) => {
        setClienteId(id);
        setNombreUsuario(nombre);
    };

    const logout = () => {
        setClienteId(null);
        setNombreUsuario('');
    };

    useEffect(() => {
        if (clienteId !== -1) {
            localStorage.setItem('clienteId', clienteId);
        }
    }, [clienteId]);

    return (
        <AuthContext.Provider value={{ clienteId, nombreUsuario, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    return useContext(AuthContext);
};
