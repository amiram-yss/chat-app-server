import RegisterCard from './RegisterCard';


function RegistrationForm (){
    return(
        <section className="background">
        <div className="px-4 py-5 px-md-5 text-center  " >
            <div className="container">
                <div className="row gx-lg-5 align-items-center">
                    <div className="col-lg-4 mb-5 mb-lg-0">
                        <h1 className="my-5 display-5 fw-bold ls-tight">
                        Welcome to the inner WhatsApp of   <br />
                            <span className="text-warning display-3 fw-bold">---</span>
                        </h1>
                        <p className='welcomeText'>
                            
                        </p>
                    </div>

                    <div className="col-lg-8 mb-5 mb-lg-0">
                        <div className="card">
                            <div className="card-body py-5 px-md-5">

                            
                                <RegisterCard/>


                                
                            </div>
                        </div>
                    </div>
                    
                </div>
               
            </div >
               
            
        </div>

        
            
        
    </section>
    )
}

export default RegistrationForm;