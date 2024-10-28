import React, { useEffect, useState } from 'react';
import CategoryService from '../services/CategoryService';
import '../styles/List.css';

const CategoryList = () => {
    const [categorias, setCategorias] = useState([]);

    useEffect(() => {
        obtenerCategorias();
    }, []);

    const obtenerCategorias = async () => {
        const CategoriasData = await CategoryService.obtenerCategorias();
        setCategorias(CategoriasData);
    };

    return (
        <div>
            <h1>Categorias</h1>
            <button onClick={obtenerCategorias}>Consultar Categorias</button>

            <h2>Categorias Disponibles</h2>
            {categorias.length === 0 ? (
                <p>No hay categorias disponibles</p>
            ) : (
                <ul>
                    {categorias.map((categoria) => (
                        <li key={categoria.nombre}>
                            Categoria {categoria.nombre} - Prioridad: {categoria.prioridad}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default CategoryList;
