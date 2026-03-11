import { useState } from "react";
import { FaLock, FaEnvelope, FaEye, FaEyeSlash, FaExclamationCircle  } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import { validateEmail, validatePassword} from "../../utils/validations";
import "./commonStyles.css";
import { toast } from "react-toastify";

export default function Login() {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);
    const [emailError, setEmailError] = useState('');
    const [passwordError, setPasswordError] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        let hasError = false;

        if(!email.trim()){
            setEmailError("Email is Required");
            hasError = true;
        }
        else if(!(validateEmail(email))){
            setEmailError("Enter a valid email");
            hasError = true;
        }

        if(!password){
            setPasswordError("Password is Required");
            hasError = true;
        }
        else if(password.trim().length <8) {
            setPasswordError("Password should be atleast 8 characters long.")
            hasError = true;
        }
        else if(!(validatePassword(password))){
            setPasswordError("Password must include uppercase, lowercase, a number, and a special character.");
            hasError = true;
        }

        if(hasError) return;

        const payload = {
            "Email": email,
            "Password": password
        }

        try{
             setEmailError('');
        setPasswordError('');
            const response = await fetch("https://localhost:7251/api/auth/login", {
            method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(payload)
        });

        console.log("The response is", response);
        
        const responseText = await response.text();
        console.log("The response text is", responseText);
        if(responseText === "Login Success"){
            toast.success("Logged in Successfully")
            navigate('/home');
        }
        else if(responseText === "Invalid Email or Password"){
            toast.error("Invalid Email or Password")
        }
        else if(responseText === "Invalid Password"){
            toast.error("Invalid Password")
        }
        else{
            toast.error("Something went wrong: ", responseText)
        }

       
        }
        catch(error){
            console.log("The error is", error);
            toast.error("Something went wrong!")    
        }

    }

    const handleEmailChange = (e) => {
    const value = e.target.value.replace(/\s+/g, '');
    setEmail(value);
    if (emailError) setEmailError('');
};

const handlePasswordChange = (e) => {
    const value = e.target.value.replace(/\s+/g, '');
    setPassword(value);
    if (passwordError) setPasswordError('');
};

    return (
        <div className="min-h-screen bg-gray-100 flex items-center justify-center bg-[url('/falling_drops.jpg')] bg-cover bg-center">
            {/* <img src={waterImg} alt="Image" /> */}
            <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
                <h1 className="text-3xl font-bold text-black mb-10 flex justify-center">Login</h1>
                <form onSubmit={handleLogin}>
                    <label className="mt-3 block">
                        <span className="font-bold">Username</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaEnvelope />    
                        <input 
                        placeholder="User Name" 
                        className="text-black focus:outline-none flex-1"
                        value={email}
                        onChange={handleEmailChange}
                        />
                        {emailError && <FaExclamationCircle color="red" />}
                        </div>

                        {emailError && <p className="text-red-500 text-sm">{emailError}</p>}
                    </label>

                    <label className="mt-3 block">
                        <span className="font-bold">Password</span> <a className="text-red-500">*</a>
                        <div className="flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300">

                        <FaLock />   
                        <div className="flex items-center w-full">
                        <input 
                        placeholder="Password" 
                        type= {showPassword ? "text" : "password"}
                        className="text-black focus:outline-none flex-1"
                        value={password}
                        onChange={handlePasswordChange}
                        />
                        <button type="button" className="ml-3 cursor-pointer active:bg-gray-300 active:scale-95 transition" onClick={()=>setShowPassword(!showPassword)}>
                            {showPassword ? <FaEye /> : <FaEyeSlash />}
                        </button>

                        {passwordError && <FaExclamationCircle color="red" className="ml-2"/>}
                        </div> 
                        </div>

                        {passwordError && <p className="text-red-500 text-sm">{passwordError}</p>}
                    </label>
                    <div className="flex justify-between">
                         <a href="/register" className="flex justify-start my-0.5 cursor-pointer hover:text-green-300">Not Registered?</a>
                    <a href="" className="flex justify-end my-0.5 cursor-pointer hover:text-green-300">Forgot Password?</a>
                    </div>
                   

                    <button type="submit" className="bg-[#5ac495] rounded-3xl p-3 w-full text-white cursor-pointer active:bg-green-400 transition-colors">
                        LOGIN
                    </button>
                </form>
            </div>
        </div>
    )
}