using System;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }      // Health / Life / Vehicle
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }         // years
        public bool IsActive { get; set; }

        public InsurancePolicy()
        {
        }

        public InsurancePolicy(int policyId,
                               string policyHolderName,
                               string policyType,
                               decimal premiumAmount,
                               int policyTerm,
                               bool isActive)
        {
            PolicyId = policyId;
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            PolicyTerm = policyTerm;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"Id: {PolicyId}, " +
                   $"Holder: {PolicyHolderName}, " +
                   $"Type: {PolicyType}, " +
                   $"Premium: {PremiumAmount}, " +
                   $"Term: {PolicyTerm} years, " +
                   $"Active: {IsActive}";
        }
    }
}
