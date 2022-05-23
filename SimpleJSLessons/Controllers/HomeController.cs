﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleJSLessons.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SimpleJSLessons.Models;
using SimpleJSLessons.data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SimpleJSLessons.Controllers
{
    public class HomeController : Controller
    {
        private SimpleJSLessonsDbContext context;

        public HomeController(SimpleJSLessonsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            UserModel thisUser = new UserModel();
            string cookieValueFromReq = Request.Cookies["sessionid"];
            if (cookieValueFromReq != null)
            {
                string accountHash = "";
                try
                {
                    accountHash = context.SessionModel.FromSqlRaw($"use SimpleJSLessonsAPIData select * from SessionModel where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                }
                catch
                {
                    return View();
                }
                if(accountHash != null)
                {
                    string firstname = context.ApiUserInformation.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUserInformation where accountHash = '{accountHash}'").ToList()[0].FirstName;
                    ViewBag.firstName = firstname;
                }
            }
            return View();
        }
        public IActionResult myAccount()
        { 
            string cookieValueFromReq = Request.Cookies["sessionid"];
            if (cookieValueFromReq != null)
            {
                string accountHash = context.SessionModel.FromSqlRaw($"use SimpleJSLessonsAPIData select * from SessionModel where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                if (accountHash != null)
                {
                    string firstname = context.ApiUserInformation.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUserInformation where accountHash = '{accountHash}'").ToList()[0].FirstName;
                    ViewBag.firstName = firstname;
                    ApiUser currentUser = context.ApiUser.FirstOrDefault((user) => user.AccountHash == accountHash);
                    return View(currentUser);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpGet]
        public IActionResult createAccount(String error)
        {
            UserModel thisUser = new UserModel();
            string cookieValueFromReq = Request.Cookies["sessionid"];
            if (cookieValueFromReq != null)
            {
                string accountHash = "";
                try
                {
                    accountHash = context.SessionModel.FromSqlRaw($"use SimpleJSLessonsAPIData select * from SessionModel where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                }
                catch
                {
                    return View();
                }
                if (accountHash != null)
                {
                    return RedirectToAction("myAccount", "Home");
                }
            }

            return View();
        }
        [HttpPost]
        public IActionResult createAccount(UserModel newUser)
        {
            String accounthash = ComputeSha256Hash(newUser.password + newUser.username);
            var apiUserList = context.ApiUser.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUser where username = '{newUser.username}'").ToList();
            foreach (ApiUser user in apiUserList)
            {
                if(user.Username == newUser.username)
                {
                    return View("createAccount");
                }
            }
            ApiUser newApiUser = new ApiUser();
            ApiUserInformation newApiUserInformation = new ApiUserInformation();
            
            newApiUser.Username = newUser.username;
            newApiUser.AccountHash = accounthash;

            newApiUserInformation.AccountHash = accounthash;
            newApiUserInformation.FirstName = newUser.firstName;
            newApiUserInformation.LastName = newUser.lastName;

            context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into apiUser(accountHash, username) values({accounthash}, {newApiUser.Username})");
            context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into apiUserInformation(accountHash, firstName, lastName) values ({accounthash}, {newApiUserInformation.FirstName}, {newApiUserInformation.LastName})");

            var rand = new Random();
            string newSessionHash = ComputeSha256Hash(newApiUser.Username + newApiUser.AccountHash + rand.Next() + DateTime.Now);
            context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into SessionModel(sessionID, accountHash) values({newSessionHash}, {newApiUser.AccountHash})");
            SetCookie("sessionid", newSessionHash, 9999);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login([FromBody] loginControl newLogin)
        {
            string accountHash = ComputeSha256Hash(newLogin.password + newLogin.username);
            var user = context.ApiUser.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUser where username='{newLogin.username}' and accountHash='{accountHash}'").ToList();
            if(user.Count > 0)//basically just checking for not null because otherwise checking for null is pita in c#
            {
                var rand = new Random();
                string newSessionHash = ComputeSha256Hash(user[0].Username + user[0].AccountHash + rand.Next() + DateTime.Now);
                context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into SessionModel(sessionID, accountHash) values({newSessionHash}, {accountHash})");
                SetCookie("sessionid", newSessionHash, 9999);
                return Json(1);
            }
            else
            {
                return Json(0); //zero for not found
            }
        }
        public IActionResult usernameCheck(String username)
        {
            var user = context.ApiUser.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUser where username = '{username}'").ToList();
            if(user.Count > 0)
            { 
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        [HttpPost]
        public IActionResult postData([FromBody] DataModel data)
        {
            DataModel newData = data;

            string cookieValueFromReq = Request.Cookies["sessionid"];
            if (cookieValueFromReq != null)
            {
                string accountHash = "";
                try
                {
                    accountHash = context.SessionModel.FromSqlRaw($"use SimpleJSLessonsAPIData select * from SessionModel where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                }
                catch
                {
                    return Json(-1);
                }
                if (accountHash != null)
                {
                    if (newData.type == "demo")
                    {
                        context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into UserSavedDemos(accountHash, demoHash, demoTitle) values ({accountHash},{newData.hashcode},{newData.title})");
                        return Json(0);
                    }
                    else if (newData.type == "lessonAnswers")
                    {
                        context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into UserSavedLessons(accountHash, lessonHash, lessonTitle) values ({accountHash},{newData.hashcode},{newData.title})");
                        return Json(0);
                    }
                    else
                    {
                        return Json(1);
                    }
                }
            }
            else
            {
                return Json(1);
            }
            return Json(-1);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //pulled this functon from a tutorial somewhere. no need to write myself
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        //got this chunk of code somewhere online after a google search for "how to set a cookie in asp.net core 3.1"
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
    }
}