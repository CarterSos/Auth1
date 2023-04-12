using Auth1.Models;
using Auth1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Controllers
{
    public class HomeController : Controller
    {
        private IMummyRepository repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController (IMummyRepository temp, ILogger<HomeController> logger)
        {
            repo = temp;
            _logger = logger;
        }
        
                
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Records(string fieldType, string fieldColor, int pageNum = 1, long idForRecord = 0)
        {
            int pageSize = 100;

            //ViewBag.textiles = repo.textile.ToList();

            var BurialData = new BurialViewModel
            {

                masterburialsummary = repo.masterburialsummary // used to be burialmain
                    //.Include(x => x.burialmain_textile) tried to include association with it
                    .OrderBy(d => d.id)
                    .Where(d => d.sex == fieldType || fieldType == null)
                    .Where(d => d.color == fieldColor || fieldColor == null)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    //TotalNumBurials = (bookCategory == null ? repo.burialmain.Count()
                    //    : repo.burialmain.Where(x => x.Category == bookCategory).Count()),
                    TotalNumBurials = (fieldType == null ? repo.masterburialsummary.Count()
                        : repo.masterburialsummary.Where(x => x.sex == fieldType).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                IdForRecord = idForRecord,

            };

            return View(BurialData);
        }
        [HttpGet]
        public IActionResult MummyForm()
        {
            long? newId = GetNewId();
            // Pass the new ID to the view
            ViewBag.NewId = newId;
            return View();
        }
        private long? GetNewId() // used to auto increment the IDs
        {
            // retrieve the most recent ID from the database
            long? lastId = repo.masterburialsummary
                .OrderByDescending(x => x.id)
                .Select(x => x.id)
                .FirstOrDefault();

            // increment the ID to get a new ID
            long? newId = lastId + 1;

            return newId;
        }
        [HttpPost]
        public IActionResult MummyForm(Masterburialsummary mummy) // POST
        {
            
            // retrieve the ID value from the form
            long id = long.Parse(Request.Form["id"]);

            // set the ID value of the model to the value from the form
            mummy.id = id;
            if (ModelState.IsValid)
            {
                repo.AddMummy(mummy);
                repo.Save();
                return RedirectToAction("Records");
            }
            else // if invalid
            {
                //ViewBag.masterburialsummary = repo.GetAllMummies();

                return RedirectToAction("Records");
            }
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mummy = repo.GetMummyById(id.Value);
            if (mummy == null)
            {
                return NotFound();
            }
            //var movie = movieContext.Responses.Single(x => x.Title == title);

            //return View("MovieForm", movie);

            return View("MummyForm", mummy);
        }

        [HttpPost]
        public IActionResult Edit(Masterburialsummary mummy)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the Edit view with the invalid mummy object
                return View("Edit", mummy);
            }

            // Check if the mummy exists in the data store
            if (!repo.MummyExists(mummy.id))
            {
                return NotFound();
            }

            // Update the mummy in the data store
            repo.UpdateMummy(mummy);
            repo.Save();

            // Redirect to the MummyList action
            return RedirectToAction("Records");
        }

        // GET: /Home/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mummy = repo.GetMummyById(id.Value);
            if (mummy == null)
            {
                return NotFound();
            }

            return View(mummy);
        }

        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var mummy = repo.GetMummyById(id);
            repo.DeleteMummy(mummy);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public IActionResult Delete(string title)
        //{
        //    var movie = movieContext.Responses.Single(x => x.Title == title);

        //    return View(movie);
        //}

        //[HttpPost]
        //public IActionResult Delete(ApplicationResponse ar)
        //{
        //    movieContext.Responses.Remove(ar);
        //    movieContext.SaveChanges();

        //    return RedirectToAction("MovieList");
        //}
        public IActionResult Info(long? id = 0)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mummy = repo.GetMummyById(id.Value);
            if (mummy == null)
            {
                return NotFound();
            }
            ViewBag.Mummy = mummy;
            
            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
