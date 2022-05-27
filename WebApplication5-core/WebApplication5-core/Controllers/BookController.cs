using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5_core.Models;
using WebApplication5_core.Data;

namespace WebApplication5_core.Controllers
{
    public class BookController : Controller
    {

     

        public IActionResult Showmain()
        {

            BookstoreContext b = new BookstoreContext();

                List<Book> s=b.Books.Where(a => a.Scount >= 10).ToList();

            return View(s);
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
