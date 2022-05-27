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
        //to handle the request coming from the user
        public void Register(Registeration reg)
        {

            HashAlgorithm sha = SHA256.Create();
            BookstoreContext c = new BookstoreContext();
            Registeration s = new Registeration();

            

            if (c.Registerations.Count() >= 1) {
                List<Registeration> m = c.Registerations.ToList();
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
            c.Registerations.Add(s);
            c.SaveChanges();

        }

        //TO return the view to the user
        public IActionResult Register()
        {




            return View();



        }
    }

    }
