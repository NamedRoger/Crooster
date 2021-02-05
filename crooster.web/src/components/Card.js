import React from 'react'

export default function Card({placa,
   apodo, 
   fecha, 
   color, 
   img, 
   arete, 
  madre, 
  padre, 
  amigo}) {

  const Arete = () => {
    if (arete){
      return(
        <p>{`Arete: ${arete}`}</p>
      );
    }
    return null;
  }
  const Externo = () => {
    if(madre && padre && amigo) {
      return (
        <>
        <p>{`Amigo: ${amigo}`}</p>
        <p>{`Madre: ${madre}`}</p>
        <p>{`Padre: ${madre}`}</p>
        </>
      );
    }
    return null;
  };
    return (
        <div>
            <div className="row">
    <div className="col s12 m7">
      <div className="card">
        <div className="card-image">
          <img src={img} alt="" />
          <span className="card-title">{`${placa} ${Externo()===null ? '' : '(Externo)'}`}</span>
        </div>
        <div className="card-content left-align" style={{backgroundColor: `${color}`, 
        color: `${color==='#000000' ? '#ffffff': '#000000'}`}}>
          <h5>{`Apodo: ${apodo}`}</h5>
          <p>{fecha}</p>
          <Arete />
          <Externo />
        </div>
        <div className="card-action">
        <button className="waves-effect waves-light grey darken-2 btn">Editar</button>  
        <button className="waves-effect waves-light red btn">Eliminar</button>
        </div>
      </div>
    </div>
  </div>
        </div>
    )
}
