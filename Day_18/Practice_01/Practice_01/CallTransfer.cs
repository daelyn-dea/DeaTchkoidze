using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    static public  class CallTransfer
    {
        static public void TransferAmountFromUser(User dea)
        {
            Console.WriteLine("How much GEL do you want to transfer?");
            try
            {
                decimal TransactionAmount = decimal.Parse(Console.ReadLine());
                if (TransactionAmount > 5000)
                {
                    throw new AmountExceptionLogic("limit of per transaction is 5000");
                }
                if (TransactionAmount < 0)
                {
                    throw new AmountExceptionLogic("Please Enter Valid amount: from 0 to 5000");
                }
                Console.WriteLine($"Choose which IBAN you want to transfer from: (choose numbers) ");
                for (int i = 0, k = 0; i < dea._DebtorIban.Count + dea._CreditorIban.Count; i++)
                {
                    if (i < dea._DebtorIban.Count)
                    {
                        Console.WriteLine($"{i}. {dea._DebtorIban[i].IbanNum}");
                    }
                    else
                    {
                        Console.WriteLine($"{dea._DebtorIban.Count + k}. {dea._CreditorIban[k].IbanNum}");
                        k++;
                    }
                }
                int ibanChoose = int.Parse(Console.ReadLine());

                Console.WriteLine($"Choose which IBAN you want to transfer to: (choose numbers) ");
                for (int i = 0, k = 0; i < dea._DebtorIban.Count + dea._CreditorIban.Count; i++)
                {
                    if (i < dea._DebtorIban.Count & i != ibanChoose)
                    {
                        Console.WriteLine($"{i}. {dea._DebtorIban[i].IbanNum}");
                    }
                    if (i >= dea._DebtorIban.Count & i != ibanChoose)
                    {
                        Console.WriteLine($"{dea._DebtorIban.Count + k}. {dea._CreditorIban[k].IbanNum}");
                        k++;
                    }
                }
                int ibanChoose2 = int.Parse(Console.ReadLine());
                try
                {
                    if (ibanChoose < dea._DebtorIban.Count)
                    {
                        dea._DebtorIban[ibanChoose].Addamount(TransactionAmount, dea._DebtorIban[ibanChoose], dea._DebtorIban[ibanChoose2]);
                    }
                    else
                    {
                        dea._CreditorIban[ibanChoose].Addamount(TransactionAmount, dea._CreditorIban[ibanChoose], dea._CreditorIban[ibanChoose2]);
                    }
                }
                catch (IBANValidException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Transaction status: Succesful");
            }
            catch (AmountExceptionLogic ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "please enter just numbers");
            }
            dea.PrintUserInfo();
        }
    }
}
