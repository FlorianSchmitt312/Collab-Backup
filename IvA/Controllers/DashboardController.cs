﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvA.Data;
using IvA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IvA.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext context, 
                                    UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var loggedUser = await _userManager.GetUserAsync(this.User);
            List<PaketeUserViewModel> UsersPackages = _context.PaketeUserViewModel.ToList();
            var Packages = _context.ArbeitsPaket.ToList();
            var dashboard = from _packages in Packages
                                join _userPackages in UsersPackages
                                on _packages.ArbeitsPaketId equals _userPackages.ArbeitsPaketId
                                where _userPackages.UserId == loggedUser.Id
                                select new ArbeitsPaketModel
                                {
                                    ArbeitsPaketId = _packages.ArbeitsPaketId,
                                    Beschreibung = _packages.Beschreibung,
                                    Frist = _packages.Frist,
                                    Mitglieder = _packages.Mitglieder,
                                    PaketName = _packages.PaketName,
                                    ProjektId = _packages.ProjektId,
                                    Status = _packages.Status
                                };
            List<ArbeitsPaketModel> sortedDashboard = dashboard.ToList();
            sortedDashboard.Sort((x, y) => DateTime.Compare(x.Frist, y.Frist));
            return View(sortedDashboard);
        }

        public async Task<IActionResult> List()
        {
            var loggedUser = await _userManager.GetUserAsync(this.User);
            List<PaketeUserViewModel> UsersPackages = _context.PaketeUserViewModel.ToList();
            var Packages = _context.ArbeitsPaket.ToList();
            var dashboard = from _packages in Packages
                            join _userPackages in UsersPackages
                            on _packages.ArbeitsPaketId equals _userPackages.ArbeitsPaketId
                            where _userPackages.UserId == loggedUser.Id
                            select new ArbeitsPaketModel
                            {
                                ArbeitsPaketId = _packages.ArbeitsPaketId,
                                Beschreibung = _packages.Beschreibung,
                                Frist = _packages.Frist,
                                Mitglieder = _packages.Mitglieder,
                                PaketName = _packages.PaketName,
                                ProjektId = _packages.ProjektId,
                                Status = _packages.Status
                            };
            List<ArbeitsPaketModel> sortedDashboard = dashboard.ToList();
            sortedDashboard.Sort((x, y) => DateTime.Compare(x.Frist, y.Frist));
            return View(sortedDashboard);
        }
        public async Task<IActionResult> Done()
        {
            var loggedUser = await _userManager.GetUserAsync(this.User);
            List<PaketeUserViewModel> UsersPackages = _context.PaketeUserViewModel.ToList();
            var Packages = _context.ArbeitsPaket.ToList();
            var dashboard = from _packages in Packages
                            join _userPackages in UsersPackages
                            on _packages.ArbeitsPaketId equals _userPackages.ArbeitsPaketId
                            where _userPackages.UserId == loggedUser.Id
                            select new ArbeitsPaketModel
                            {
                                ArbeitsPaketId = _packages.ArbeitsPaketId,
                                Beschreibung = _packages.Beschreibung,
                                Frist = _packages.Frist,
                                Mitglieder = _packages.Mitglieder,
                                PaketName = _packages.PaketName,
                                ProjektId = _packages.ProjektId,
                                Status = _packages.Status
                            };
            List<ArbeitsPaketModel> sortedDashboard = dashboard.ToList();
            sortedDashboard.Sort((x, y) => DateTime.Compare(x.Frist, y.Frist));
            return View(sortedDashboard);
        }
    }
}