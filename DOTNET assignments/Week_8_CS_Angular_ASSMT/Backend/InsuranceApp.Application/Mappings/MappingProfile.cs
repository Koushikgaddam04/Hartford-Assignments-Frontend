using AutoMapper;
using InsuranceApp.Domain.Entities;
using InsuranceApp.Application.DTOs;

namespace InsuranceApp.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Mapper
        CreateMap<User, UserDto>().ReverseMap();

        // Customer Mapper
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CreateCustomerDto, Customer>();

        // Policy Mapper
        CreateMap<Policy, PolicyDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => 
                src.Customer != null ? $"{src.Customer.FirstName} {src.Customer.LastName}" : string.Empty));
                
        CreateMap<CreatePolicyDto, Policy>();
    }
}
