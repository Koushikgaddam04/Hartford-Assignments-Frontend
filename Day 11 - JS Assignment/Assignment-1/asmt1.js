

// Task - 1
let title = document.getElementById("pageTitle");
title.textContent = "Customer Insurance Overview";

//Task - 2 - 
let list = document.getElementsByTagName("li");
for (let i = 0; i < list.length; i++) {
    list[i].style.border = "1px solid black";
}

//Task - 3
let policies = document.getElementsByClassName("policy");
for (let i = 0; i < policies.length; i++) {
    policies[i].classList.add("highlight");
    policies[i].style.color = "blue";
}

//Task - 4
console.log("First customer:");
console.log(list[0].textContent);
console.log("All customers:");
for (let i = 0; i < list.length; i++) {
    console.log(list[i].textContent);
}
const lastCustomer = document.querySelector('#customerList li:last-child');
lastCustomer.classList.add('active');

//Task - 5
let forms = document.getElementsByTagName("form");
console.log("No of forms = ", forms.length);
let images = document.getElementsByTagName("img");
console.log("No of images = ", images.length);
let links = document.getElementsByTagName("a");
for(let i=0; i<links.length; i++){
    links[i].textContent = "More info";
}

//Task - 6 -
let ul = document.getElementById("customerList");
ul.innerHTML += '<li class="customer">Sita - Home</li>';


//Task - 7
let inp = document.createElement("input");
for(let i=0; i<inp.length; i++){
    if (inp[i].type === "text"){
        inp[i].style.backgroundColor = 'yellow';
    }
}
let cusName = document.getElementsByTagName("input")
console.log(cusName[0].placeholder);
cusName[0].placeholder="Enter Full Name";

// Task 8: Multiple Class Selection
const priorityCustomers = document.querySelectorAll('.customer.active');
priorityCustomers.forEach(customer => {
    customer.style.color = 'darkgreen';
    customer.style.fontWeight = 'bold';
    customer.textContent += ' Priority Customer';
});


// Task 9: Descendant vs Child Selector
// Descendant selector - ALL li elements inside customerList (any level)
const descendantLis = document.querySelectorAll('#customerList li');
console.log(`Descendant selector found ${descendantLis.length} li elements`);

// Direct child selector - ONLY direct li children of customerList
const directChildLis = document.querySelectorAll('#customerList > li');
console.log(`Direct child selector found ${directChildLis.length} li elements`);

// Log the difference
console.log('Difference:', descendantLis.length - directChildLis.length);


//Task 10
const eveOdd = document.querySelectorAll('#customerList li');
f = true;
eveOdd.forEach(ele=>{
    if(f){
        ele.style.backgroundColor = "lightblue"
        f = false;
    }else{
        ele.style.backgroundColor = "lightgray"
        f = true;
    }
})

//Task 11
const enquiryForm = document.getElementById("enquiryForm")
console.log(enquiryForm);
const formElements = enquiryForm.elements;
console.log('Input field names:');
for (let i = 0; i < formElements.length; i++) {
    if (formElements[i].tagName === 'INPUT') {
        console.log(`- ${formElements[i].name}`);
    }
}
// Disable the submit button
const submitBtn = enquiryForm.elements['submit'] || enquiryForm.querySelector('button[type="submit"]');
submitBtn.disabled = true;
console.log('Submit button disabled');


//Task 12
const livePolicies = document.getElementsByClassName('policy');
console.log('HTMLCollection (live):', livePolicies.length, 'policies');

// Select policies using querySelectorAll (static NodeList)
const staticPolicies = document.querySelectorAll('.policy');
console.log('NodeList (static):', staticPolicies.length, 'policies');

// Dynamically add a new policy to test difference
const policiesSection = document.querySelector('h2:nth-of-type(2)');
const newPolicy = document.createElement('p');
newPolicy.className = 'policy';
newPolicy.textContent = 'New Home Insurance';
policiesSection.parentNode.insertBefore(newPolicy, policiesSection.nextElementSibling.nextElementSibling.nextElementSibling);

console.log('After adding new policy:');
console.log('HTMLCollection updated:', livePolicies.length);     // Shows 4 (live)
console.log('NodeList unchanged:', staticPolicies.length);       // Still 3 (static)

//Task 13
const custList = document.querySelectorAll("#customerList li");
console.log(custList);
for(let i in custList){
    if(i==2){
        custList[i].classList.add("highlight");
    }
    if(i==1){
        custList[i].style.display = "None"
    }
}

//Task 14
document.querySelectorAll('#customerList li').forEach(customer => {
    customer.addEventListener('click', function() {
        const nearestUl = this.closest('ul');
        
        // Remove existing borders from all uls first
        document.querySelectorAll('ul').forEach(ul => {
            ul.style.border = '';
        });
        
        // Add border to clicked customer's ul parent
        nearestUl.style.border = '3px solid orange';
        
        console.log('Clicked customer:', this.textContent);
        console.log('Nearest ul parent:', nearestUl);
    });
});

//Task 15
// Select all policy p elements EXCEPT the first one
const policyPsExceptFirst = document.querySelectorAll('.policy:not(:first-child)');
console.log(`${policyPsExceptFirst.length} policy p elements (except first)`);

// Style them: italic + prefix "Hint: "
policyPsExceptFirst.forEach(p => {
    p.style.fontStyle = 'italic';
    p.textContent = 'Hint: ' + p.textContent;
});

