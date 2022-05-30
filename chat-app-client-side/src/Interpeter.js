import users from './Users.js'
import server from '../data stractures/Server';

//const express = require("express")



function httpGet(theUrl) {


    const request = new XMLHttpRequest();
    request.open("GET", theUrl);
    request.send();

    request.onload = () => {
        console.log(request);
        if(request.status === 200){
            console.log(JSON.parse(request.response));
        }
    }
    // fetch(theUrl)
    // .then(res => res.json())
    // .then(data => console.log(data))
    return "aa"
}
export default httpGet
