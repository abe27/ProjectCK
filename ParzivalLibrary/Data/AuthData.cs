using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class Profile
    { 
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime? email_verified_at { get; set; }
        public bool is_activated { get; set; }
        public DateTime? last_login { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class UserListData
    {
        public bool success { get; set; }
        public List<Profile> profile { get; set; }
        public string token { get; set; }
    }

    public class AuthData
    {
        public bool success { get; set; }
        public Profile profile { get; set; }
        public string token { get; set; }
    }
}
