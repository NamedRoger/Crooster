import React, { useEffect, useRef } from 'react';
import M from 'materialize-css';

export default function Campos({select, padre, madre, handleChange}) {
    const element = useRef();
    useEffect(()=>{
        M.FormSelect.init(element.current)
    });
    if(!select){
        return null;
    }
    return (
        <>
        <div className="input-field col s12">
        <select required defaultValue="" name="select" onChange={handleChange} ref={element}>
          <option value="" disabled>Choose your option</option>
          <option value="1">Option 1</option>
          <option value="2">Option 2</option>
          <option value="3">Option 3</option>
        </select>
        <label>Materialize Select</label>
      </div>
      <div className="input-field col s6">
          <input required placeholder="Padre" name="padre" type="text" 
          className="validate" onChange={handleChange} value={padre}/>
        </div>
        <div className="input-field col s6">
          <input required placeholder="Madre" name="madre" type="text" 
          className="validate" onChange={handleChange} value={madre}/>
        </div>
      </>
    )
}
