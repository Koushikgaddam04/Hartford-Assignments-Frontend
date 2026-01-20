const insurancePlans = [
    { name: 'Health Insurance', basePremium: 3000, coverage: '₹5L', color: 'blue' },
    { name: 'Life Insurance', basePremium: 5000, coverage: '₹10L', color: 'purple' },
    { name: 'Vehicle Insurance', basePremium: 2000, coverage: '₹3L', color: 'green' }
    ,{ name: 'Home Insurance', basePremium: 8000, coverage: '₹15L', color: 'yellow' }
];

let customers = [];
let nextId = 1;

document.addEventListener('DOMContentLoaded', function() {
    renderPlans();
    setupEventListeners();
    updateStats();
});

function setupEventListeners() {
    const coverageSlider = document.getElementById('coverage');
    const coverageValue = document.getElementById('coverageValue');
    
    coverageSlider.addEventListener('input', function() {
        coverageValue.textContent = `₹${(this.value / 100000)}L`;
    });

    document.getElementById('customerForm').addEventListener('submit', handleFormSubmit);
    document.getElementById('filterPolicy').addEventListener('change', filterAndSearch);
    document.getElementById('searchName').addEventListener('input', filterAndSearch);
}

function renderPlans() {
    const container = document.getElementById('plansContainer');
    container.innerHTML = insurancePlans.map(plan => `
        <div class="bg-white p-8 rounded-2xl shadow-xl border border-gray-100 hover:shadow-2xl hover:-translate-y-2 transition-all duration-300 group cursor-pointer">
            <div class="text-2xl md:text-3xl font-bold text-${plan.color}-600 mb-4">${plan.name}</div>
            <div class="text-2xl font-bold text-gray-900 mb-2">₹${plan.basePremium.toLocaleString()}/yr</div>
            <div class="text-lg text-gray-600 mb-8">${plan.coverage} Coverage</div>
            <button class="w-full bg-gradient-to-r from-${plan.color}-500 to-${plan.color}-600 text-white py-4 px-6 rounded-xl font-semibold hover:from-${plan.color}-600 hover:to-${plan.color}-700 focus:ring-4 focus:ring-${plan.color}-200 transition-all duration-200 shadow-lg hover:shadow-xl" onclick="alert('Enroll feature coming soon!')">
                Enroll Now
            </button>
        </div>
    `).join('');
}

function handleFormSubmit(e) {
    e.preventDefault();
    clearErrors();

    const customer = {
        id: nextId++,
        name: document.getElementById('customerName').value.trim(),
        age: parseInt(document.getElementById('age').value),
        email: document.getElementById('email').value.trim(),
        policyType: document.getElementById('policyType').value,
        coverage: parseInt(document.getElementById('coverage').value)
    };

    let isValid = validateCustomer(customer);

    if (isValid) {
        customer.premium = calculatePremium(customer.age, customer.policyType, customer.coverage);
        customers.push(customer);
        renderTable();
        updateStats();
        e.target.reset();
        document.getElementById('coverage').value = 100000;
        document.getElementById('coverageValue').textContent = '₹1L';
    }
}

function validateCustomer(customer) {
    let valid = true;
    if (!customer.name) { showError('nameError', 'Name is required'); valid = false; }
    if (!customer.age || customer.age < 18 || customer.age > 80) { showError('ageError', 'Age must be 18-80'); valid = false; }
    if (!customer.policyType) { showError('policyError', 'Select policy type'); valid = false; }
    if (!customer.coverage) { showError('coverageError', 'Select coverage'); valid = false; }
    return valid;
}

function calculatePremium(age, policyType, coverage) {
    const basePremiums = { Health: 3000, Life: 5000, Vehicle: 2000 };
    let premium = basePremiums[policyType];
    if (age > 45) premium *= 1.2;
    premium += Math.floor((coverage - 100000) / 100000) * 500;
    return Math.round(premium);
}

function renderTable(filteredCustomers = customers) {
    const tbody = document.getElementById('customerTableBody');
    if (filteredCustomers.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" class="px-8 py-20 text-center text-gray-500 text-lg font-medium">No customers match the filter</td></tr>';
        return;
    }
    tbody.innerHTML = filteredCustomers.map(customer => `
        <tr class="hover:bg-gray-50 transition-colors duration-150">
            <td class="px-8 py-5 font-semibold text-gray-900">${customer.name}</td>
            <td class="px-6 py-5 text-gray-700">${customer.age}</td>
            <td class="px-6 py-5">
                <span class="inline-flex px-3 py-1 bg-blue-100 text-blue-800 text-sm font-medium rounded-full">
                    ${customer.policyType}
                </span>
            </td>
            <td class="px-6 py-5 text-gray-700">₹${(customer.coverage/100000).toFixed(1)}L</td>
            <td class="px-6 py-5 font-bold text-green-600">₹${customer.premium.toLocaleString()}</td>
        </tr>
    `).join('');
}

function filterAndSearch() {
    const filterPolicy = document.getElementById('filterPolicy').value;
    const searchName = document.getElementById('searchName').value.toLowerCase();
    let filtered = customers.filter(customer => 
        (!filterPolicy || customer.policyType === filterPolicy) &&
        (!searchName || customer.name.toLowerCase().includes(searchName))
    );
    renderTable(filtered);
}

function updateStats() {
    document.getElementById('totalCustomers').textContent = customers.length;
    document.getElementById('totalPremium').textContent = customers.reduce((sum, c) => sum + c.premium, 0).toLocaleString();
}

function showError(id, message) {
    document.getElementById(id).textContent = message;
}

function clearErrors() {
    document.querySelectorAll('.error').forEach(el => el.textContent = '');
}
