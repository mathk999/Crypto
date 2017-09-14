﻿using System;
using System.Diagnostics;
using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public class Market
    {
        private static readonly Lazy<Market> _instance =
            new Lazy<Market>(() => new Market());

        public decimal[][] Rates;

        public static Market GetInstance()
        {
            return _instance.Value;
        }


        public bool Exchange(CurrenciesSignatures toSell, CurrenciesSignatures toBuy, decimal quantity, IWallet wallet)
        {
            if (wallet.HasEnoughFunds(toSell, quantity))
            {
                wallet.SubstractFunds(toSell, quantity);
                wallet.AddFunds(toBuy, quantity * Rates[(int)toSell][(int)toBuy]);

                return true;
            }
            return false;
        }

        public void OnRatesUpdated(object source, CurrenciesRatesEvantArgs args)
        {
            Rates[(int)args.ChangeFrom][(int)args.ChangeTo] = args.Value;
            Rates[(int)args.ChangeTo][(int)args.ChangeFrom] = 1 / args.Value;
        }
    }
}