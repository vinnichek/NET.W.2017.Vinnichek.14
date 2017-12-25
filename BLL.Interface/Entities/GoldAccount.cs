using System;
namespace BLL.Interface.Entities
{
    public class GoldAccount : Account
    {
        #region Ctors
        public GoldAccount(string accountNumber, string name, string email, decimal balance, int points)
        : base(accountNumber, name, email, balance, points) { }
        #endregion

        #region Overriding abstract base class methods
        protected override bool IsValidBalance(decimal value)
            => value >= -2000;

        protected override int CalculateBenifitPoints(decimal amount)
            => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
        #endregion
    }
}