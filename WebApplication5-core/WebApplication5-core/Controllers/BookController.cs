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

            BookstoreContext database = new BookstoreContext();

                List<Book> s=database.Books.Where(a => a.Scount >= 10).ToList();

            return View(s);
        }


        public IActionResult Details(int ID) {


            BookstoreContext database = new BookstoreContext();


            Book b1 =database.Books.FirstOrDefault(a => a.Id == ID);
            b1.Author = database.Authors.FirstOrDefault(a => a.Id == b1.AuthorId);

            return View(b1);
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
