using Entities;
using System.Collections.Generic;

namespace IServices
{
    public interface IUserService
    {
        List<User> GetUsersAll();
        User GetUserById(int idUser);
        List<User> GetUsersById(List<int> idsUser);
        User GetUserByCode(string codeUser);
        User InsertUser(User user);
        void DeleteUser(User user);
        User UpdateUser(User user, RolAppUser rolAppUser);
    }
}
