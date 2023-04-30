const passwordInput = document.getElementById('password');
const submitButton = document.getElementById('submit');
const correctPassword = 'password123'; //will change after git push

function checkPassword() {
    if (passwordInput.value === correctPassword) {
        submitButton.disabled = false;
    } else {
        submitButton.disabled = true;
    }
}

passwordInput.addEventListener('input', checkPassword);
