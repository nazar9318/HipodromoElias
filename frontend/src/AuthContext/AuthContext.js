import React, { createContext, useContext, useState, useEffect } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [clienteId, setClienteId] = useState(() => {
        const storedClienteId = localStorage.getItem('clienteId');
        return storedClienteId !== null ? parseInt(storedClienteId, 10) : -1;
    });

    useEffect(() => {
        if (clienteId !== -1) {
            localStorage.setItem('clienteId', clienteId);
        }
    }, [clienteId]);

    return (
        <AuthContext.Provider value={{ clienteId, setClienteId }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    return useContext(AuthContext);
};
