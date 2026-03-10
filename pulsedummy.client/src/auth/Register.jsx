import { useState } from "react";
import { FaLock, FaEnvelope, FaEye, FaEyeSlash, FaExclamationCircle, FaUser, FaPhone, FaBirthdayCake  } from "react-icons/fa";
import { toast } from "react-toastify";
import { validateEmail, validatePassword} from "../../utils/validations";
import { textType } from "../../utils/sanitize";
import "./commonStyles.css";

export default function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState(null);
    const [age, setAge] = useState(null);
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
    const [emailError, setEmailError] = useState('');
    const [passwordError, setPasswordError] = useState('');
    const [confirmPasswordError, setConfirmPasswordError] = useState('');
    const [firstNameError, setFirstNameError] = useState('');
    const [lastNameError, setLastNameError] = useState('');
    const [phoneNumberError, setPhoneNumberError] = useState('');
    const [ageError, setAgeError] = useState('');
    
    const resetForm = () => {
        setEmail('');
        setPassword('');
        setConfirmPassword('');
        setFirstName('');
        setLastName('');
        setPhoneNumber('');
        setAge('');
        setEmailError('');
        setPasswordError('');
        setConfirmPasswordError('');
        setFirstNameError('');
        setLastNameError('');
        setPhoneNumberError('');
        setAgeError('');
    }

    const handleRegister = async (e) => {
        e.preventDefault();
        
        let hasError = false;
        
        // Email validation
        if(!email.trim()){
            setEmailError("Email is Required");
            hasError = true;
        }
        else if(!(validateEmail(email))){
            setEmailError("Enter a valid email");
            hasError = true;
        }

        // Password validation
        if(!password){
            setPasswordError("Password is Required");
            hasError = true;
        }
        else if(password.trim().length <8) {
            setPasswordError("Password should be atleast 8 characters long.")
            hasError = true;
        }
        else if(!(validatePassword(password))){
            setPasswordError("Password should contain atleast 1 capital, small alphabet, atleast 1 special character, and atleast 1 number!");
            hasError = true;
        }

        // Confrim Password validation
        if(!confirmPassword){
            setConfirmPasswordError("Confirm Password is Required");
            hasError = true;
        }
        else if(confirmPassword.trim() !== password.trim()) {
            setConfirmPasswordError("Password and Confirm password must be same.")
            hasError = true;
        }

        // First Name validation
        if(!firstName){
            setFirstNameError("First Name is Required");
            hasError = true;
        }

        // Last Name validation
        if(!lastName){
            setLastNameError("Last Name is Required");
            hasError = true;
        }

        // Phone Number validation
        if(!phoneNumber){
            setPhoneNumberError("Phone Number is Required");
            hasError = true;
        }
        else if(phoneNumber.trim().length < 10 || phoneNumber.trim().length > 10){
            setPhoneNumberError("Phone Number length should be 10");
            hasError = true;
        }

        // Age validation
        if(!age){
            setAgeError("Age is Required");
            hasError = true;
        }
        else if(age.trim().length > 3 || age.trim() > 150){
            setAgeError("Age cannot be greater than 150 years");
            hasError = true;
        }

        if(hasError) return;

        const payload = {
            "Email": email,
            "Password": password,
            "FirstName": firstName,
            "LastName": lastName,
            "PhoneNumber": phoneNumber,
            "Age": age
        }

        try{
            setEmailError('');
            setPasswordError('');
            const response = await fetch("https://localhost:7251/api/auth/register", {
            method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(payload)
        });

        console.log("The response of api is ", response)
        console.log("The response status is ", response.status)
        
        const responseText = await response.text();
        console.log("The response text is", responseText);
        if(responseText === "Registration Success"){
            toast.success("Registration Successful!");
            resetForm();
        }
        else if(responseText === "Email already exists"){
            toast.error("This email is associated with another account");
        }
        else {
            toast.error("Something went wrong: ", responseText);
        }
        
       
        }
        catch(error){
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
        <div className="min-h-screen bg-gray-100 flex items-center justify-center bg-[url('/falling_drops.jpg')] bg-cover bg-center pt-3 pb-14">
            {/* <img src={waterImg} alt="Image" /> */}
            <div className="bg-white px-8 py-4 rounded-lg shadow-lg w-full max-w-md">
                <h1 className="text-3xl font-bold text-black mb-5 flex justify-center">Register</h1>
                <form onSubmit={handleRegister}>
                    <label className="mt-1 block">
                        <span className="font-bold">First Name</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaUser />    
                        <input 
                        placeholder="First Name" 
                        className="text-black focus: outline-none flex-1"
                        value={textType(firstName)}
                        onChange={(e)=> {setFirstName(e.target.value.replace(/\s+/g, '')); if(firstNameError) setFirstNameError('')}}
                        />
                        {firstNameError && <FaExclamationCircle color="red" />}
                        </div>

                        {firstNameError && <p className="text-red-500 text-sm">{firstNameError}</p>}
                    </label>

                    <label className="mt-3 block">
                        <span className="font-bold">Last Name</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaUser />    
                        <input 
                        placeholder="Last Name" 
                        className="text-black focus: outline-none flex-1"
                        value={textType(lastName)}
                        onChange={(e)=> {setLastName(e.target.value.replace(/\s+/g, '')); if(lastNameError) setLastNameError('')}}
                        />
                        {lastNameError && <FaExclamationCircle color="red" />}
                        </div>

                        {lastNameError && <p className="text-red-500 text-sm">{lastNameError}</p>}
                    </label>

                    


                    <label className="mt-3 block">
                        <span className="font-bold">Email</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaEnvelope />    
                        <input 
                        placeholder="Email Address" 
                        className="text-black focus: outline-none flex-1"
                        value={email}
                        onChange={handleEmailChange}
                        />
                        {emailError && <FaExclamationCircle color="red" />}
                        </div>

                        {emailError && <p className="text-red-500 text-sm">{emailError}</p>}
                    </label>


                    <label className="mt-3 block">
                        <span className="font-bold">Phone</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaPhone />    
                        <input 
                        placeholder="Phone Number" 
                        type="Number"
                        maxLength={10}
                        className="text-black focus: outline-none flex-1"
                        value={phoneNumber}
                        onChange={(e)=> {setPhoneNumber(e.target.value.replace(/\s+/g, '')); if(phoneNumberError) setPhoneNumberError('')}}
                        />
                        {phoneNumberError && <FaExclamationCircle color="red" />}
                        </div>

                        {phoneNumberError && <p className="text-red-500 text-sm">{phoneNumberError}</p>}
                    </label>

                    <label className="mt-3 block">
                        <span className="font-bold">Age</span> <a className="text-red-500">*</a>
                        <div className={`flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300`}>

                        <FaBirthdayCake />    
                        <input 
                        placeholder="Age" 
                        type="number"
                        maxLength={3}
                        className="text-black focus: outline-none flex-1"
                        value={age}
                        onChange={(e)=> {setAge(e.target.value.replace(/\s+/g, '')); if(ageError) setAgeError('')}}
                        />
                        {ageError && <FaExclamationCircle color="red" />}
                        </div>

                        {ageError && <p className="text-red-500 text-sm">{ageError}</p>}
                    </label>

                    <label className="mt-3 block">
                        <span className="font-bold">Password</span> <a className="text-red-500">*</a>
                        <div className="flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300">

                        <FaLock />   
                        <div className="flex items-center w-full">
                        <input 
                        placeholder="Password" 
                        type= {showPassword ? "text" : "password"}
                        className="text-black focus: outline-none flex-1"
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

                    <label className="mt-3 block">
                        <span className="font-bold">Confirm Password</span> <a className="text-red-500">*</a>
                        <div className="flex p-3  items-center gap-3 bg-[#dae8ed] border-b-2 border-gray-300">

                        <FaLock />   
                        <div className="flex items-center w-full">
                        <input 
                        placeholder="Confirm Password" 
                        type= {showConfirmPassword ? "text" : "password"}
                        className="text-black focus: outline-none flex-1" 
                        value={confirmPassword}
                        onChange={(e)=> {setConfirmPassword(e.target.value.replace('/\s+/g', '')); if(confirmPasswordError) setConfirmPasswordError('')}}
                        />
                        <button type="button" className="ml-3 cursor-pointer active:bg-gray-300 active:scale-95 transition" onClick={()=>setShowConfirmPassword(!showConfirmPassword)}>
                            {showConfirmPassword ? <FaEye /> : <FaEyeSlash />}
                        </button>

                        {confirmPasswordError && <FaExclamationCircle color="red" className="ml-2"/>}
                        </div> 
                        </div>

                        {confirmPasswordError && <p className="text-red-500 text-sm">{confirmPasswordError}</p>}
                    </label>

                   

                    <div className="flex justify-between">
                         <a href="/" className="flex justify-start my-0.5 cursor-pointer hover:text-green-300">Already have an account?</a>
                    <a href="" className="flex justify-end my-0.5 cursor-pointer hover:text-green-300">Forgot Password?</a>
                    </div>

                    <button type="submit" className="bg-[#5ac495] rounded-3xl p-3 w-full text-white cursor-pointer active:bg-green-400 transition-colors">
                        Register
                    </button>
                </form>
            </div>
        </div>
    )
}