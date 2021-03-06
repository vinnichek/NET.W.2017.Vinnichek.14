﻿using System;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        #region Ctors
        public BaseAccount(string accountNumber, string name, string email, decimal balance, int points)
        : base(accountNumber, name, email, balance, points) { }
        #endregion

        #region Overriding abstract base class methods
        protected override bool IsValidBalance(decimal value)
            => value >= 0;

        protected override int CalculateBenifitPoints(decimal amount)
            => (int)Math.Round(amount * 0.01m + Balance * 0.01m);
        #endregion
    }
}