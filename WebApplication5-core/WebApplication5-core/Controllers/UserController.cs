using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5_core.Data;
using WebApplication5_core.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication5_core.Controllers
{
    public class UserController : Controller
    {


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string Email,string Password) {

            HashAlgorithm sha = SHA256.Create();
            BookstoreContext database = new BookstoreContext();

           byte[]arr= sha.ComputeHash(Encoding.ASCII.GetBytes(Password));


            Registeration s=database.Registerations.FirstOrDefault(a => a.Email == Email && a.Password == Encoding.Default.GetString(arr));

            if (s != null)
                return RedirectToAction("Showmain", "Book");
            else
                return View("Loginerror");




        }


        [HttpPost]
        //to handle the request coming from the user
        public IActionResult Register(Registeration reg)
        {

            HashAlgorithm sha = SHA256.Create();
            BookstoreContext database = new BookstoreContext();
            Registeration s = new Registeration();


            if (database.Registerations.FirstOrDefault(a => a.Email == reg.Email) != null)
                return View("Registererror");
            

            if (database.Registerations.Count() >= 1) {
                List<Registeration> m = database.Registerations.ToList();
                s.Id = m[m.Count - 1].Id + 1;


            }
            else
                s.Id =1;
           

            s.Firstname = reg.Firstname;
            s.Lastname = reg.Lastname;
            s.Email = reg.Email;
            s.Phonenumber = reg.Phonenumber;

            byte[]arr=sha.ComputeHash(Encoding.ASCII.GetBytes(reg.Password));
            s.Password=Encoding.Default.GetString(arr);
            database.Registerations.Add(s);
            database.SaveChanges();
            return RedirectToAction("Login");

        }

        //TO return the view to the user
        public IActionResult Register()
        {




            return View();



        }
    }

    }
