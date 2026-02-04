using System;
using System.Collections.Generic;
using InsuranceLibrary.Models;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private const int MaxPolicies = 10;

        private readonly InsurancePolicy[] _policies;
        private int _count;

        public PolicyService()
        {
            _policies = new InsurancePolicy[MaxPolicies];
            _count = 0;

            // Duplicate data on startup
            AddPolicy(new InsurancePolicy(1, "Kishor", "Health", 15000m, 10, true));
            AddPolicy(new InsurancePolicy(2, "Amit", "Life", 25000m, 15, true));
            AddPolicy(new InsurancePolicy(3, "John", "Vehicle", 8000m, 5, true));
        }

        // Add
        public bool AddPolicy(InsurancePolicy policy)
        {
            // Prevent duplicate PolicyId
            for (int i = 0; i < _count; i++)
            {
                if (_policies[i].PolicyId == policy.PolicyId)
                {
                    return false; // duplicate id
                }
            }

            // Check capacity
            if (_count >= MaxPolicies)
            {
                return false;
            }

            _policies[_count] = policy;
            _count++;
            return true;
        }

        // View All
        public List<InsurancePolicy> GetAllPolicies()
        {
            var list = new List<InsurancePolicy>();
            for (int i = 0; i < _count; i++)
            {
                list.Add(_policies[i]);
            }
            return list;
        }

        // View by ID
        public InsurancePolicy GetPolicyById(int id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_policies[i].PolicyId == id)
                {
                    return _policies[i];
                }
            }
            return null;
        }

        // Edit
        public bool UpdatePolicy(int id, decimal newPremium, int newTerm)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null)
            {
                return false;
            }

            policy.PremiumAmount = newPremium;
            policy.PolicyTerm = newTerm;
            return true;
        }

        // Delete (Deactivate)
        public bool DeletePolicy(int id)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null)
            {
                return false;
            }

            policy.IsActive = false;
            return true;
        }
    }
}
