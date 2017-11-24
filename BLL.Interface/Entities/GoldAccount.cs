using System;
namespace BLL.Interface.Entities
{
    public class GoldAccount : Account
    {
        #region Ctors
        public GoldAccount(string accountNumber, string name) : base(accountNumber, name) { }

        public GoldAccount(string accountNumber, string name, decimal balance) : base(accountNumber, name, balance){ }

        public GoldAccount(string accountNumber, string name, decimal balance, int points)
        : base(accountNumber, name, balance, points){ }
        #endregion

        #region Overriding abstract base class methods
        protected override bool IsValidBalance(decimal value)
            => value >= -2000;

        protected override int CalculateBenifitPoints(decimal amount)
            => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
        #endregion
    }
}
