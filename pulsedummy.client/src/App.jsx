import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Login from './auth/Login';
import Register from './auth/Register';
import HomePage from './HomePage';

function App() {
    return (
        <BrowserRouter>
        <Routes>
            <Route path="/" element={<Login/>}/>
            <Route path="/register" element={<Register/>}/>
            <Route path='/home' element={<HomePage/>} /> 
        </Routes>
        <ToastContainer />
        </BrowserRouter>
    )
    
}

export default App;