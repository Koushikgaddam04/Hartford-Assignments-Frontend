document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('enquiryForm');
    
    form.addEventListener('submit', function(e) {
        e.preventDefault();
        clearErrors();
        
        // Get form values
        const name = document.getElementById('fullName').value.trim();
        const email = document.getElementById('email').value.trim();
        const mobile = document.getElementById('mobile').value.replace(/\D/g, '');
        const requestType = document.getElementById('requestType').value;
        const policyType = document.getElementById('policyType').value;
        const message = document.getElementById('message').value.trim();
        const rating = document.querySelector('input[name="rating"]:checked');
        
        let isValid = true;
        
        // Validation rules
        if (!name) {
            showError('nameError', 'Full Name is required');
            isValid = false;
        }
        
        if (!email) {
            showError('emailError', 'Email is required');
            isValid = false;
        }
        
        if (mobile.length !== 10) {
            showError('mobileError', 'Mobile must be exactly 10 digits');
            isValid = false;
        }
        
        if (!requestType) {
            showError('requestError', 'Please select Request Type');
            isValid = false;
        }
        
        if (!policyType) {
            showError('policyError', 'Please select Policy Type');
            isValid = false;
        }
        
        if (message.length < 10) {
            showError('messageError', 'Message must be at least 10 characters');
            isValid = false;
        }
        
        if (!rating) {
            showError('ratingError', 'Please select a rating');
            isValid = false;
        }
        
        // Success handling
        if (isValid) {
            document.getElementById('successMsg').classList.remove('hidden');
            form.reset();
        }
    });
});

function showError(id, message) {
    const errorEl = document.getElementById(id);
    errorEl.textContent = message;
}

function clearErrors() {
    document.querySelectorAll('.error').forEach(el => {
        el.textContent = '';
    });
    document.getElementById('successMsg').classList.add('hidden');
}
