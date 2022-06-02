import 'bootstrap/dist/css/bootstrap.min.css'
import './Luncher.css';
import ChatTile from './ChatTile';
import LoginForm from './LoginForm';
import React from 'react';
import users from './server info/Users';
import ChatInterface from './ChatInterface';


//import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route, Switch, Link } from 'react-router-dom';

import RegistrationForm from './RegistrationForm';
import { useState } from 'react';
import Welcome from './Welcome';
import User from './data stractures/User.js'
import Server from './data stractures/Server'


var server = new Server()
server.initialize()
server.upload("C:\Users\ben\Downloads\Blank diagram (1).png")

/**
 * 
 * @returns 
 *     for (let index = 0; index < users.length; index++) {
      const element = users[index];
      if (details.name == element.userName && details.password == element.pass) {
        console.log("Well Done!!!");
        setUser({
          name: details.name
        });
        return;
      }
    }
 */


function Luncher() {



  const LogOut = e => {

    setUser({
      name: "",
      password: ""
    });
    return true;
  }

  const Login = details => {


    if (server.BoolLoggingIn(details.name, details.password)) {
      setUser({
        name: details.name,
        password: details.password
      });
      return true;
    }

    return false;
  }

  const Registration = details => {
    console.log(details);
    let nickName = details.nickName
    if(nickName == "") {
      nickName = details.name
    }
    if (server.register(details.name, details.password, 'logo192.png', nickName)) {
      setUser({
        // name: details.name,
        // password: details.password
        name: "",
        password: ""


      });
      return true;
    }
    return false
  }

  const [user, setUser] = useState({ name: "", nickName: "", password: "" });

  return (
    <BrowserRouter>
      <div className='Luncher'>
        {(user.name != "") ? (<ChatInterface User={server.loggingIn(user.name, user.password)} LogOut={LogOut} />) : (<Welcome Login={Login} Registration={Registration} />)}
      </div>
    </BrowserRouter>
  );
}

export default Luncher;
