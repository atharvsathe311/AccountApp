using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            AccountManager.MainMenu();
        }


       

        //public static void AccountTransactionMain()
        //{
        //    List<Account> account = SerialDeserial.DeserialiseData();
        //    Account selectedAccount;
        //    int accountNumberChoice;

        //    while (true)
        //    {
        //        Console.WriteLine("Enter the account Number");
        //        accountNumberChoice = int.Parse(Console.ReadLine());

        //        selectedAccount = ChoiceAccountFinder(account,accountNumberChoice);

        //        if (selectedAccount == null)
        //        {
        //            Console.WriteLine("Invalid Account Number ! Please try again !");
        //            continue;
        //        }

        //        selectedAccount.Trasactions();
        //        SerialDeserial.SerialiseData(account);
        //        break;
        //    }

        //}
        //public static Account ChoiceAccountFinder(List<Account> accounts,int accountNumberChoice)
        //{

        //    Account selectedAccount;
        //    foreach (Account selectAccount in accounts)
        //    {
        //        if (selectAccount.AccNo == accountNumberChoice)
        //        {
        //            selectedAccount = selectAccount;
        //            return selectedAccount;
        //        }
        //    }
        //    return null;

        //}

    }

}
