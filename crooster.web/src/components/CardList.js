import React from 'react';
import Card from './Card';

export default function CardList({items}) {
    if (items.length===0){
        return (
            <div className="row">
                No hay items disponibles
            </div>
        );
    }
    return (
        <div>
            <Card {...items[0]} />
        </div>
    )
}
