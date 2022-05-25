
import { BrowserRouter, Routes, Route, Switch, Link } from 'react-router-dom';
import { useState } from 'react';



function RegisterCard({ Registration }) {

    const [details, setDetails] = useState({ name: "", nickName: "", password: "" });

    const submitHandler = e => {
        e.preventDefault()
        if(Registration(details) == false) {
            if(details.name == "") {
                alert("username empty")
            }
            else if (details.password == "") {
                alert("password empty")
            }
            else {
                alert("username already exists")
            }
        }
    }


    return (

        <form className="" >
            <div className="row inputRow">
                <div className="col-4"><span className="text-danger">User Name</span></div>
                <div className="col-8 ">

                    <div className="form-outline mb-4">
                        <input type="text" id="form3Example1" className="form-control" onChange={e => setDetails({ ...details, name: e.target.value })} value={details.name} />
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
                <div className="col-4"><span className="text-danger">Display Name</span></div>
                <div className="col-8 ">

                    <div className="form-outline mb-4">
                        <input type="text" id="form3Example3" className="form-control" onChange={e => setDetails({ ...details, nickName: e.target.value })} value={details.nickName} />
                        <label className="form-label" htmlFor="form3Example3"></label>
                    </div>
                </div>
            </div>



            <div className="row inputRow registerBTN">
                <Link to="/" className="btn btn-primary " onMouseDown={submitHandler}>
                    register
                </Link>
            </div>
            <br></br>

            <div className="row">
                <p >Already register? <Link to="/" >Login</Link></p>


            </div>


        </form>

    )
}

export default RegisterCard;