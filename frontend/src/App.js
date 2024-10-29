import React from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';
import { AuthProvider } from './AuthContext/AuthContext';
import ReservationPage from './pages/ReservationPage';
import ReservationListPage from './pages/ReservationListPage';
import WaitlistPage from './pages/WaitListPage';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import TableList from './pages/TableList';
import CategoryListPage from './pages/CategoryListPage';
import ClientListPage from './pages/ClientListPage';
import Navbar from './components/Navbar';

function AppContent () {
    const location = useLocation();
    const isLoginPage = location.pathname === '/';
    return (
        <AuthProvider>
            {!isLoginPage && <Navbar />}
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/home" element={<HomePage />} />
                <Route path="/reservations" element={<ReservationPage />} />
                <Route path="/reservation-list" element={<ReservationListPage />} />
                <Route path="/waitlist" element={<WaitlistPage />} />
                <Route path="/mesas" element={<TableList />} />
                <Route path="/categorias" element={<CategoryListPage />} />
                <Route path="/clientes" element={<ClientListPage />} />
            </Routes>
        </AuthProvider>
    );
}

const App = () => (
    <Router>
        <AppContent />
    </Router>
);

export default App;
