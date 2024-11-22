
using ECOSAGE.DATA.models;
using ECOSAGE.REPOSITORY.user;

namespace ECOSAGE.SERVICE.user
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            if (await EmailExists(user.Email))
                throw new ArgumentException("Email já está em uso.");

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.UserId);

            if (existingUser == null)
                throw new KeyNotFoundException("User NOT FOUND.");

            if (user.Email != existingUser.Email && await EmailExists(user.Email))
                throw new ArgumentException("Email is alredy used.");

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        private async Task<bool> EmailExists(string email)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Any(u => u.Email == email);
        }
    }
}
