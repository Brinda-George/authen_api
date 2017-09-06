using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiToken.Models;

namespace WebApiToken.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("UserDbContext")
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}