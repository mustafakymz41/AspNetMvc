using KisiGirisCikisKontrol.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KisiGirisCikisKontrol.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string bugun = DateTime.Now.ToString();
            var persons = PersonContext.Person;

            return View(persons);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePerson()
        {
            var firstName = HttpContext.Request.Form["FirstName"].ToString();
            var lastName = HttpContext.Request.Form["LastName"].ToString();
            var tcNo = long.Parse(HttpContext.Request.Form["TcNo"].ToString());
            var hesKod = HttpContext.Request.Form["HesKod"].ToString();
            var LoginTime = DateTime.Now.ToString();

            Person lastPerson = null;
            if (PersonContext.Person.Count > 0)
            {
                lastPerson = PersonContext.Person.Last();
            }
            int id = 1;
            if (lastPerson != null)
            {
                id = lastPerson.Id + 1;
            }

            PersonContext.Person.Add(new Person
            {
                FirstName = firstName,
                LastName = lastName,
                TcNo = tcNo,
                HesKod = hesKod,
                loginTime = LoginTime,
                Id = id
            });

            return RedirectToAction("Index");
        }
        public IActionResult Remove()
        {
            var Id = int.Parse(RouteData.Values["Id"].ToString());
            var removedPerson = PersonContext.Person.Find(a => a.Id == Id);

            Person lastPerson = null;
            if (PersonContext.Person.Count > 0)
            {
                lastPerson = PersonContext.Person.Last();
            }
            int LogId = 1;
            if (lastPerson != null)
            {
                LogId = lastPerson.Id + 1;
            }
            PersonLogContext.personLogs.Add(new PersonLog
            {
                Id = LogId,
                FirstName = removedPerson.FirstName,
                LastName = removedPerson.LastName,
                TcNo = removedPerson.TcNo,
                HesKod = removedPerson.HesKod,
                ExitTime = DateTime.Now.ToString()
            });
            PersonContext.Person.Remove(removedPerson);


            return RedirectToAction("PersonsLog");
        }
        public IActionResult Update()
        {
            var Id = int.Parse(RouteData.Values["Id"].ToString());
            var UpdatePerson = PersonContext.Person.Find(a => a.Id == Id);

            return View(UpdatePerson);
        }
        public IActionResult PersonsLog()
        {
            var personLog = PersonLogContext.personLogs;
            return View(personLog);
        }
        public IActionResult UpdatePerson()
        {
            var Id = int.Parse(HttpContext.Request.Form["Id"].ToString());
            var updatePerson = PersonContext.Person.Find(a => a.Id == Id);
            updatePerson.FirstName = HttpContext.Request.Form["FirstName"];
            updatePerson.LastName = HttpContext.Request.Form["LastName"];
            updatePerson.TcNo = long.Parse(HttpContext.Request.Form["TcNo"].ToString());
            updatePerson.HesKod = HttpContext.Request.Form["HesKod"];
            updatePerson.loginTime = DateTime.Now.ToString();

            return RedirectToAction("Index");
        }
     
    }
}
