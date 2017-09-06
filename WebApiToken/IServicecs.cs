using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToken.Models;

namespace WebApiToken
{
    interface IServicecs
    {
        User GenerateToken(string username, string password);
        bool ValidateToken(string tokenValue);
    }
}
