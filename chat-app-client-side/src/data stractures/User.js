import users from '../server info/Users.js'
import Chat from './Chat.js'
import Server from './Server.js'

class UserInfo {
    constructor(name, password) {
        this.name = name
        this.password = password
    }
} 

class User {
    /**
     * Single user object
     * @param {*} name name of user (key val)
     * @param {*} picture picture
     * @param {*} server server
     */
    constructor(name, picture, server, nickName = name) {
        this.name = name
        this.nickName = nickName
        this.picture = picture
        this.server = server
        this.contacts = new Map()
        this.chats = new Array()
    } 
    
    addContact(user) {
        if (this.server.searchUser(user.name) && !this.contacts.has(user.name)) {
            this.contacts.set(user.name, user)
            let chat = new Chat([this, user])
            user.contacts.set(this.name, this)
            this.chats.push(chat)
            user.addChat(chat)
        }        
    }
    changeProfilePicture(pic) {
        this.picture = pic
    }

    createChat(users) {
        for(let i = 0; i < users.length;i++){
            if(this.server.searchUser(users[i].name)==false) return null
        }
        let chat = new Chat(users)
        for(let i = 0; i < users.length; i++){
            users[i].addChat(chat)
        }
    }
    addChat(chat) {
        this.chats.push(chat)
    }
    getChat(userName){
        for(let i = 0; i < this.chats.length; i++) {
            if(this.chats[i].users[0].name === userName || this.chats[i].users[1].name === userName){
                return this.chats[i]
            }
        }
        return null
    }
} 

function consoleUser(user, index) {
    /*
    console.log("USER:")
    console.log("===============")
    console.log(user.name)
    console.log("contacts:")
    console.log(user.contacts.keys())

    console.log("chats:")
    for (let i = 0; i < user.chats.length; i++) {
        console.log("chat " + i)
        for(let j = 0; j < user.chats[i].users.length; j++)
        console.log(user.chats[i].users[j].name)
    }
    */
}

function main() {
    let server = new Server()
    server.initialize()
    let array = Array.from(server.userDB.values())
    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array.length; j++) {
            if (i != j) {
                array[i].addContact(array[j])
            }
        }
    }
    array[0].createChat(array)
    server.register("haha", "password", "jjjj.png")
    array[0].addContact(new User("haha", "jjjj.png"))
    array = Array.from(server.userDB.values())
    array.forEach(consoleUser)
}
export default User
//main()





