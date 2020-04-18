using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Models
{
    public class UserModel : IUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }

        public string BasicOverview
        {
            get
            {
                return $"{ Username} | {Role}";
            }
        }
    }
}
