using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Controllers;
using VkNet.Enums.Filters;
using System.Web.Script.Serialization;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            UserData Model = new UserData();


            string code = Request["code"];

        

            if (code != null)
            {

               

                string URI = String.Format("https://oauth.vk.com/access_token?client_id=5760826&client_secret=R8DEEzwLmgziPepArWVy&redirect_uri=http://localhost:1501/Home/About&code=" + code);
               

                var response = Load(URI);
                var accessToken = DeserializeJson<AccessToken>(response);


                URI = String.Format(
                        "https://api.vk.com/method/users.get?uids={0}&fields=uid,first_name,last_name,photo_50",
                        accessToken.user_id);

                response = Load(URI);
                var usersData = DeserializeJson<UsersData>(response);
                Model = usersData.response.First();
              

            }

            return View(Model);
           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static string Load(string address)
        {
            var request = WebRequest.Create(address) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T DeserializeJson<T>(string input)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }
    }
}