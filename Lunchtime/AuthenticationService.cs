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

        /* dodelat napojeni na DB */
        public User AuthenticateUser(string username, string password)
        {
            MySqlDB connection = new MySqlDB("SVEDAMARTIN", "lunchtime", "martin", "martin");
            return connection.ValidateUser(username, password);
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



