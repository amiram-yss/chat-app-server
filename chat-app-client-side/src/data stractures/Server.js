import users from '../server info/Users.js'
import Message from './Message.js'
import User from './User.js'

class Server {

    constructor() {
        this.loginDB = new Map()
        this.userDB = new Map()
    }

    initialize() {
        for (let i = 0; i < users.length; i++) {
            //this.loginDB.set(users[i].userName, users[i].pass)
            //this.userDB.set(users[i], new User(users[i].userName, users[i].pic))
            this.register(users[i].userName, users[i].pass, users[i].pic)
        }
        this.userDB.get("Krabs").addContact(this.userDB.get("Spongebob"))
        this.userDB.get("Krabs").chats[0].sendMessage
            ({
                content: "Krusty Krab?",
                time: new Date(),
                addresser: this.userDB.get("Krabs"),
                addressee: this.userDB.get("Spongebob"),
                type: "txt"
            })
        this.userDB.get("Krabs").chats[0].sendMessage
            ({
                content: "KrAsty CrUb!!",
                time: new Date(),
                addresser: this.userDB.get("Spongebob"),
                addressee: this.userDB.get("Krabs"),
                type: "txt"
            })
        this.userDB.get("Krabs").chats[0].sendMessage
            ({
                content: "Rusty cab :D!!",
                time: new Date(),
                addresser: this.userDB.get("Krabs"),
                addressee: this.userDB.get("Spongebob"),
                type: "txt"
            })
        this.userDB.get("Krabs").addContact(this.userDB.get("Squidward"))
        this.userDB.get("Krabs").chats[1].sendMessage({
            content: "Shut UP",
            time: new Date(),
            addressee: this.userDB.get("Krabs"),
            addresser: this.userDB.get("Squidward"),
            type: "txt"
        })
        this.userDB.get("Krabs").chats[1].sendMessage({
            content: "BACK TO WOTK, SQUIDWARD! >:( ",
            time: new Date(),
            addressee: this.userDB.get("Squidward"),
            addresser: this.userDB.get("Krabs"),
            type: "txt"
        })
        this.userDB.get("Krabs").chats[1].sendMessage({
            content: "krabs.jpg",
            time: new Date(),
            addressee: this.userDB.get("Squidward"),
            addresser: this.userDB.get("Krabs"),
            type: "img"
        })
        this.userDB.get("Krabs").chats[1].sendMessage({
            content: "Screen_Recording_20220502-220051_YouTube (2).mp4",
            time: new Date(),
            addressee: this.userDB.get("Squidward"),
            addresser: this.userDB.get("Krabs"),
            type: "vid"
        })

    }

    register(name, password, pic, nickName = name) {
        if(name == "" || password == "") {
            return false
        }
        if (!this.userDB.has(name)) {

            this.loginDB.set(name, password)
            this.userDB.set(name, new User(name, pic, this, nickName))
            return true
        }
        else {
            return false
        }
    }

    //irelevant after server...
    searchUser(name) {

        return this.userDB.has(name)
    }

    loggingIn(userName, password) {

        
        // let jdata = interpeter("http://localhost:5062/api/login", "GET", ()=>{},
        //  null, false, userName ,password)
        //  if(jdata != false) {
        //      let u = new User(jdata.name, jdata.picture, jdata.server, jdata.nickName)
        //      u.chats = jdata.chats
        //      u.contacts = jdata.contacts
        //      return u
        //  }
        //  else {
        //      return null
        //  }

        if (this.searchUser(userName) && this.loginDB.get(userName) === password) {
            return this.userDB.get(userName)
        }
        else {
            return null
        }
    }


    BoolLoggingIn(userName, password) {
        if(this.loggingIn(userName, password) == null) {
            return false
        }
        else {
            return true
        }
        // if (this.searchUser(userName) && this.loginDB.get(userName) === password) {
        //     return true
        // }
        // else {
        //     return false
        // }
    }


    GetUserByName(userName){

        // let jdata = interpeter("http://localhost:5062/api/search", "GET", ()=>{},
        //  null, false, userName ,"")
        //  if(jdata != false) {
        //      let u = new User(jdata.name, jdata.picture, jdata.server, jdata.nickName)
        //      u.chats = jdata.chats
        //      u.contacts = jdata.contacts
        //      return u
        //  }
        //  else {
        //      return null
        //  }


        if(this.searchUser(userName) ){
            return this.userDB.get(userName)
        }
        else {
            return null
        }
    }

    upload(filePath){
        
    }

} export default Server