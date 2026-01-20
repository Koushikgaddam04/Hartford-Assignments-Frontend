
// Variables
let CompanyName = "Hartford Insurance";
console.log(CompanyName);
var policyNumber = 123456789;
console.log(policyNumber);
let isActive = true;
console.log(isActive);
let policyTypes = ["Auto", "Home", "Life", "Health"];
console.log(policyTypes);
let policyDetails = {
    policyHolder: "John Doe",
    coverageAmount: 250000,
    startDate: "2023-01-01",
    endDate: "2024-01-01"
};
console.log(policyDetails);
a = function() {
    return "Function Executed";
}
console.log(a());


//Checking Data Types
console.log("");
console.log(typeof(CompanyName));
console.log(typeof(policyNumber));
console.log(typeof(isActive));
console.log(typeof(policyTypes));
console.log(typeof(policyDetails));
console.log(typeof(policyDetails.startDate));
console.log(typeof(a));



//Calculating Total Premium with GST
console.log("");
console.log("Calculating Total Premium");
let basePremium = 6000;
let GST=18;
let totalPremium = basePremium + (basePremium * GST / 100);
console.log("Total Premium: " + totalPremium);


//Policy Eligibility Check
console.log("");
console.log("Checking Eligibility Status");
function checkEligibility(customerAge) {
    if (customerAge >= 18) {
        return "Eligible for policy.";
    } else {
        return "Not eligible for policy.";
    }
}

console.log(checkEligibility(17));
console.log(checkEligibility(25));


//Policy Status Message using Template literals
console.log("");
console.log("Generating Policy Status Message using Template Literals");
let CustomerName = "Koushik";
var policyNumber = 987654321;
let PolicyStatus = "active";
console.log(`Policy ${policyNumber} for ${CustomerName} is ${PolicyStatus}.`);



//Discount on Premium
console.log("");
console.log("Discount on Premium");
var Premium = 12000;
var discount = 15;
console.log(`Final Premium = ${Premium*(100-discount)/100}`);

//Fixed Coverage Value
console.log("");
const maxInsuranceCoverage = 500000;
console.log(`Max Insurance Coverage: ${maxInsuranceCoverage}`);

// maxInsuranceCoverage = 600000;
// console.log(`Max Insurance Coverage: ${maxInsuranceCoverage}`);
//Uncaught TypeError: Assignment to constant variable.


//Yearly Premium Calculator
console.log("");
console.log("Yearly Premium Calculator using arrow function");

const calculateYearlyPremium = (monthlyPremium) => monthlyPremium * 12;
console.log(`Yearly Premium for monthly premium of 1500: ${calculateYearlyPremium(1500)}`);


// Policy Validation using logical operators
console.log("");
console.log("Policy Validation using Logical Operators");
var policyActive = true;
var paymentUpToDate = false;
let isPolicyValid = (policyActive,paymentUpToDate) => policyActive&&paymentUpToDate;
console.log(`Policy is ${isPolicyValid(true, true)?"Valid":"Invalid"}`);
console.log(`Policy is ${isPolicyValid(true, false)?"Valid":"Invalid"}`);

//Claim Approval Check using conditional logic and template literals
console.log("");
console.log("Claim Approval Check using Conditional Logic and Template Literals");
function checkClaimApproval(claimAmount, coverageLimit) {
    if (claimAmount <= coverageLimit) {
        return `Claim of amount ${claimAmount} is Approved.`;
    } else {
        return `Claim of amount ${claimAmount} is Rejected.`;
    }
}

console.log(checkClaimApproval(200000, 250000));
console.log(checkClaimApproval(300000, 250000));


//Claim bonus calculator
console.log("");
console.log("Claim Bonus Calculator using arrow function");
//  If customer has no previous claims, give 5% bonus
const claimBonus = (hasPreviousClaims, claimAmount) => {
    if (!hasPreviousClaims) {
        return claimAmount * 0.05;
    } else {
        return 0;
    }
};

console.log(`Claim Bonus for no previous claims on 10000: ${claimBonus(false, 10000)}`);
console.log(`Claim Bonus for previous claims on 10000: ${claimBonus(true, 10000)}`);

 console.log(2+"2");