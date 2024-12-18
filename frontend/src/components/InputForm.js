import React from 'react';
import '../styles/ReservationForm.css';

const InputForm = ({ label, type, value, onChange, min }) => {
    return (
        <div>
            <label>{label}</label>
            <input
                style={{ width: '96%' }}
                type={type}
                value={value}
                onChange={onChange}
                min={min}
            />
        </div>
    );
};

export default InputForm;
