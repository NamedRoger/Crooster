import React, { useEffect, useRef, useReducer } from 'react';
import Form from '../components/Form';
import CardList from '../components/CardList';
import M from 'materialize-css';
import Campos from '../components/Campos';
import { reducer } from '../reducers/gallinaReducer';
import { ACTIONS } from '../helpers/ACTION';

export default function GalloSemental() {
    const element = useRef();
    useEffect(()=>{
        M.Datepicker.init(element.current,{
            defaultDate: new Date(),
            setDefaultDate: true
        });
    }, []);
    const BUTTONS = ['Guardar'];

    const [state, dispatch] = useReducer(reducer, {
        placa: '',
        apodo: '',
        color: '#ffffff',
        selected: false,
        img: '',
        madre: '',
        padre: '',
        amigo: '',
        items: []
    });

    const {placa, apodo, color, selected, img, items, madre, padre, amigo} = state;

    const handleSubmit = (e) =>{
        e.preventDefault();
       const date = M.Datepicker.getInstance(element.current).toString();
       dispatch({type: ACTIONS.ITEMS, payload: [{
        placa,
        apodo,
        fecha: date,
        color,
        img,
        madre,
        padre,
        amigo
       }]
      });
    }
    const handleChange = (e) => {
        switch (e.target.name) {
            case 'placa':
                dispatch({type: ACTIONS.PLACA, payload: e.target.value});
                break;
                case 'apodo':
                dispatch({type: ACTIONS.APODO, payload: e.target.value});
                break;
                case 'color':
                dispatch({type: ACTIONS.COLOR, payload: e.target.value});
                break;
                case 'imagen':
                dispatch({type: ACTIONS.IMG, payload: e.target.value});
                break;
                case 'madre':
                dispatch({type: ACTIONS.MADRE, payload: e.target.value});
                break;
                case 'padre':
                dispatch({type: ACTIONS.PADRE, payload: e.target.value});
                break;
                case 'select':
                dispatch({type: ACTIONS.AMIGO, payload: e.target.value});
                break;
            default:
                break;
        }
    };

    const handleRadioChange = (e)=>{
        switch (e.target.value) {
            case 'inactivo':
                dispatch({type: ACTIONS.SELECTED, payload: false});
                break;
                case 'activo':
                dispatch({type: ACTIONS.SELECTED, payload: true});
                break;
            default:
                break;
        }
    }
    return (
        <div>
         <Form buttons={BUTTONS} handleSubmit={handleSubmit} title="Gallos-Semental">
         <div className="input-field col s6">
          <input required placeholder="Placa" name="placa" type="text" 
          className="validate" onChange={handleChange} value={placa} />
        </div>
        <div className="input-field col s6">
          <input required placeholder="Apodo" name="apodo" type="text" 
          className="validate" onChange={handleChange} value={apodo} />
        </div>
        <div className="input-field col s6">
          <input required placeholder="Fecha de Nacimiento" type="text" 
          className="datepicker" ref={element} />
        </div>
        <div className="input-field col s6">
          <input required name="color" type="color" 
          className="validate" onChange={handleChange} value={color} />
          <span>Selecciona un color</span>
        </div>
        <div className="input-field col s12">
          <input required placeholder="Imagen" name="imagen" type="text" 
          className="validate" onChange={handleChange} value={img} />
        </div>
        <div className="input-field col s12 left-align">
          <div className="row">
            <div className="col s6">
    <p>
      <label>
        <input className="with-gap" name="group1" type="radio" onChange={handleRadioChange} value="inactivo" defaultChecked />
        <span>Local</span>
      </label>
    </p>
    </div>
    <div className="col s6">
    <p>
      <label>
        <input className="with-gap" name="group1" onChange={handleRadioChange} value="activo" type="radio" />
        <span>Externo</span>
      </label>
    </p>
    </div>
    </div>
        </div>
        <Campos select={selected}
        madre={madre} 
        padre={padre} 
        handleChange={handleChange} />
         </Form>
         <CardList items={items} />
        </div>
    )
}