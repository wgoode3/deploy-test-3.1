using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AttemptOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AttemptOne.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }

        public HomeController (MyContext context)
        {
            _context = context;
        }

        [HttpGet ("")]
        public IActionResult Index ()
        {
            Console.WriteLine ("Hello");
            ViewBag.Notes = _context.Notes.ToList ();
            return View ();
        }

        [HttpPost ("create")]
        public IActionResult Create(Note n)
        {
            if(ModelState.IsValid)
            {
                _context.Notes.Add(n);
                _context.SaveChanges();
                return Redirect("/");
            }
            ViewBag.Notes = _context.Notes.ToList ();
            return View("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _context.Notes.Remove(
                _context.Notes.FirstOrDefault(n => n.NoteId == id)
            );
            _context.SaveChanges();
            return Redirect("/");
        }

    }
}