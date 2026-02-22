using InsuranceApp.Domain.Entities;
using System.Threading.Tasks;

namespace InsuranceApp.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
}
