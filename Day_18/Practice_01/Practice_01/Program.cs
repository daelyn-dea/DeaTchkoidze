using Practice_01;
using System.Threading.Channels;
//between own account :D
User dea = new User("dea", "tchkoidze", "62005030347");
DebitIban debitor = new DebitIban("GE928TB4739423940000093", 2000.34m, 12.5m, new DateTime(2027, 12, 12), new DateTime(2022, 12, 12));
DebitIban debitor2 = new DebitIban("GE928TB4739423940000094", 12.34m, 12.5m, new DateTime(2027, 12, 12), new DateTime(2018, 12, 12));
DebitIban debitor3 = new DebitIban("GE928TB4739423940000095", 1012.34m, 12.5m, new DateTime(2027, 12, 12), new DateTime(2016, 12, 12));
dea._DebtorIban.Add(debitor);
dea._DebtorIban.Add(debitor2);
dea._DebtorIban.Add(debitor3);
CreditIban credIban = new CreditIban("GE928TB4739423940000011", 100.34m);
CreditIban credIban1 = new CreditIban("GE928TB4739423940000012", 0.34m);
CreditIban credIban2 = new CreditIban("GE928TB4739423940000012", 2.34m);
dea._CreditorIban.Add(credIban);
dea._CreditorIban.Add(credIban1);
dea._CreditorIban.Add(credIban2);

CallTransfer.TransferAmountFromUser(dea);
CallTransfer.TransferAmountFromUser(dea);

Console.WriteLine(debitor.FutureValueOfDeposit());
