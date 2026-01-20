let usersArray = [];
const API_URL = 'https://jsonplaceholder.typicode.com/users';

const container = document.getElementById('user-list');
const totalContainer = document.getElementById('total-balance-display');
const updForm = document.getElementById("updForm");
const insForm = document.getElementById("insForm");
const delForm = document.getElementById("delForm");
const filForm = document.getElementById("filForm");

window.onload = () => fetchBankData();

// Task 1 & 6: Fetch with Loading and Error Handling
async function fetchBankData() {
    container.innerHTML = "<h2 style='text-align:center;'>Syncing Bank Records...</h2>"; 
    try {
        const response = await fetch(API_URL);
        if (!response.ok) throw new Error("API Connection Failed");
        const data = await response.json();
        
        
        usersArray = data.map(user => ({
            ...user,
            balance: Math.floor(Math.random() * (50000 - 10000 + 1)) + 10000,
            history: [{ type: 'Account Opened', amt: 0, time: new Date().toLocaleString() }] // Task 7
        }));
        
        displayUser();
    } catch (error) {
        container.innerHTML = `<h2 style='color:red;'>Error: ${error.message}</h2>`;
    }
}

// Task 1, 9 & 10: Display with Total Balance and Highlighting
function displayUser(arr = usersArray) {
    let htmlContent = "";
    
    // Task 10: Calculate total using reduce()
    const totalVault = arr.reduce((sum, user) => sum + user.balance, 0);
    totalContainer.innerHTML = `Total Bank Balance: ₹${totalVault.toLocaleString()}`;

    arr.forEach(user => {
        // Task 10: Highlight accounts with balance < 5,000
        const isLow = user.balance < 5000;
        const lowStyle = isLow ? "border: 2px solid #ef4444; background: rgba(239, 68, 68, 0.1);" : "";

        htmlContent += `
            <div class="user-card" style="${lowStyle}">
                <h3>${user.name}</h3>
                <p><strong>AccountNo:</strong> ${user.id}</p>
                <p><strong>Email:</strong> ${user.email}</p>
                <p><strong>Branch:</strong> ${user.address?.city || 'Main Branch'}</p>
                <p class="balance-text" style="${isLow ? 'color:#ef4444' : ''}">
                    Balance: ₹${user.balance.toLocaleString()}
                </p>
                <button onclick="viewHistory(${user.id})" style="background:none; border:1px solid #334155; font-size:10px; padding:3px 8px;">History</button>
            </div>
        `;
    });
    container.innerHTML = htmlContent;
}

// Task 8: Manual Sorting
function handleSort() {
    usersArray.sort((a, b) => b.balance - a.balance);
    displayUser();
}

// Task 3 & 8: Transaction Logic with Penalty
async function updateUser() {
    const id = document.getElementById("updateAccNo").value;
    const type = document.getElementById("tranType").value;
    const amt = Number(document.getElementById("amount").value);
    const index = usersArray.findIndex(u => u.id == id);

    if (index === -1) return alert("Account not found");

    // Task 3: Prevent withdrawal if insufficient balance
    if (type === "sub" && usersArray[index].balance < amt) {
        alert("Transaction Denied: Insufficient Funds!");
        return;
    }

    // Apply Transaction
    if (type === "add") usersArray[index].balance += amt;
    else if(usersArray[index].balance - amt < 5000){
        if(!confirm("Minimum balance rule violated! ₹500 penalty applied.")) return;
        usersArray[index].balance -= amt;
    }else usersArray[index].balance -= amt;

    // Task 8: Minimum Balance Rule (₹500 penalty if < ₹5,000)
    if (usersArray[index].balance < 5000) {
        usersArray[index].balance -= 500;
        usersArray[index].history.push({ type: 'PENALTY (Low Bal)', amt: 500, time: new Date().toLocaleString() });
    }

    // Task 7: Audit Trail entry
    usersArray[index].history.push({ 
        type: type === "add" ? "DEPOSIT" : "WITHDRAWAL", 
        amt: amt, 
        time: new Date().toLocaleString() 
    });

    displayUser();
    clearForms();
}

// Task 7: View History Function
function viewHistory(id) {
    const user = usersArray.find(u => u.id == id);
    let log = `Audit Trail for ${user.name}:\n\n`;
    user.history.forEach(h => log += `[${h.time}] ${h.type}: ₹${h.amt}\n`);
    alert(log);
}

// Task 2: Real-time Search
document.getElementById("filName").addEventListener('input', (e) => {
    const term = e.target.value.toLowerCase();
    const filtered = usersArray.filter(u => u.name.toLowerCase().startsWith(term));
    displayUser(filtered);
});

// Task 5: Delete with Confirmation
async function deleteUser() {
    const id = document.getElementById("deleteNo").value;
    if (confirm("Confirm account closure for ID: " + id + "?")) {
        try {
            await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
            usersArray = usersArray.filter(u => u.id != id);
            displayUser();
            clearForms();
        } catch (err) { alert("Delete failed"); }
    }
}

// Task 4: Insert Enable
function insertEnable() {
    clearForms();
    insForm.innerHTML = `
        <h3>New Account</h3>
        <input type="text" id="accName" placeholder="Holder Name">
        <input type="email" id="accEmail" placeholder="Email">
        <input type="text" id="accCity" placeholder="City">
        <input type="number" id="accBal" placeholder="Initial Deposit">
        <button onclick="insertUser()">Open Account (POST)</button>
    `;
}

async function insertUser() {
    const name = document.getElementById("accName").value;
    const email = document.getElementById("accEmail").value;
    const balance = Number(document.getElementById("accBal").value);
    const city = document.getElementById("accCity").value;
    const newUser = { name,email,city, balance, history: [{ type: 'Opened', amt: balance, time: new Date().toLocaleString() }] };

    try {
        const res = await fetch(API_URL, {
            method: 'POST',
            body: JSON.stringify(newUser),
            headers: { 'Content-type': 'application/json; charset=UTF-8' }
        });
        const data = await res.json();
        usersArray.push(data);
        displayUser();
        clearForms();
    } catch (err) { alert("POST failed"); }
}

function updateEnable() {
    clearForms();
    updForm.innerHTML = `
        <h3>Transaction</h3>
        <input type="number" id="updateAccNo" placeholder="Acc No">
        <select id="tranType"><option value="add">Deposit</option><option value="sub">Withdraw</option></select>
        <input type="number" id="amount" placeholder="Amount">
        <button onclick="updateUser()">Submit</button>
    `;
}

function deleteEnable() {
    clearForms();
    delForm.innerHTML = `<h3>Close Account</h3><input type="number" id="deleteNo" placeholder="Acc No"><button style="background:var(--danger)" onclick="deleteUser()">Delete</button>`;
}

function clearForms() {
    [insForm, updForm, delForm].forEach(f => f.innerHTML = "");
}