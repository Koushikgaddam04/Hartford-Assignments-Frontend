using AutoMapper;
using Day_35_C__InsurancePoliciesFullstack.DTOs;
using Day_35_C__InsurancePoliciesFullstack.Models;

namespace Day_35_C__InsurancePoliciesFullstack.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map CustomerCreateDTO to Customer entity
            CreateMap<CustomerCreateDTO, Customer>();

            // Map PolicyCreateDTO to Policy entity
            CreateMap<PolicyCreateDTO, Policy>();

            // Map Entity to Response DTO
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Customer, CustomerSummaryDTO>();
            CreateMap<Policy, PolicyDTO>();
            CreateMap<Policy, PolicySummaryDTO>();
        }
    }
}
