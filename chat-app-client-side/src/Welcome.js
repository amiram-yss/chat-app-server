import 'bootstrap/dist/css/bootstrap.min.css'
import './Welcome.css';

import ChatTile from './ChatTile';
import Wrong from './Wrong';
import LoginForm from './LoginForm';
import RegistrationForm from './RegistrationForm';
import './server info/Users';
import parse from './server info/Interpeter';


import React from 'react';

//import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route, Switch, Link } from 'react-router-dom';

import { useState } from 'react';
import LoginCard from './LoginCard';
import RegisterCard from './RegisterCard';

import 'react-bootstrap'
import { Row } from 'react-bootstrap';
import users from './server info/Users';
import { Button } from 'bootstrap';


function Welcome({ Login, Registration }) {


    return (

        <section>
            <div className=" py-5 px-md-5 text-center screen" >
                <div className="row gx-lg-5 align-items-center">
                    <div className="col-lg-4 col-md-4 col-sm-4 mb-5 mb-lg-0 ">
                        <h1 className="my-5 display-5 fw-bold ls-tight welcomeText">
                            Welcome to the inner WhatsApp of   <br />
                            <span className="bikiniText display-3 fw-bold">Bikini Bottom</span>
                            <br /><br />
                            <h3 className="rateLine">click <a href='http://localhost:5122/'>here</a> to rate the app</h3>
                        </h1>
                    </div>

                    <div className="col-lg-8 col-md-8 col-sm-8 mb-5 mb-lg-3">
                        <div id="cardBlock" className="card ">
                            <div className="card-body py-5 px-md-5">
                                <Routes>
                                    <Route path="/" element={<LoginCard Login={Login} />}></Route>
                                    <Route path="/register" element={<RegisterCard Registration={Registration} />}></Route>
                                </Routes>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default Welcome;