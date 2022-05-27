using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5_core.Data;
using WebApplication5_core.Models;

namespace WebApplication5_core.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Aboutus()
        {

            return View();
        }
    }
}
