using Auth1.Models;
using Auth1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Python.Runtime;
using Microsoft.AspNetCore.Identity;
using IdentityManagerUI.Models;

namespace Auth1.Controllers
{
    public class HomeController : Controller
    {
        private IMummyRepository repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMummyRepository temp, ILogger<HomeController> logger)
        {
            repo = temp;
            _logger = logger;
        }
        //private readonly Dictionary<string, string> _claimTypes;

        //public HomeController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ILogger<HomeController> logger)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _logger = logger;

        //    _roles = roleManager.Roles.ToDictionary(r => r.Id, r => r.Name);
        //    var fldInfo = typeof(ClaimTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
        //    _claimTypes = fldInfo.ToDictionary(i => i.Name, i => (string)i.GetValue(null));
        //}
        //public IActionResult Roles()
        //{
        //    ViewBag.ClaimTypes = _claimTypes.Keys.OrderBy(s => s);
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Records(int pageNum = 1)
        {
            int pageSize = 100;

            //ViewBag.textiles = repo.textile.ToList();

            var BurialData = new BurialViewModel
            {

                masterburialsummary3 = repo.masterburialsummary3 // used to be burialmain
                                                                 //.Include(x => x.burialmain_textile) tried to include association with it
                    .OrderBy(d => d.id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    //TotalNumBurials = (bookCategory == null ? repo.burialmain.Count()
                    //    : repo.burialmain.Where(x => x.Category == bookCategory).Count()),
                    TotalNumBurials = repo.masterburialsummary3.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },
            };

            return View(BurialData);
        }

        [HttpPost]
        public IActionResult Records(string BurialID, string Sex, string TextileColor, string AgeAtDeath, string HeadDirection,
            string HairColor, string TextileStructure, string TextileFunction, float EstimateStature, string Area, string Femur, int pageNum = 1) // POST
        {

            int pageSize = 100;

            var BurialData = new BurialViewModel
            {

                masterburialsummary3 = repo.masterburialsummary3 // used to be burialmain
                    .OrderBy(d => d.id)
                     .Where(d => (Sex == null || d.sex == Sex) && (BurialID == null || d.burialid == BurialID) &&
                        (TextileColor == null || d.color == TextileColor) &&
                        (AgeAtDeath == null || d.ageatdeath == AgeAtDeath) &&
                        (HeadDirection == null || d.headdirection == HeadDirection) &&
                        (HairColor == null || d.haircolor == HairColor) &&
                        (TextileStructure == null || d.structure == TextileStructure) &&
                        (TextileFunction == null || d.textilefunction == TextileFunction) &&
                        (Area == null || d.area == Area) &&
                        (Femur == null || d.femur == Femur) &&
                        (EstimateStature == null || d.estimatestature == EstimateStature))
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                //masterburialsummary = repo.masterburialsummary // used to be burialmain
                //    .OrderBy(d => d.id)
                //    .Where(d => (Sex == null || d.sex == Sex) &&
                //                (TextileColor == null || d.color == TextileColor) &&
                //                (AgeAtDeath == null || d.ageatdeath == AgeAtDeath) &&
                //                (HeadDirection == null || d.headdirection == HeadDirection) &&
                //                (HairColor == null || d.haircolor == HairColor) &&
                //                (TextileStructure == null || d.structure == TextileStructure) &&
                //                (TextileFunction == null || d.textilefunction == TextileFunction))
                //    .Skip((pageNum - 1) * pageSize)
                //    .Take(pageSize),


                PageInfo = new PageInfo
                {
                    TotalNumBurials = (BurialID == null && Sex == null && TextileColor == null && AgeAtDeath == null && HeadDirection == null && HairColor == null
                    && TextileStructure == null && TextileFunction == null && Area == null && Femur == null ? repo.masterburialsummary3.Count() //most RECENT one
                       : repo.masterburialsummary3.Where(x => (Sex == null || x.sex == Sex) &&
                                           (TextileColor == null || x.color == TextileColor) &&
                                           (AgeAtDeath == null || x.ageatdeath == AgeAtDeath) &&
                                           (HeadDirection == null || x.headdirection == HeadDirection) &&
                                           (HairColor == null || x.haircolor == HairColor) &&
                                           (TextileStructure == null || x.structure == TextileStructure) &&
                                           (TextileFunction == null || x.textilefunction == TextileFunction) &&
                                           (Area == null || x.area == Area) &&
                                           (Femur == null || x.femur == Femur)).Count()),

                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },


            };

            return View(BurialData);
        }



        [HttpGet]
        public IActionResult MummyForm()
        {
            if (User.Identity.Name == "bprosurf@yahoo.com")
            {
                long? newId = GetNewId();
                // Pass the new ID to the view
                ViewBag.NewId = newId;
                return View();
            }
            else
            {
                return new ForbidResult();
            }
        }
        private long? GetNewId() // used to auto increment the IDs
        {
            // retrieve the most recent ID from the database
            long? lastId = repo.masterburialsummary3
                .OrderByDescending(x => x.id)
                .Select(x => x.id)
                .FirstOrDefault();

            // increment the ID to get a new ID
            long? newId = lastId + 1;

            return newId;
        }

        [HttpPost]
        public IActionResult MummyForm(Masterburialsummary3 mummy) // POST
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
        [HttpGet]
        public IActionResult EditMummyForm()
        {
            //long? newId = GetNewId();
            //// Pass the new ID to the view
            //ViewBag.NewId = newId;
            return View();
        }

        [HttpPost]
        public IActionResult EditMummyForm(Masterburialsummary3 mummy) // POST
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
            if (User.Identity.Name == "bprosurf@yahoo.com")
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

                return View("EditMummyForm", mummy);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(Masterburialsummary3 mummy)
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
            if (User.Identity.Name == "bprosurf@yahoo.com")
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
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var mummy = repo.GetMummyById(id);
            repo.DeleteMummy(mummy);
            repo.Save();
            return RedirectToAction("Records");
        }

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

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Supervised()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Supervised(string parames)
        {

            return View();
        }

        public IActionResult Unsupervised()
        {
            

            return View();
        }
    }
}
