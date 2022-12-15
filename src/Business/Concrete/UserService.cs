using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResponse CreateUser(User user) //This can use identity registration in the future
        {
            _userRepository.Add(user);          //TODO: Validation for username, email, password before creating user
            return new SuccessResponse();
        }

        public IResponse DeleteUser(User user)      //TODO: Maybe validate that only admins and users themselves can delete users.
        {
            _userRepository.Delete(user);
            return new SuccessResponse();
        }

        public IDataResponse<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return new SuccessDataResponse<List<User>>(users);
        }

        public IDataResponse<User> GetUserById(int id) //TODO: Maybe shouldn't be able to see the password. Use DTO?
        {
            var user = _userRepository.Get(u => u.Id == id);
            return new SuccessDataResponse<User>(user);
        }

        public IResponse UpdateUser(User user)
        {
            _userRepository.Update(user);
            return new SuccessResponse();
        }
    }
}
