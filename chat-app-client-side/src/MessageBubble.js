/**
 * @author Amiram Yassif
 */
import { Card, Container } from 'react-bootstrap'
import './MessageBubble.css'
import timeStringForComponents from './Time'



/**
 * Message bubble item for chat view
 * @param {*} args content, time
 * @returns 
 */
function MessageBubble(args) {
    console.log(args)
    const messageType = 'message-bubble ' + (args.addresser ? 'message-sent' : 'message-recieved')
    let messagecontent = (<span className='message-content'>{args.content}</span>)
    let mimeType = args.content.match(/[^:]\w+\/[\w-+\d.]+(?=;|,)/)
    //console.log("content: ", mimeType)
    if(args.type == "img") {

        messagecontent = (<img src={(args.content)} className="limitedSizedBubble"></img>)
    }
    if(args.type == "vid") {
        if(mimeType == null) mimeType = ["video/mp4"]
        messagecontent = (<video controls>
            <source type={mimeType[0]} src={args.content} height="200px" width="200px"></source>

            </video>)
    }
    if(args.type == "rec") {
        if(mimeType == null) mimeType = ["audio/mp3"]
        messagecontent = (<audio controls>
            <source type={mimeType[0]} src={args.content} height="200px" width="200px"></source>

            </audio>)
    }
    return (
        <div className='test'>
            <Card className={messageType}>
                {messagecontent}
                <div>
                    <span className='message-time'>{timeStringForComponents(args.time)}</span>
                </div>
            </Card>
        </div>
    )
}

export default MessageBubble