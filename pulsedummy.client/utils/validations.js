const validateEmail = (email) => {
const trimmedEmail = email.trim().toLowerCase();
const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
return regex.test(trimmedEmail);
} 

const validatePassword = (password) => {
    const trimmedPassword = password.trim();
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$/
    return regex.test(trimmedPassword);
}

export { validateEmail, validatePassword }