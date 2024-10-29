import React, { useEffect, useState } from 'react';
import CategoryService from '../services/CategoryService';
import List from '../components/List';
import '../styles/List.css';

const CategoryListPage = () => {
    const [categorias, setCategorias] = useState([]);

    useEffect(() => {
        obtenerCategorias();
    }, []);

    const obtenerCategorias = async () => {
        const CategoriasData = await CategoryService.obtenerCategorias();
        setCategorias(CategoriasData);
    };

    const columns = ['Nombre', 'Prioridad'];
    const data = categorias.map((categoria) => ({
        nombre: categoria.nombre,
        prioridad: categoria.prioridad
    }));

    return (
        <div>
            <h1>Categorías</h1>
            {categorias.length === 0 ? (
                <p>No hay categorias disponibles</p>
            ) : (
                <List columns={columns} data={data}/>
            )}
        </div>
    );
};

export default CategoryListPage;
