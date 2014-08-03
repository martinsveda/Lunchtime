using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Lunchtime
{
    public class User
    {
        // username,email,access_rights,name, surname, passwd
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private int accessRights;
        public int AccessRights
        {
            get { return accessRights; }
            set { accessRights = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string surname_name;
        public string Surname_Name
        {
            get { return surname_name; }
            set { surname_name = value; }
        }

        public User(string userName, int accessRights, string name, string surname, string password) 
        {
            UserName = userName;
            AccessRights = accessRights;
            Name = name;
            Surname = surname;
            Password = password;
            Surname_Name = surname + " " + name;
        }

    }
}
