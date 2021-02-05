import React, { useReducer } from 'react';
import Form from '../components/Form';
import Tabla from '../components/Tabla';

export default function Amigos() {
    const BUTTONS = ['Guardar'];

    const columns = ['Nombre', 'Email', 'Telefono', 'Prefijo']
    const ACTIONS = {
        NOMBRE: 'nombre',
        EMAIL: 'email',
        TELEFONO: 'telefono',
        PREFIJO: 'prefijo'
    };

    const reducer = (state, action) =>{
        switch (action.type) {
            case  ACTIONS.NOMBRE:
              return {
                ...state,
                nombre: action.payload
            };
            case  ACTIONS.EMAIL:
              return {
                ...state,
                email: action.payload
            };
            case  ACTIONS.TELEFONO:
              return {
                ...state,
                telefono: action.payload
            };
            case  ACTIONS.PREFIJO:
              return {
                ...state,
                prefijo: action.payload
            }
            default:
               return state;
        }
    }

    const [state, dispatch] = useReducer(reducer, {
        nombre: '',
        email: '',
        telefono: '',
        prefijo: ''
    });

    const {nombre, email, telefono, prefijo} = state;
    const handleSubmit = (e) =>{
        e.preventDefault();
    }
    const handleChange = (e) => {
        switch (e.target.name) {
            case 'nombre':
                dispatch({type: ACTIONS.NOMBRE, payload: e.target.value});
                break;
                case 'email':
                dispatch({type: ACTIONS.EMAIL, payload: e.target.value});
                break;
                case 'telefono':
                dispatch({type: ACTIONS.TELEFONO, payload: e.target.value});
                break;
                case 'prefijo':
                dispatch({type: ACTIONS.PREFIJO, payload: e.target.value});
                break;
            default:
                break;
        }
    };
    return (
        <div>
         <Form buttons={BUTTONS} handleSubmit={handleSubmit} title="Amigos">
         <div className="input-field col s6">
          <input placeholder="Nombre" name="nombre" type="text" 
          className="validate" onChange={handleChange} value={nombre} />
        </div>
        <div className="input-field col s6">
          <input placeholder="Email" name="email" type="text" 
          className="validate" onChange={handleChange} value={email} />
        </div>
        <div className="input-field col s6">
          <input placeholder="Telefono" name="telefono" type="text" 
          className="validate" onChange={handleChange} value={telefono} />
        </div>
        <div className="input-field col s6">
          <input placeholder="Prefijo" name="prefijo" type="text" 
          className="validate" onChange={handleChange} value={prefijo} />
        </div>
         </Form>
         <Tabla columns={columns}/>
        </div>
    )
}
