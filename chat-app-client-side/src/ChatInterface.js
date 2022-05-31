import { Row, Col, Container } from 'react-bootstrap'
import './ChatInterface.css'
import ChatList from './ChatList'
import MessageBubbleList from './MessageBubbleList'
import SubmissionView from './SubmissionView'
import LogedUserInfo from './LogedUserInfo'
import { useState, useEffect } from 'react';
import Chat from "./data stractures/Chat";
import Message from "./data stractures/Message";
import interpeter from "./server info/Interpeter";

import users from "./server info/Users";
import ActiveChatUserInfo from './ActiveChatUserInfo'
import User from './data stractures/User'





function ChatInterface(args) {

    const [A, setA] = useState({ change: "" });

    

    const REnder = e => {
        setA({ change: "B" })
    }

    const [activeChat, setActiveChat] = useState({ activeChat: "" });

    const changeActiveChat = chat => {
        setActiveChat({ activeChat: chat })
    }

    //
    const [data, setData] = useState(null);
    const parseChats = (data) => {
        //console.log("data: type", typeof data)
        let con = (data)
        let chats = []
        let messages = []
        let c = ""
        //[Users[{name: ariel, nickname: AR}, {name, nickname}], Messages[{addresser, addresee, type, content}.....]]
        for(let i = 0; i < data.length; i++) {
            let cusers = data[i].users
            users.push(new User(cusers[0].name, cusers[0].pic, args.User.server, cusers[0].nickName))
            users.push(new User(cusers[1].name, cusers[1].pic, args.User.server, cusers[1].nickName))
            c = new Chat(users)
            for(let j = 0; j < data[i].messages.length; j++) {
                c.messages.push(new Message(data[i].messages[j].addresser, data[i].messages[j].addressee,
                     data[i].messages[j].type, data[i].messages[j].content))
            }
            chats.push(c)
        }
        args.User.chats = chats
    }

    // u = new User(con[i].id, con[i].pic, args.User.server, con.nickName)

    useEffect ( () => {
        const fetchData = async () => {
            const res = await (await fetch("http://localhost:5062/WeatherForecast"));
            const data = await res.json();
            setData(data);
        }
        fetchData()
        console.log("data content: ", data)
        
       
    }, []);
    

    // useEffect(() => {
    //     async function fetchData() {
    //       // You can await here
    //       const response = await MyAPI.getData(someId);
    //       // ...
    //     }
    //     fetchData();
    //   }, [someId]); // Or [] if effect doesn't need props or state



    console.log("data: ", data);
    if(data != null) {
        parseChats(data)
    }
    console.log(args.User)
    //args.User.update();
    return (
        
        <Row className='screen g-0'>
            
            <Col className='left'>
                <Row className='logged-user-info'>
                    <LogedUserInfo User={args.User} LogOut={args.LogOut} REnder={REnder}/>
                </Row>
                <Row className='chat-list-container' id = "ChatList">
                    <ChatList User={args.User} changeActiveChat={changeActiveChat} chat={activeChat.activeChat} />
                </Row>
            </Col>
            <Col className='right g-0'>
                <Row className='chat-user-info'>
                    <ActiveChatUserInfo chat={activeChat.activeChat} User = {args.User} REnder = {REnder}/>
                </Row>
                <Row className='messages-container' >
                    <Container>
                        <Col>
                            <MessageBubbleList
                                User={args.User}
                                chat={activeChat.activeChat}
                            />
                        </Col>
                    </Container>
                </Row>
                <Row className='submit-block'>
                    <div >
                        <SubmissionView
                            className='submittion-block'
                            onSubmitClick={(message) => {/** deleted */ }}
                            REnder={REnder}
                            User={args.User}
                            chat={activeChat.activeChat}
                        />
                    </div>
                </Row>
            </Col>
        </Row>
    )
}

export default ChatInterface