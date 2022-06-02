import users from './Users.js'
import server from '../data stractures/Server';

//const express = require("express")



function httpGet(theUrl, mode, callback, data = null, async = true, userName = null, password = null) {

    const request = new XMLHttpRequest();
    if(userName == null || password == null) {
        request.open(mode, theUrl, async);
    }
   else {
    request.open(mode, theUrl, async, userName, password);
   }
    request.send(data);

    request.onload = () => {
        console.log(request);
        if(request.status === 200){
            //console.log(JSON.parse(request.response));
            callback(JSON.parse(request.response))
            //return request.response;
        }
    }
    if(!async) return JSON.parse(request.response)

    return "async"
}
export default httpGet
