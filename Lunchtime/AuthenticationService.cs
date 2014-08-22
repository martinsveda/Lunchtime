using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;


namespace Lunchtime
{

    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }

            public string Username
            {
                get ;
                private set;
            }

            public string Email
            {
                get;
                private set;
            }

            public string HashedPassword
            {
                get;
                private set;
            }

            public string[] Roles
            {
                get ;
                private set;
            }
        }

        /* dodelat napojeni na DB */
        public User AuthenticateUser(string username, string password)
        {
            MySqlDB connection = new MySqlDB();

            if (connection.ValidateUser(username, password) != 1)
            {
                return new User(username, string.Empty, null);
            }
            else
            {
                return new User(string.Empty, string.Empty, null);    
            }
        }


        private string CalculateHash(string clearTextPassword, string salt)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }

    }
}



