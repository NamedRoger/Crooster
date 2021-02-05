import React from 'react';

export default function Alert({item}) {
    if(item) {
        return (
            <div style={{backgroundColor: 'red', width: '100%'}}>
                <i className="material-icons">highlight_off</i>
                <p>Debes llenar este campo</p>
            </div>
        )
    }
    return null;
}
