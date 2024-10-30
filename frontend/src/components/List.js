import React from 'react';
import '../styles/Table.css';

const List = ({ columns, data }) => {
    return (
        <table className="table">
            <thead>
                <tr>
                    {columns.map((col) => (
                        <th key={col}>{col}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((row, index) => (
                    <tr key={index}>
                        {Object.values(row).map((cell, idx) => (
                            <td key={idx}>{cell}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default List;
