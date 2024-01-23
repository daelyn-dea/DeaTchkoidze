using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    public class User
    {
        public User(string name, string lastName, string idNum)
        {
            Name = name;
            LastName = lastName;
            IdNum = idNum;
            _DebtorIban = new List<DebitIban>();
            _CreditorIban = new List<CreditIban>();
        }

        string Name { get; set; }
        string LastName { get; set; }
        string IdNum { get; set; }
        public List<DebitIban> _DebtorIban { get; set; }
        public List<CreditIban> _CreditorIban { get; set; }

  
   
        public void PrintUserInfo()
        {
            Console.WriteLine($"User FullName: {Name} {LastName}, ID : {IdNum}");
           for (int i = 0; i < _DebtorIban.Count; i++)
            {
                Console.WriteLine($"Balance on Debtor IBAN {_DebtorIban[i].IbanNum} is: {_DebtorIban[i].Balance}");
    
            };
            for (int i = 0; i < _CreditorIban.Count; i++)
            {
                Console.WriteLine($"Balance on Debtor IBAN {_CreditorIban[i].IbanNum} is: {_CreditorIban[i].Balance}");

            };
        }
    }
}
