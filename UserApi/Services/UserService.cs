using UserApi.Interfaces;
using UserApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _repository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repository.DeleteUserAsync(id);
        }
    }
}
