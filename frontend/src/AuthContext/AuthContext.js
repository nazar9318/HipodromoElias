import React, { createContext, useContext, useState } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [clienteId, setClienteId] = useState(-1);

    return (
        <AuthContext.Provider value={{ clienteId, setClienteId }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    return useContext(AuthContext);
};
