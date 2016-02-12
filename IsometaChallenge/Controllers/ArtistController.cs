using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsometaChallenge.Models;

namespace IsometaChallenge.Controllers
{
    public class ArtistController : Controller
    {
        readonly IArtistsRepository repository = new DbArtistsRepository();
        // GET: Superhero
        public ActionResult Index()
        {
            var artists = AutoMapper.Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistViewModel>>(repository.GetAll());
            return View(artists);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(ArtistViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var artist = AutoMapper.Mapper.Map<ArtistViewModel, Artist>(model);
                    repository.Add(artist);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(model);
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var model = AutoMapper.Mapper.Map<Artist, ArtistViewModel>(repository.GetById(id));
            return View(model);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArtistViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hero = AutoMapper.Mapper.Map<ArtistViewModel, Artist>(model);
                    hero.ArtistId = id;
                    repository.Update(hero);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(model);
        }
    }
}
