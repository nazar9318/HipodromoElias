import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider } from './AuthContext/AuthContext';
import ReservationPage from './pages/ReservationPage';
import ReservationListPage from './pages/ReservationListPage';
import WaitlistPage from './pages/WaitListPage';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';

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
                </Routes>
            </Router>
        </AuthProvider>
    );
}

export default App;
