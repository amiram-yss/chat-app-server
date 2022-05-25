/**@author Amiram Yassif */
import { Button, Badge, Row, Col, Container } from 'react-bootstrap';
import 'bootstrap'
import './ChatTile.css'
/**
 * Chat tile, set on the main page on the left.
 * @param {*} args
 * @param {unreadCounter} Num of unread messages
 * @param {profPic} Profile picture
 * @param {lastMessageTime} Recieve time of last message
 * @param {chatTitle} Name of content
 * @param {lastMessage} Test of last message.
 * @returns 
 */
function ChatTile(args) {
    console.log("args: ", args)
    var cName = "chat-tile-container " + (args.isSelected ? "selected-tile":"")
    return (
        <div>
            <div className='spacer' />
            <Button className={cName} onClick = {()=>{
                let chat = args.User.getChat(args.chatId)
                if(chat != null) {
                    args.changeActiveChat(chat)
                }}}>
                <Row>
                    <Col className='left-col'>
                        <div className='test'>
                            <img className='prof-pic' src={args.profPic}></img>
                        </div>
                    </Col>
                    <Col >
                        <div className='chat-title'>{args.chatTitle}</div>
                        <div className='last-message'>{args.lastMessage}</div>
                    </Col>
                    <Col className='right-col'>
                        {args.unreadCounter < 1 ? <></> : <Badge className='notification-bubble'>{args.unreadCounter}</Badge>}
                        <div className='time-text'>
                            {args.lastMessageTime}
                        </div>
                    </Col>
                </Row>
            </Button>
        </div>
    );
}
export default ChatTile