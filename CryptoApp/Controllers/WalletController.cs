﻿using CryptoApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoApp.Controllers
{
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalletController()
        {
            _context = new ApplicationDbContext();
        }
   
        // GET: Wallet
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated){
                var userId = User.Identity.GetUserId();
                var wallet = _context.Users.Where(u => u.Id == userId).SingleOrDefault().UserWallet;
                return View(wallet);
            }
            else
            {
                return Redirect("Account/Login");
            }
        }
    }
}