using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NenoSlack.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NenoSlack.Controllers
{
    public class LoginController : Controller
    {
        const int SessionUserId = 0;
        private readonly BloggingContext _context;

        public LoginController(BloggingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: Departments/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult checkUser(string UserName, string Password)
        //{
        //    var user1 = _context.UserDetail.Where(s => s.UserName == UserName && s.Password == Password).FirstOrDefault();
        //    var user = _context.UserDetail.Where(s => s.UserName == UserName && s.Password == Password).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return RedirectToAction("Index", "Chat");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> checkUser([Bind("UserName,Password")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserDetail.Where(s => s.UserName == userDetail.UserName && s.Password == userDetail.Password).ToList().FirstOrDefault();
                if (user != null)
                {
                    //SessionValue.onlineUsers.Add(new OnlineUser { UserId = user.UserId, connectionIds = new List<string>(), Img = user.Img });
                    
                    OnlineUser ouser = new OnlineUser();
                    ouser.UserId = user.UserId;
                    ouser.UserName = user.UserName;
                    ouser.Img = user.Img;
                    ouser.connectionIds = new List<string>();
                    HttpContext.Session.SetString("UseDetail", JsonConvert.SerializeObject(ouser));
                    int UserId = user.UserId;
                    HttpContext.Session.SetInt32("UserId", UserId);
                    return RedirectToAction("Index", "Chat");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}