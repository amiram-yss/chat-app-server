import RegistrationForm from './RegistrationForm';
import { BrowserRouter, Routes, Route, Switch, Link } from 'react-router-dom';
import './LoginCard.css';
import { useState } from 'react';





function LoginCard({ Login }) {

    const [details, setDetails] = useState({ name: "", nickName: "", password: "", error: "" });

    const submitHandler = e => {
        e.preventDefault()

        //Login(details);

        if (!Login(details)) {

            setDetails({ ...details, error: "1" })
        }
    }

    if (details.error != "") {

        return (

            <form onSubmit={submitHandler}>
                <div className="row inputRow">
                    <div className="col-4"><span className="text-danger">User Name</span></div>
                    <div className="col-8 ">
    
                        <div className="form-outline mb-4">
                            <input type="text" id="form3Example5" className="form-control try" onChange={e => setDetails({ ...details, name: e.target.value })} value={details.name} />
                            <label className="form-label" htmlFor="form3Example3"></label>
                        </div>
                    </div>
                </div>
    
                <div className="row inputRow">
                    <div className="col-4"><span className="text-danger">Password</span></div>
                    <div className="col-8 ">
    
                        <div className="form-outline mb-4">
                            <input type="password" id="form3Example2" className="form-control try" onChange={e => setDetails({ ...details, password: e.target.value })} value={details.password} />
                            <label className="form-label" htmlFor="form3Example3"></label>
                        </div>
                    </div>
                </div>
    
                <div className="row inputRow">
                    <button type="submit" className="btn btn-primary btn-block mb-4">
                        Sign up
                    </button>
                </div>
    
                <p >Not a member? <Link to="/Register" >Register</Link></p>
    
            </form>
    
        )

        

    }


    return (

        <form onSubmit={submitHandler}>
            <div className="row inputRow">
                <div className="col-4"><span className="text-danger">User Name</span></div>
                <div className="col-8 ">

                    <div className="form-outline mb-4">
                        <input type="text" id="form3Example5" className="form-control" onChange={e => setDetails({ ...details, name: e.target.value })} value={details.name} />
                        <label className="form-label" htmlFor="form3Example3"></label>
                    </div>
                </div>
            </div>

            <div className="row inputRow">
                <div className="col-4"><span className="text-danger">Password</span></div>
                <div className="col-8 ">

                    <div className="form-outline mb-4">
                        <input type="password" id="form3Example2" className="form-control" onChange={e => setDetails({ ...details, password: e.target.value })} value={details.password} />
                        <label className="form-label" htmlFor="form3Example3"></label>
                    </div>
                </div>
            </div>

            <div className="row inputRow">
                <button type="submit" className="btn btn-primary btn-block mb-4">
                    Sign up
                </button>
            </div>

            <p >Not a member? <Link to="/Register" >Register</Link></p>

        </form>

    )
}

export default LoginCard;