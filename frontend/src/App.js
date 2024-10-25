import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ReservationPage from './pages/ReservationPage';
import ReservationListPage from './pages/ReservationListPage';
import WaitlistPage from './pages/WaitListPage';
import HomePage from './pages/HomePage';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/reservations" element={<ReservationPage />} />
                <Route path="/reservation-list" element={<ReservationListPage />} />
                <Route path="/waitlist" element={<WaitlistPage />} />
            </Routes>
        </Router>
    );
}

export default App;
