using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExipryOn { get; set; }
    }
}