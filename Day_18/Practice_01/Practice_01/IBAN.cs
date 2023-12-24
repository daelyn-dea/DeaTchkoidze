using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    public class IBAN
    {
        public IBAN(string ibanNum, decimal balance)
        {
            IbanNum = ibanNum;
            Balance = balance;
        }

        public string IbanNum { get; set;}
        public decimal Balance { get; set; }

        public decimal TransactionAmount { get; set; }


        public void Addamount(decimal TransactionAmount, IBAN iban1, IBAN iban2)
        {
                
            if (TransactionAmount > iban1.Balance)
            {
                throw new AmountExceptionLogic("You havn't enough money. ");
            }

            iban1.Balance -= TransactionAmount;
            iban2.Balance += TransactionAmount;
        }
    
    }

    public class CreditIban : IBAN
    {
        public CreditIban(string ibanNum, decimal balance) : base(ibanNum, balance)
        {
        }
    }
    public class DebitIban : IBAN
    {
        public DebitIban(string ibanNum, decimal balance, decimal percente, DateTime endofDeposit, DateTime start) : base(ibanNum, balance)
        {
            Percente = percente;
            EndOfDeposit = endofDeposit;
            StartOfDeposit = start;
        }
        public decimal Percente { get; set; }
        public DateTime EndOfDeposit { get; set; }
        public DateTime StartOfDeposit { get; set; }
        public decimal FutureValueOfDeposit()
        {
            decimal nper = EndOfDeposit.Year - DateTime.Now.Year;
            decimal finnalyAmount = Balance + Balance * Percente /100 * nper;
            return finnalyAmount;
        }
    }
}
