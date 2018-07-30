using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NenoSlack.Models;
using Microsoft.AspNetCore;

namespace NenoSlack.Controllers
{
    public class LoginController : Controller
    {
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
                    //OnlineUser ouser = new OnlineUser();
                    //ouser.UserId = user.UserId;
                    //ouser.connectionIds = new List<ConnectionId>();

                    //Session["User"] = ouser;
                    return RedirectToAction("Index", "Chat");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}