


import 'bootstrap/dist/css/bootstrap.min.css'
import './AddNewContactPop.css';
import SubmissionView from './SubmissionView';
import { Modal, Button, Alert, Form } from 'react-bootstrap';
import React, { useEffect, useState } from "react";

//hahaha
function AddNewContactPop(args) { //User, render


    const [show, setShow] = useState(false);

    const [Name, setName] = useState({ name: "" });



    const handleOK = () => {

        let u = args.User.server.GetUserByName(Name.name)
        
        if (u != null && u.name != args.User.name) {
            args.User.addContact(u)
        }
        else if (u == null) {
            alert("username not found, please try again")
        }
        else {
            alert("cant add yourself as contact")
        }
        handleClose();
        args.REnder();

        //args.User.Server.GetUserByName(Name.name)

    }

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);




    return (
        <div>
            <Button variant="primary btn-sm circ" onClick={handleShow} data-backdrop='false' data-dismiss='modal'>
                <i className="bi bi-person-plus-fill"></i>
            </Button>
            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>add new contact</Modal.Title>
                </Modal.Header>
                <Modal.Body className='msg'>
                    write here new contact from your contacts
                </Modal.Body>

                <Form>
                    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                        <Form.Control
                            className='txtbox'
                            type="input"
                            placeholder="Insert username:"
                            onChange={e => setName({ name: e.target.value })}
                            value={Name.name}
                            autoFocus
                        />
                    </Form.Group>
                </Form>

                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancle
                    </Button>
                    <Button variant="primary" onClick={handleOK}>
                        create
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default AddNewContactPop;

/**
 *                 <input type="text" className="field items" placeholder="Type here..." onChange={e => setName({ name: e.target.value })} value={Name.name} />

 * 
 *            
 */

/**
 * 
 * 
 * 
 * 
}
 */
