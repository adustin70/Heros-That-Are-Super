using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Data;
using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var superheroes = _context.SuperHeroes;
            return View(superheroes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SuperHero superHero)
        {
            try
            {
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            var hero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                _context.Update(superHero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            var heroToDelete = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(heroToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                _context.Remove(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int? id)
        {
            var heroToDisplay = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(heroToDisplay);
        }
    }
}
