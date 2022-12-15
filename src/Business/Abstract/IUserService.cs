using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResponse CreateUser(User user);
        IResponse DeleteUser(User user);
        IResponse UpdateUser(User user);
        IDataResponse<User> GetUserById(int id);
        IDataResponse<List<User>> GetAllUsers();
    }
}
