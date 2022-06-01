import users from './Users.js'
import server from '../data stractures/Server';

//const express = require("express")


class PostFun {
    constructor() {
        this.token = ""
        this.data = ""
    }
    setData(data) {
        this.data = data
    }
    setToken(token) {
        this.token = token
    }
    login(userName, password) {
        const request = new XMLHttpRequest()
        request.open("POST", 'http://localhost:5062/api/login?username=' + 
        userName + '&password=' + password, false
         )
         request.addEventListener('load', async (e) => {
            console.log("token: ", e.target.response);
            if(request.status === 200){
                //console.log(JSON.parse(request.response));
                this.token = e.target.response
                //return request.response;
            }else{
                alert("not 200");
            }
        })
        request.send()
        request.onload = async () => {
            console.log(request);
            if(request.status === 200){
                //console.log(JSON.parse(request.response));
                this.token = await (JSON.parse(request.response))
                console.log("token: ", this.token)
                //return request.response;
            }else{
                alert("not 200");
            }
        }
        /*let res = await fetch('http://localhost:5062/api/login?username=' + 
        userName + '&password=' + password, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        })
        let jdata = await res.json()
        this.token = jdata
        //$.ajax()*/
    }
    async post(url, data, async = false) {
        let res = await fetch(url, {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
                Authorization: 'token ' + this.token
             },
            body: data,
            
        })
        let jdata = await res.json()
        this.data = jdata

        //$.ajax()
    }
    get(url, async = false) {
        const request = new XMLHttpRequest()
        request.open("GET", url, async)
        request.setRequestHeader("Authorization", 'Bearer ' + this.token);
        request.addEventListener('load', async (e) => {
            console.log("get onload");
            if(request.status === 200){
                //console.log(JSON.parse(request.response));
                this.data = e.target.response
                //console.log("DTAT: ", this.data)
                //return request.response;
            }else{
                alert("not 200");
            }
        })
        request.send()
        request.onload = async () => {
            //console.log("get onload");
            if(request.status === 200){
                //console.log(JSON.parse(request.response));
                this.data = await (JSON.parse(request.response))
                //return request.response;
            }else{
                alert("not 200");
            }
        }
        /*let res = await fetch(url, {
            /*url: 'http://localhost:5062/api/contacts',
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                Authorization: 'token ' + this.token
             },
           
        })
        //$.ajax()
        let jdata = await res.json()
        this.data = jdata*/
        console.log("before return: ", this.data)
        return this.data
    }
    httpPost(theUrl, data = null, async = true, userName = null, password = null) {
        
        
        const request = new XMLHttpRequest();
        //     if(userName == null || password == null) {
        request.open("POST", theUrl, async);
        //     }
        //    else {
        //     request.open("POST", theUrl, async, userName, password);
        //    }
        request.send(data);
    
        request.onload = () => {
            //console.log(request);
            if (request.status === 200) {
                //console.log(JSON.parse(request.response));
                //callback(JSON.parse(request.response))
                //return request.response;
            } else {
                alert("not 200");
            }
        }
        //if(!async) return JSON.parse(request.response)
    
        return "async"
    }
}


export default PostFun
