import React from 'react';

const Form = (props) => {

  return (
    <div className="row">
    <form className="col s12" onSubmit={props.handleSubmit}>
        <h1 className="left-align">{props.title}</h1>
      <div className="row">
          <div>
          {props.children}
        </div>
        <div className="col s12">
        {props.buttons.map((button, index) => {
            return(<button className="btn" type="submit" key={index}>
            {button}
          </button>)
        })}
        </div>
      </div>
    </form>
    </div>
  );
}

export default Form;