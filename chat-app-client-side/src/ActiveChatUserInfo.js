import { Button, Row, Col, Container } from 'react-bootstrap';
import AddNewContactPop from "./AddNewContactPop";
import './ActiveChatUserInfo.css'
import './ChatTile.css'

function ActiveChatUserInfo(args) {

    const Out = e => {
        args.LogOut();
    }
    if(args.chat=='')
        return (<Row className=''/>)
    return (
        <Row className='holder'>
            <Col className='pic-col'>
                <img className='self-prof-pic' src={args.chat.getAddresee(args.User).picture} />
            </Col>
            <Col className='name-col g-1'>
                <span className='name-holder'>
                    {args.chat.getAddresee(args.User).nickName}
                </span>
            </Col>
        </Row >
    );
}
export default ActiveChatUserInfo