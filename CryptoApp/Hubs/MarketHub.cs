﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CryptoApp.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CryptoApp.Hubs
{
    public class MarketHub : Hub
    {
        private readonly TestApi _market;

        public MarketHub() : this(TestApi.GetInstance()) { }

        public MarketHub(TestApi market)
        {
            _market = market;
        }

        public void TestMethod()
        {
            Clients.All.updateRates();
            Debug.WriteLine("test Bro");
        }
    }
}