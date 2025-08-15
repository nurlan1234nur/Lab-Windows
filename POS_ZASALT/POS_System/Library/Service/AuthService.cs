using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;    
using Library.Repository;
using Library.model;

namespace Library.Service
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        public AuthService() {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Нэвтрэх нэр, нууц үгийг шалгах
        /// </summary>
        public bool checkUsernamePassword(String username, String pass)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                return pass == user.Password;
            }
        }

        /// <summary>
        /// Хэрэглэгчийн эрхийг нэвтрэх нэрээр хайх
        /// </summary>
        public String getUserRoleByUsername(String username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user.Role;
            }
        }   
        //public bool checkUsernamePass(String username, String password)
        //{
        //    var userUserName = _userRepository.GetUserByUsername(username);
        //    var userPass = _userRepository.GetUserPasswordByUsername(username);
        //    if (_userRepository.GetUserByUsername(username) == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return password == userPass;
        //    }
        //}

    }
}   
