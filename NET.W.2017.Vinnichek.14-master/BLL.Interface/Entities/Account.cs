using System;
using System.Net.Mail;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        #region Fields
        private string accountNumber;
        private string ownerName;
        private string ownerEmail;
        private decimal balance;
        private int benefitPoints;
        #endregion

        #region Properties
        public string AccountNumber
        {
            get => accountNumber;
            private set => accountNumber = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException(nameof(accountNumber));
        }

        public string OwnerName
        {
            get => ownerName;
            private set => ownerName = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException(nameof(ownerName));
        }

        

        public decimal Balance
        {
            get => balance;
            private set => balance = IsValidBalance(value) ? value : throw new ArgumentException(nameof(balance));
        }

        public int BenefitPoints
        {
            get => benefitPoints;
            private set => benefitPoints = value >= 0 ? value : throw new ArgumentException(nameof(benefitPoints));
        }

        public string OwnerEmail
        {
            get => ownerEmail;
            set
            {
                try
                {
                    var mailAddress = new MailAddress(value);
                }
                catch (Exception)
                {
                    throw new ArgumentException(nameof(ownerEmail));
                }

                ownerEmail = value;
            }
        }
        #endregion

        #region Ctors
        protected Account(string accountNumber, string ownerName, string ownerEmail, decimal balance, int benefitPoints)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            OwnerEmail = ownerEmail;
            Balance = balance;
            BenefitPoints = benefitPoints;
        }
        #endregion
 
        #region Public Methods
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            Balance += amount;

            benefitPoints += CalculateBenifitPoints(amount);
        }

        public void Whithdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            Balance -= amount;

            benefitPoints -= CalculateBenifitPoints(amount);
        }
        #endregion

        #region Abstract Methods
        protected abstract bool IsValidBalance(decimal value);

        protected abstract int CalculateBenifitPoints(decimal amount);
        #endregion

        #region overriding ToSrting()
        public override string ToString()
            => $"#{AccountNumber} Name: {OwnerName}  Email: {OwnerEmail} Balance: {Balance} Benefit points: {benefitPoints}";
        #endregion
    }
}