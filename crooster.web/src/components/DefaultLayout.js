import React from 'react';
import Container from "./Container";
import Navbar from '../components/Navigator';

const DefaultLayout = (props) => {

    return (
        <>
        <header>
        <div className="row">
                <Navbar />
            </div>
            </header>
            <div className="container">
            <div className="col s12 m10">
                <Container>
                    {props.children}
                </Container>
            </div>
            </div>
        </>
    );
}
export default DefaultLayout;