import React from 'react';

const Tabla = ({columns}) => {
    return (
        <table>
            <thead className="deep-purple lighten-4">
                <tr>
                    {columns.map((column, index)=>{
                        return(<th key={index}>{column}</th>)
                    })}
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                
            </tbody>
        </table>
    );
}

export default Tabla;