import 'bootstrap/dist/css/bootstrap.min.css'
import './SubmissionView.css';
import React from 'react';
import { useState } from 'react';
import { Button, InputGroup, Form } from 'react-bootstrap'
import AddNewContactPop from './AddNewContactPop';
import User from './data stractures/User';




function SubmissionView(args) {

    const randomName = () => {
        if (args.chat == "") {
            //console.log("here")
            alert("please select chat")
            document.getElementById("ChatList").click()
        }
    }
    const [Text, setText] = useState({ text: "" });

    const sendMessage = e => {
        var time = new Date()
        //e.preventDefault()

        setText({ text: Text })
        // if(Text == ""){
        //     return
        // }
        if (args.chat != "") {
            let newMessage = { content: Text.text, time: new Date() }
            newMessage.addresser = args.User
            newMessage.addressee = args.chat
            newMessage.type = "txt"
            args.chat.sendMessage(newMessage)
            //console.info(args.chat)
        }
        else {
            alert("please select chat")
        }

        setText({ text: "" })
    }



    /**
     * <div></div>
     * 
     *  <AddNewContactPop/>
     * 
     * //onclick="doupload()"
     *
     */

    return (

        <div className="row box">
            <input type="file" accept="video/*" name="" id="input_video" hidden onChange={async (e) => {
                if (args.chat != "") {
                    await args.chat.upload(e.target.files[0], args.User, args.chat)
                    args.REnder()
                }
            }} />
            <input type="file" accept="audio/*" name="" id="input_audio" hidden onChange={async (e) => {
                if (args.chat != "") {
                    await args.chat.upload(e.target.files[0], args.User, args.chat)
                    args.REnder()
                }
            }} />
            <input type="file" accept="image/*" name="" id="input_image" hidden onChange={async (e) => {
                if (args.chat != "") {
                    await args.chat.upload(e.target.files[0], args.User, args.chat)
                    args.REnder()
                }
            }} />
            <div className="col optionBtn">
                <button className="optionBtn littlrBtn items" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false" onClick={randomName}>
                    <i className="bi bi-paperclip"></i>
                </button>
                <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                    <button className="OPTbtn" onClick={() => {
                        document.getElementById("input_audio").click()
                    }}>
                        <li><a href="#"><i className="dropdown-item bi bi-mic-fill" ></i></a></li>
                    </button >
                    <button className="OPTbtn" onClick={() => {
                        document.getElementById("input_video").click()
                    }}>
                        <li><a href="#"><i className="dropdown-item bi bi-camera-reels"></i></a></li>
                    </button>
                    <button className="OPTbtn" onClick={() => {
                        document.getElementById("input_image").click()
                    }}>
                        <li><a href="#"><i className="dropdown-item bi bi-image"></i></a></li>
                    </button>
                </ul>
            </div>

            <div className="col field">
                <Form>
                    <Form.Control
                        className='field msgbox'
                        type="text"
                        placeholder="Insert message . . ."
                        onChange={e =>
                            setText({ text: e.target.value })
                        }
                        value= {Text.text}
                    />
                </Form>
            </div>

            <div className="col sendBtn">
                <button className="littlrBtn items" onClick={() => {
                    if (Text.text == '')
                        return
                    sendMessage()
                    args.onSubmitClick(Text.text)
                    args.REnder()
                }}>
                    <i className="bi bi-send"></i>
                </button>
            </div>


        </div>
    );
}

export default SubmissionView;

/*
<input
                    type="input"
                    className="field msgbox"
                    placeholder="Type here..."
                    onChange={e => setText({ text: e.target.value })}
                    value={Text.text} />
*/