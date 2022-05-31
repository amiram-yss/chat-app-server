import Message from './Message'
import interpeter from '../server info/Interpeter.js'


class Chat {

    constructor(users) {
        this.users = users
        this.messages = Array()
    }
    sendMessage(message) {
        this.messages.push(message)
        // interpeter("http://localhost:5062/api/transfer", "POST", ()=>{},
        //  {from: message.addresser, to: message.addresser, content: message.content} )

    }
    getLastMessage() {
        return this.messages.at(-1)
    }

    getAddresee(user) {
        if (user == this.users[0])
            return this.users[1]
        return this.users[0]

    }
    static resizeImage(base64Str, maxWidth = 500, maxHeight = 500) {
        return new Promise((resolve) => {
          let img = new Image()
          img.src = base64Str
          img.onload = () => {
            let canvas = document.createElement('canvas')
            const MAX_WIDTH = maxWidth
            const MAX_HEIGHT = maxHeight
            let width = img.width
            let height = img.height
      
            if (width > height) {
              if (width > MAX_WIDTH) {
                height *= MAX_WIDTH / width
                width = MAX_WIDTH
              }
            } else {
              if (height > MAX_HEIGHT) {
                width *= MAX_HEIGHT / height
                height = MAX_HEIGHT
              }
            }
            canvas.width = width
            canvas.height = height
            let ctx = canvas.getContext('2d')
            ctx.drawImage(img, 0, 0, width, height)
            resolve(canvas.toDataURL())
          }
        })
      }
    async upload(file, addresser, addressee) {
        let a = await Chat.convertBase64(file)
        console.log("this is base64", a)
        let type = "txt"
        if(a.startsWith('data:audio')) {
            type = "rec"
        }
        if(a.startsWith('data:video')) {
            type = "vid"
        }
        if(a.startsWith('data:image')) {
            type = "img"
            a = await Chat.resizeImage(a)
        }
        this.sendMessage({
            content: a,
            type: type,
            time: new Date(),
            addresser: addresser,
            addressee: addressee
        })
    }

    static convertBase64(file) {
        return new Promise((resolve, reject) => {
            const fileReader = new FileReader()
            fileReader.readAsDataURL(file)
            fileReader.onload = () => {
                resolve(fileReader.result)
            }
            fileReader.onerror = (error) => {
                reject(error)
            }
        })
    }
} export default Chat