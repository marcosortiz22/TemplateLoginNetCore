using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using IDataAccess;

namespace Services
{
    public class UserService
    {
        readonly IBaseRepository<User> _userRepository;
        readonly IBaseRepository<RolAppUser> _rolAppUserRepository;

        public UserService(IBaseRepository<User> userRepository, IBaseRepository<RolAppUser> rolAppUserRepository)
        {
 
            _userRepository = userRepository;
            _rolAppUserRepository = rolAppUserRepository;
        }

        public List<User> GetUsersAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int idUser)
        {
            return _userRepository.Get(idUser);
        }

        public List<User> GetUsersById(List<int> idsUser)
        {
            return _userRepository.FindAll(x => idsUser.Contains(x.Id));
        }


        public User GetUserByCode(string codeUser)
        {
            return _userRepository.Find(x => x.CodeUser == codeUser);
        }

        public User InsertUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            return _userRepository.Add(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }
        public User UpdateUser(User user, RolAppUser rolAppUser)
        {

            var rolAppUserActual = _rolAppUserRepository.FindAll(x => x.IdUser == user.Id).FirstOrDefault();
            if (rolAppUserActual != null)
            {
                _rolAppUserRepository.Delete(rolAppUserActual);
            }
            else
            {
                rolAppUserActual = new RolAppUser();
                rolAppUserActual.IdUser = rolAppUser.IdUser;
            }

            rolAppUserActual.IdRolApp = rolAppUser.IdRolApp;
            rolAppUserActual = _rolAppUserRepository.Add(rolAppUserActual);
            user.RolAppUser = new List<RolAppUser>() { rolAppUserActual };
            user.CreatedDate = DateTime.Now;
            return _userRepository.Update(user, user.Id);
        }
    }
}
