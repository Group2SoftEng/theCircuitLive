using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuromori.DataStructure
{
    public class Admin
    {
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }

        public Admin(string username, string password)
        {
            AdminUsername = username;
            AdminPassword = password;
        }
    }
}
