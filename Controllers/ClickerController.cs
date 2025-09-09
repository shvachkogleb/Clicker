using ClickerGame.Data;
using ClickerGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClickerGame.Controllers
{
    public class ClickerController : Controller
    {
        private readonly AppDbContext _context;

        public ClickerController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            _context.Database.EnsureCreated();
            var player = _context.Players.FirstOrDefault();
            if (player == null)
            {
                player = new Player();
                _context.Players.Add(player);
                _context.SaveChanges();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Click()
        {
            var player = _context.Players.FirstOrDefault();
            player.Clicks += player.ClickPower;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BuyUpgrade()
        {
            var player = _context.Players.First();

            int baseCost = 10;           
            int increasePerLevel = 20;   
            int upgradeCost = baseCost + (player.ClickPower * increasePerLevel);

            if (player.Clicks >= upgradeCost)
            {
                player.Clicks -= upgradeCost;
                player.ClickPower++;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ResetProgress()
        {
            var player = _context.Players.First();

            player.Clicks = 0;
            player.ClickPower = 1; 
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
