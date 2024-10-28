import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider, useAuth } from './AuthContext/AuthContext';
import ReservationPage from './pages/ReservationPage';
import ReservationListPage from './pages/ReservationListPage';
import WaitlistPage from './pages/WaitListPage';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import TableList from './pages/TableList';
import CategoryList from './pages/CategoryList';
import ClientList from './pages/ClientList';

function App() {
    return (
        <AuthProvider>
            <Router>
                <Routes>
                    <Route path="/" element={<LoginPage />} />
                    <Route path="/home" element={<HomePage />} />
                    <Route path="/reservations" element={<ReservationPage />} />
                    <Route path="/reservation-list" element={<ReservationListPage />} />
                    <Route path="/waitlist" element={<WaitlistPage />} />
                    <Route path="/mesas" element={<TableList />} />
                    <Route path="/categorias" element={<CategoryList />} />
                    <Route path="/clientes" element={<ClientList />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
}

export default App;
