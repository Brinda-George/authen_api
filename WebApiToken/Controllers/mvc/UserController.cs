using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiToken.Filters;
using WebApiToken.Models;

namespace WebApiToken.Controllers.mvc
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<User> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<User>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    users = Enumerable.Empty<User>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("user", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(user);
        }

        public ActionResult Details(int id)
        {
            User user = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("user", user);
                putTask.Wait();


                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64787/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("student/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}