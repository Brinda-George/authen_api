using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiToken.Data;
using WebApiToken.Filters;
using WebApiToken.Models;

namespace WebApiToken.Controllers
{
    public class UserController : ApiController
    {

        BusinessService _BusinessService = new BusinessService();
        private HttpResponseMessage GetAuthToken(string username, string password)
        {
            var token = _BusinessService.GenerateToken(username, password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", token.ExipryOn.ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
        [HttpGet]
        [AuthorizationRequired]
        public HttpResponseMessage GetUserToken(string username, string password)
        {
            return GetAuthToken(username, password);
        }
        [AuthorizationRequired]
        [HttpPost]
        public void PostToken(string Token)
        {
            
        }

        //public IHttpActionResult PostNewUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid user.");

        //    using (var context = new UserDbContext())
        //    {
        //        context.Users.Add(new User()
        //        {
        //            UserId = user.UserId,
        //            UserName = user.UserName,
        //            Password = user.Password
        //        });
        //        context.SaveChanges();

        //    }
        //    return Ok("New User Added");
        //}

        ////localhost:52971/api/user/id
        //[AuthorizationRequired]
        //public IHttpActionResult GetUserById(int id)
        //{
        //    User user = new User();
        //    using (var context = new UserDbContext())
        //    {
        //        user = context.Users.Where(s => s.UserId == id).FirstOrDefault();
        //    }
        //    if (user == null)
        //        return Ok("No user with given ID found");
        //    else
        //        return Ok(user);
        //}
        //public IHttpActionResult Put(User user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid user");
        //    using (var context = new UserDbContext())
        //    {
        //        var existingUser = context.Users.Where(s => s.UserId== user.UserId).FirstOrDefault();
        //        if (existingUser == null)
        //            return NotFound();
        //        else
        //        {
        //            existingUser.UserName = user.UserName;
        //            existingUser.Password = user.Password;
        //            context.SaveChanges();
        //        }
        //        return Ok();
        //    }
        //}

        //public IHttpActionResult Delete(int id)
        //{
        //    User user = new User();
        //    if (id <= 0)
        //        return BadRequest("Not a valid user id");
        //    using (var context = new UserDbContext())
        //    {
        //        user = context.Users.Where(s => s.UserId == id).FirstOrDefault();
        //        if (user == null)
        //            return NotFound();
        //        else
        //        {
        //            context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
        //            context.SaveChanges();
        //        }
        //    }
        //    return Ok();
        //}
    }
}