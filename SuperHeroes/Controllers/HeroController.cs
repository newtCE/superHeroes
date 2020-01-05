using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Hero
        public ActionResult Index()
        {
            List<SuperHero> heroList = context.SuperHeroes.ToList();
            return View(heroList);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHero = context.SuperHeroes.Where(h => h.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                context.SuperHeroes.Add(superHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)//int id
        {
            SuperHero superHero = context.SuperHeroes.Where(h => h.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                SuperHero targetRemove = context.SuperHeroes.Where(h => h.Id == superHero.Id).FirstOrDefault();
                context.SuperHeroes.Remove(targetRemove);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
