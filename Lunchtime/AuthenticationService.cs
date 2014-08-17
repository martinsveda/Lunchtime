using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Lunchtime
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }


    public class User
    {
        public User(string username, string email, string[] roles)
        {
            Username = username;
            Email = email;
            Roles = roles;
        }

        public string Username
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string[] Roles
        {
            get;
            set;
        }
    }


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

            public User AuthenticateUser(string username, string password)
            {
                return new User(string.Empty , string.Empty, null);
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
}
