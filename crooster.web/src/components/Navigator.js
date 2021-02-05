import React, { useEffect, useRef } from 'react';
import M from 'materialize-css';
import { Link } from 'react-router-dom';

const Navbar = () => {
    const navigator = useRef();
    const list = [
        {name: 'Amigos', link: "/Amigos"},
        {name: 'Gallo-Semental', link: "/galloSemental"},
        {name: 'Gallina', link: "/gallina"}
]

    useEffect(()=>{
        M.Sidenav.init(navigator.current);
    }, []);

    const handleClick =()=>{
        const instance  = M.Sidenav.getInstance(navigator.current);
        instance.close();
    }
    return (
        <nav className="">
            <div className="nav-wrapper deep-purple darken-3">
                <a href="#/" className="brand-logo">Logo</a>
                <a href="#/" data-target="menu" className="sidenav-trigger">
                    <i className="material-icons">menu</i>
                </a>
                <ul id="side" className="right hide-on-med-and-down">
                {list.map((target, index)=>{
                    return(<li key={index}><Link to={target.link}>{target.name}</Link></li>)
                })}
                </ul>
                <ul className="sidenav" id="menu" ref={navigator}>
                {list.map((target, index)=>{
                    return(<li key={index} onClick={handleClick}><Link to={target.link}>{target.name}</Link></li>)
                })}
                </ul>
            </div>
        </nav>
    );
}

export default Navbar;