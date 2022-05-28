using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleJSLessons.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SimpleJSLessons.data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace SimpleJSLessons.Controllers
{
    public class HomeController : Controller
    {
        private SimpleJSLessonsDbContext context;

        public HomeController(SimpleJSLessonsDbContext context)
        {
            this.context = context;
        }
        public ApiUser getUser(string cookie)
        {
            UserModel thisUser = new UserModel();
            string cookieValueFromReq = Request.Cookies["sessionid"];
            string accountHash = "";
            try
            {
                accountHash = context.SessionModel.FromSqlRaw(@$"use SimpleJSLessonsAPIData 
                                                                select * from SessionModel 
                                                                where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
            }
            catch
            {
                return null;
            }
            if (accountHash != null)
            {
                ApiUser user = context.ApiUser.FromSqlRaw($"use SimpleJSLessonsAPIData select * from apiUser where accountHash = '{accountHash}'").ToList()[0];
                return user;
            }
            return null;
        }

        public IActionResult Index()
        {
            string cookieValueFromReq = Request.Cookies["sessionid"];
            if(cookieValueFromReq != null && getUser(cookieValueFromReq) != null)
            {
                ViewBag.firstName = getUser(cookieValueFromReq).ApiUserInformation.FirstName;
            }
            return View();
        }
        public IActionResult myAccount()
        { 
            string cookieValueFromReq = Request.Cookies["sessionid"];

            if(cookieValueFromReq != null && getUser(cookieValueFromReq) != null)
            {
                ViewBag.firstName = getUser(cookieValueFromReq).ApiUserInformation.FirstName;
                string accountHash = context.SessionModel.FromSqlRaw($"use SimpleJSLessonsAPIData select * from SessionModel where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                ApiUser currentUser = context.ApiUser.FirstOrDefault((user) => user.AccountHash == accountHash);
                return View(currentUser);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult createAccount()
        {
            string cookieValueFromReq = Request.Cookies["sessionid"];
            if(cookieValueFromReq != null && getUser(cookieValueFromReq) != null)
            {
                return RedirectToAction("myAccount", "Home");
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

            context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into apiUser(accountHash, username, dateCreated) values({accounthash}, {newApiUser.Username}, {DateTime.Now})");
            context.Database.ExecuteSqlCommand($"use SimpleJSLessonsAPIData insert into apiUserInformation(accountHash, firstName, lastName, datemodified) values ({accounthash}, {newApiUserInformation.FirstName}, {newApiUserInformation.LastName}, {DateTime.Now})");

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
                SetCookie("sessionid", newSessionHash, 15);
                return Json(1);
            }
            else
            {
                return Json(0); //zero for not found
            }
        }
        [HttpGet]
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
        public IActionResult postData([FromBody] DataModel data) //returns: 0 - account found, data written, no errors, 1 - saved as anon, no errors*, 2 - data saved, account error, cookie read but no user found, saved data as anon 3/-1 - nothing saved
        {
            if(data.imageData == null)
            {
                data.imageData = "null";
            }
            if(data.type == "demo" || data.type == "lessonAnswers" || data.type == "lesson")
            {
                DataModel newData = data;
                newData.hashcode = ComputeSha256Hash(newData.data).Substring(0, 6);
                string cookieValueFromReq = Request.Cookies["sessionid"];
                string accountHash = "";
                try
                {
                    accountHash = context.SessionModel.FromSqlRaw(@$"use SimpleJSLessonsAPIData 
                                                                select * from SessionModel 
                                                                where sessionID = '{cookieValueFromReq}'").ToList()[0].AccountHash;
                    ApiUser thisUser = context.ApiUser.FirstOrDefault((user) => user.AccountHash == accountHash);
                    if (thisUser != null)
                    {
                        newData.hashcode = ComputeSha256Hash(newData.data + thisUser.Username).Substring(0, 6);
                        try
                        {
#pragma warning disable CS0618 // Type or member is obsolete
                            context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into DataTable(dataHash, data, title, dateCreated) 
                                                            values({newData.hashcode},{newData.data},{newData.title}, {DateTime.Now})");
#pragma warning restore CS0618 // Type or member is obsolete
                        }
                        catch
                        {
                            System.Console.WriteLine("Data Alredy Exists!");
                        }
                        context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                        insert into Authors(dataHash, username, dateAuthored) 
                                                        values ({newData.hashcode},{thisUser.Username},{DateTime.Now})");
                        try
                        {
                            context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into dataDataTable(imageData, dataHash, uploadedBy, title, uploadDate, isPublic) 
                                                            values ({newData.imageData},{newData.hashcode},{thisUser.Username}, {newData.title}, {DateTime.Now}, 0)");
                        }
                        catch
                        {
                            System.Console.WriteLine("error writing image data...");
                        }
                        if (newData.type == "demo")
                        {
                            context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into UserSavedDemos(accountHash, demoHash, demoTitle) 
                                                            values ({thisUser.AccountHash},{newData.hashcode},{newData.title})");
                            return Json(0);
                        }
                        else if (newData.type == "lessonAnswers")
                        {
                            context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                        insert into UserSavedLessons(accountHash, lessonHash, lessonTitle) 
                                                        values ({thisUser.AccountHash},{newData.hashcode},{newData.title})");
                            return Json(0);
                        }
                    }
                    else
                    {
                        try
                        {
                            context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into DataTable(dataHash, data, title, dateCreated) 
                                                            values({newData.hashcode},{newData.data},{newData.title}, {DateTime.Now})");
                            try
                            {
                                context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                                insert into dataDataTable(imageData, dataHash, uploadedBy, title, uploadDate, isPublic) 
                                                                values ({newData.imageData},{newData.hashcode}, 'anonymous', {newData.title}, {DateTime.Now}, 1)");
                            }
                            catch
                            {
                                System.Console.WriteLine("error writing image data...");
                            }
                            return Json(2);
                        }
                        catch
                        {
                            return Json(3);
                        }

                    }
                }
                catch
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into DataTable(dataHash, data, title, dateCreated) 
                                                            values({newData.hashcode},{newData.data},{newData.title}, {DateTime.Now})");
                        context.Database.ExecuteSqlCommand(@$"use SimpleJSLessonsAPIData 
                                                            insert into dataDataTable(imageData, dataHash, uploadedBy, title, uploadDate, isPublic) 
                                                            values ({newData.imageData},{newData.hashcode}, 'anonymous', {newData.title}, {DateTime.Now}, 1)");
                        return Json(1);
                    }
                    catch
                    {
                        return Json(3);
                    }
                }
            }
            return Json(-1);
        }
        [HttpPost]
        public IActionResult requestData([FromBody] DataRequest dataHash)
        {
            DataTable data = null;
            data = context.DataTable.FirstOrDefault(data => data.DataHash == dataHash.dataHash);
            if(data == null)
            {
                System.Console.WriteLine("Invalid data");
                return Json(1);
            }
            return Json(data.Data);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult search(string searchTerm)
        {
            string cookieValueFromReq = Request.Cookies["sessionid"];
            ViewBag.Search = searchTerm;

            if (cookieValueFromReq != null && getUser(cookieValueFromReq) != null)
            {
                ViewBag.firstName = getUser(cookieValueFromReq).ApiUserInformation.FirstName;
            }
            string[] searchTerms = null;
            if (searchTerm != null)
            {
                
                List<SearchResultsModel> searchResults = new List<SearchResultsModel>();
                searchTerms = searchTerm.Split(" ");
                searchTerms = searchTerms.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();
                
                foreach(DataDataTable data in context.DataDataTable)
                {
                    if(data.IsPublic == 1)
                    {
                        double weight = 0;
                        double multi = 1;
                        foreach (string substring in searchTerms)
                        {
                            multi = 1;
                            switch (substring)
                            {
                                case "the": multi = .5; break;
                                case "of": multi = .7; break;
                                case "is": multi = .5; break;
                            }
                            string newRegex = "(" + substring.Replace("\"", "") + ")";
                            if (Regex.Matches($"{data.DataHash}", "\\b(" + substring.Replace("\"", "") + ")\\b", RegexOptions.IgnoreCase).Count > 0)
                            {
                                weight = (weight + 100) * multi;
                            }
                            if (Regex.Matches(data.Title, newRegex, RegexOptions.IgnoreCase).Count > 0)
                            {
                                weight = (weight + 15) * multi;
                            }
                            if (Regex.Matches(data.UploadedBy, newRegex, RegexOptions.IgnoreCase).Count > 0)
                            {
                                weight = (weight + 50) * multi;
                            }
                            if (weight > 0)
                            {
                                searchResults.Add(new SearchResultsModel(data, weight));
                            }
                        }

                    }
                }
                if(searchResults.Count > 0)
                {
                    List<DataDataTable> data = new List<DataDataTable>();
                    searchResults.Sort((x, y) => y.weight.CompareTo(x.weight));
                    foreach(SearchResultsModel item in searchResults)
                    {
                        data.Add(item.item);
                    }
                    return View(data);
                }
            }
        return View(context.DataDataTable.FromSqlRaw(@$"use SimpleJSLessonsAPIData 
                                                    select top(10) * from dataDataTable
                                                    where isPublic = 1
                                                    order by id desc").ToList());
        }
        [HttpGet]
        public IActionResult user(string username)
        {
            string cookieValueFromReq = Request.Cookies["sessionid"];

            if (cookieValueFromReq != null && getUser(cookieValueFromReq) != null)
            {
                ViewBag.firstName = getUser(cookieValueFromReq).ApiUserInformation.FirstName;
            }
            if (username == null)
            {
                return RedirectToAction("index", "home");
            }
            PublicUserInformationModel requestedUser = new PublicUserInformationModel(context, username);
            return View(requestedUser);
        }
        [HttpPost]
        public IActionResult updateInformation(string[] changeData) //[0] = 1: change privacy 2: update title
                                                                    //[1] = hash of demo
        {                                                           //[2] = data
            string cookieValueFromReq = Request.Cookies["sessionid"];
            ApiUser verifiedUser = getUser(cookieValueFromReq);
            if(verifiedUser != null)
            {
                UserSavedDemos demo = verifiedUser.UserSavedDemos.FirstOrDefault((demo) => demo.DemoHash == changeData[1]);
                if(demo != null)
                {
                    if (changeData[0] == "1")
                    {
                        int publicity = 0; //defaults to private if try catch fails for some reson
                        try
                        {
                            publicity = int.Parse(changeData[2]);
                        }
                        catch
                        {
                            return Json(-1);
                        }
                        context.Database.ExecuteSqlCommand($@"use SimpleJSLessonsAPIData
                                                              update dataDataTable
                                                              set isPublic = {publicity}
                                                              where dataHash = '{changeData[1]}'
                                                              and uploadedBy = '{verifiedUser.Username}'");
                        return Json(1);
                    }
                }
            } 
           return Json(-1);
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
