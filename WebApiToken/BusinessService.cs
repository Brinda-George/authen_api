using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiToken.Data;
using WebApiToken.Models;

namespace WebApiToken
{
    public class BusinessService : IServicecs
    {
        public User GenerateToken(string username, string password)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiryOn = DateTime.Now.AddMinutes(5);
            var tokendomain = new User
            {
                UserName = username,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExipryOn = expiryOn
            };
            UserDbContext dbContext = new UserDbContext();
            User user = dbContext.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                user.AuthToken = token;
                user.IssuedOn = issuedOn;
                user.ExipryOn = expiryOn;        
            }
            dbContext.SaveChanges();
            return tokendomain;
        }
        public bool ValidateToken(string tokenValue)
        {
            UserDbContext dbContext = new UserDbContext();
            User user = dbContext.Users.Where(u => u.AuthToken == tokenValue && u.ExipryOn>DateTime.Now).FirstOrDefault();
            if (user != null)
            {
                user.ExipryOn = DateTime.Now.AddMinutes(5);
                return true;
            }
            return false;
        }
    }
}