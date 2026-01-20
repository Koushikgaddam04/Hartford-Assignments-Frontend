/** * Day 12 - Advance JavaScript Assignment 
 * Task Implementation 
 */

// Local Data [cite: 19, 20, 21]
const policiesData = [
    { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active"},
    { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive"},
    { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active"},
    { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" }
];

let policies = [];

// TASK 1: Fetch Insurance Policies (Fetch + Async/Await) [cite: 15, 17]
async function fetchInsuranceData() {
    try {
        // Simulate API call with a promise
        const data = await new Promise((resolve, reject) => {
            const apiSuccess = true; // Set to false to test Task 8 Error Handling [cite: 46]
            setTimeout(() => {
                apiSuccess ? resolve(policiesData) : reject("Failed to fetch API data");
            }, 1000);
        });
        policies = data;
        displayPolicies(policies);
        updateTotalPremium();
    } catch (error) {
        document.getElementById('error-message').innerText = `Error: ${error}`; // [cite: 11, 44]
    }
}

// TASK 2: Display Policies (Objects & Arrays) [cite: 22, 24]
function displayPolicies(data) {
    const tableBody = document.getElementById('policy-body');
    tableBody.innerHTML = ""; 

    data.forEach(policy => {
        const row = `<tr>
            <td>${policy.id}</td>
            <td>${policy.name}</td>
            <td>${policy.type}</td>
            <td>${policy.premium}</td>
            <td>${policy.duration}</td>
            <td class="${policy.status === 'Active' ? 'status-active' : 'status-inactive'}">${policy.status}</td>
            <td>
                <button onclick="approvePolicy(${policy.id})">Approve</button>
            </td>
        </tr>`;
        tableBody.innerHTML += row;
    });
}

// TASK 3: Filter Policies (filter) [cite: 25, 26]
function handleFilter(type) {
    const filtered = policies.filter(p => p.type === type); // [cite: 27, 28, 29]
    displayPolicies(filtered);
}

// TASK 4: Calculate Total Premium (reduce) [cite: 30, 31]
function updateTotalPremium() {
    const total = policies
        .filter(p => p.status === "Active")
        .reduce((acc, curr) => acc + curr.premium, 0);
    document.getElementById('total-premium').innerText = total;
}

// TASK 5: Premium Discount Logic (map) [cite: 32, 33]
function handleDiscount() {
    policies = policies.map(p => {
        if (p.premium > 10000) {
            return { ...p, premium: p.premium * 0.9 }; // Apply 10% discount
        }
        return p;
    });
    displayPolicies(policies);
    updateTotalPremium();
}

// TASK 6 & 7: Policy Approval Simulation (Callback & Promise) [cite: 34, 35, 41, 42]
function approvePolicy(id) {
    // TASK 7: Promise-based logic [cite: 42]
    const simulateApproval = (policyId) => {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                const index = policies.findIndex(p => p.id === policyId);
                if (index !== -1) {
                    policies[index].status = "Active"; // Simulate approval change
                    resolve(policies[index]);
                } else {
                    reject("Invalid Policy ID"); // TASK 8 Error Handling [cite: 45]
                }
            }, 2000); // 2 second delay [cite: 35]
        });
    };

    simulateApproval(id)
        .then(updatedPolicy => {
            alert(`Policy ${updatedPolicy.name} has been approved!`);
            displayPolicies(policies);
            updateTotalPremium();
        })
        .catch(err => alert(err));
}

// Initialize Project [cite: 7]
fetchInsuranceData();