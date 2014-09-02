using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Lunchtime
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }


    public class User
    {
        #region Properties
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string[] Roles { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string HashedPassword { get; private set; }
        #endregion

        #region Methods
        public User(string username, string email, string[] roles, string name, string surname, string hashedPassword)
        {
            Username = username;
            Email = email;
            Roles = roles;
            Name = name;
            Surname = surname;
            HashedPassword = hashedPassword;
        }
        #endregion
    }
}

