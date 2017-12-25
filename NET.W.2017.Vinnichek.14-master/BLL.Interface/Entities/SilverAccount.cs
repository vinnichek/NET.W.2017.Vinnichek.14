using System;

namespace BLL.Interface.Entities
{
    public class SilverAccount : Account
    {
        #region Ctors
        public SilverAccount(string accountNumber, string name, string email, decimal balance, int points)
        : base(accountNumber, name, email, balance, points) { }
        #endregion

        #region Overriding abstract base class methods
        protected override bool IsValidBalance(decimal value)
            => value >= -1000;

        protected override int CalculateBenifitPoints(decimal amount)
            => (int)Math.Round(amount * 0.02m + Balance * 0.02m);
        #endregion
    }
}