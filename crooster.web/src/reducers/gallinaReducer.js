 import { ACTIONS } from '../helpers/ACTION';
export const reducer = (state, action) =>{
    switch (action.type) {
        case  ACTIONS.PLACA:
          return {
            ...state,
            placa: action.payload
        };
        case  ACTIONS.APODO:
          return {
            ...state,
            apodo: action.payload
        };
        case  ACTIONS.COLOR:
          return {
            ...state,
            color: action.payload
        };
        case  ACTIONS.SELECTED:
          return {
            ...state,
            selected: action.payload
        };
        case  ACTIONS.IMG:
          return {
            ...state,
            img: action.payload
        };
        case  ACTIONS.ITEMS:
          return {
            ...state,
            items: action.payload
        };
        case  ACTIONS.ARETE:
          return {
            ...state,
            arete: action.payload
        };
        case  ACTIONS.MADRE:
          return {
            ...state,
            madre: action.payload
        };
        case  ACTIONS.PADRE:
          return {
            ...state,
            padre: action.payload
        };
        case  ACTIONS.AMIGO:
          return {
            ...state,
            amigo: action.payload
        };
        default:
           return state;
    }
}