import { Row, Col, Container } from 'react-bootstrap'
import './ChatInterface.css'
import ChatList from './ChatList'
import MessageBubbleList from './MessageBubbleList'
import SubmissionView from './SubmissionView'
import LogedUserInfo from './LogedUserInfo'
import { useState } from 'react';
import Chat from "./data stractures/User";

import users from "./server info/Users";
import ActiveChatUserInfo from './ActiveChatUserInfo'




function ChatInterface(args) {

    const [A, setA] = useState({ change: "" });

    const REnder = e => {
        setA({ change: "B" })
    }

    const [activeChat, setActiveChat] = useState({ activeChat: "" });

    const changeActiveChat = chat => {
        setActiveChat({ activeChat: chat })
    }
/*
<input type={"file"} onChange={(e) => {
                if(activeChat.activeChat != ""){
                    activeChat.activeChat.upload(e.target.files[0])
                }
            }}/>
            */
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