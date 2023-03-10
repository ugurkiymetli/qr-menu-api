using QrMenu.Data.Repositories;
using QrMenu.Models;
using QrMenu.Utils;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels;

namespace QrMenu.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var userList = await userRepository.GetAllUsers();

            var userListMapped = userList.Map<List<User>, List<UserViewModel>>();

            return userListMapped;
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            return (await userRepository.GetUserById(id)).Map<User, UserViewModel>();
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            return (await userRepository.GetUserByEmail(email)).Map<User, UserViewModel>();

        }
        public async Task<bool> AddUser(UserInsertModel insertModel)
        {
            var user = insertModel.Map<UserInsertModel,User>();

            user.Password = passwordHasher.HashPassword(user.Password);

            user.CreateDate = System.DateTime.Now.TrimMilliseconds();

            return await userRepository.AddUser(user);
        }

        public async Task<bool> UpdateUser(string id, User user)
        {
            return await userRepository.UpdateUser(id, user);
        }

        public async Task<bool> RemoveUser(string id)
        {
            return await userRepository.RemoveUser(id);
        }

    }
}

