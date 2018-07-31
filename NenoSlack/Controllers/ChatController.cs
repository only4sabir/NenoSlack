using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NenoSlack.Models;

namespace NenoSlack.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            var s = JsonConvert.DeserializeObject<OnlineUser>(HttpContext.Session.GetString("UseDetail"));
            //var UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UseDetail = s;
            return View();
        }
    }
}