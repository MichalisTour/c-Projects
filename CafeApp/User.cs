using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        
        public User()
        {
            this.Name = "user1";
            this.Password = "user1";
            
        }
        public bool CheckCredentials(string username, string password)
        {
            return (this.Name.Equals(username) && this.Password.Equals(password));
            
        }
    }
}
