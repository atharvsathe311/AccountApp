using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class AccountManager:Account
    {
        public static void MainMenu()
        {
            List<Account> account = SerialDeserial.DeserialiseData();

            if (account.Count == 0)
            {
                Console.WriteLine("No Account Exists Please Add the Account :");
                AccountManager.Add();
            }

            ChoiceMenu();
        }

        public static void ChoiceMenu()
        {
            int userChoice=1;

            do
            {
                Console.WriteLine("Welcome To Banking Solutions");

                userChoice = ChoiceMenuWhileLoop(userChoice);

                ChoiceMenuSwitch(userChoice);
                
                if (userChoice == 5)
                    break;

            } while (true);

        }

        public static int ChoiceMenuWhileLoop(int userChoice)
        {
            while (true)
            {
                Account.DotLinePrinter();
                Console.WriteLine("Choose and Enter Digit From Below");
                Console.WriteLine("1 -> To Enter Bank Account Number");
                Console.WriteLine("2 -> To Add Account");
                Console.WriteLine("3 -> To Remove Account");
                Console.WriteLine("4 -> To Update Account");
                Console.WriteLine("5 -> To Exit");
                Account.DotLinePrinter();


                userChoice = int.Parse(Console.ReadLine());

                if (userChoice < 0 || userChoice > 5)
                {
                    Console.WriteLine("Invalid Input !");
                    continue;
                }
                return userChoice;
            }


        }
        
        public static void ChoiceMenuSwitch(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    AccountTransactionMain();
                    break;
                case 2:
                    AccountManager.Add();
                    break;
                case 3:
                    AccountManager.Remove();
                    break;
                case 4:
                    AccountManager.Update();
                    break;
                case 5:
                    break;

            }

        }
        
        public static void AccountTransactionMain()
        {
            List<Account> account = SerialDeserial.DeserialiseData();
            Account selectedAccount;
            int accountNumberChoice;

            while (true)
            {
                Account.DotLinePrinter();
                Console.WriteLine("Enter the Account Number");
                accountNumberChoice = int.Parse(Console.ReadLine());
                Account.DotLinePrinter();

                selectedAccount = ChoiceAccountFinder(account, accountNumberChoice);

                if (selectedAccount == null)
                {
                    Console.WriteLine("Invalid Account Number ! Please try again !");
                    continue;
                }

                selectedAccount.Trasactions();
                SerialDeserial.SerialiseData(account);
                break;
            }

        }
        
        public static Account ChoiceAccountFinder(List<Account> accounts, int accountNumberChoice)
        {

            Account selectedAccount;
            foreach (Account selectAccount in accounts)
            {
                if (selectAccount.AccNo == accountNumberChoice)
                {
                    selectedAccount = selectAccount;
                    return selectedAccount;
                }
            }
            return null;

        }

        public static void Add()
        {
            List<Account> accounts = SerialDeserial.DeserialiseData();
            Console.WriteLine("..................Adding Account..................");
            Console.WriteLine("Enter Account Number");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Account Name");
            string accountName = Console.ReadLine();
            Console.WriteLine("Enter Bank Name");
            string bankName = Console.ReadLine();
            Console.WriteLine("Enter Aadhar Number");
            long aadharNumber = long.Parse(Console.ReadLine());

            int balance = BalanceAdder();

            Account account = new Account(accountNumber,accountName,bankName,aadharNumber,balance);
            accounts.Add(account);

            SerialDeserial.SerialiseData(accounts);

        }

        public static int BalanceAdder()
        {
            Console.WriteLine("Enter 'Y' for Updating Balance or 'N' to Set by Default");
            string userOption = Console.ReadLine();

            if(userOption.ToLower()=="y")
            {
                Console.WriteLine("Enter the New Balance");
                int newBalance = int.Parse(Console.ReadLine());
                return newBalance;
            }
            return 0;


        }

        public static void Remove()
        {
            List<Account> accounts = SerialDeserial.DeserialiseData();
            Console.WriteLine("..................Remove Account..................");
            Console.WriteLine("Enter Account Number to Remove");
            int userChoiceAccountNumber = int.Parse(Console.ReadLine());

            var condition = (AccountRemover(accounts, userChoiceAccountNumber)) ? "Account Removed Successfully" : "Account Number doesnt Exist!";
            Console.WriteLine(condition);

            SerialDeserial.SerialiseData(accounts);
        }

        public static bool AccountRemover(List<Account> accounts,int userChoiceAccountNumber)
        {
            for (int iterator = 0; iterator < accounts.Count; iterator++)
            {
                Account account = accounts[iterator];
                if (accounts[iterator].AccNo == userChoiceAccountNumber)
                {
                    accounts.RemoveAt(iterator);
                    return true;
                }
            }
            return false;

        }

        public static void Update()
        {
            List <Account> accounts = SerialDeserial.DeserialiseData();
            Console.WriteLine("..................Update Account..................");
            Console.WriteLine("Enter Account Number to Update");
            int userChoiceAccountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Choice for Updating Value");
            Console.WriteLine("1.Name \n2.Bank Name \n3.Aadhar Number");

            int userUpdateChoice = int.Parse(Console.ReadLine());

            var condition = (AccountUpdater(accounts, userChoiceAccountNumber, userUpdateChoice)) ? "Account Update Succesful" : "Account Number doesnt Exist!";

            Console.WriteLine(condition);

            SerialDeserial.SerialiseData(accounts);
            
        }

        public static bool AccountUpdater(List<Account> accounts, int userChoiceAccountNumber, int userUpdateChoice)
        {

            Console.WriteLine("Enter the Value");
            string valueToUpdate = Console.ReadLine();

            for (int iterator = 0; iterator < accounts.Count; iterator++)
            {
                Account account = accounts[iterator];
                if (account.AccNo == userChoiceAccountNumber)
                {
                    switch (userUpdateChoice)
                    {
                        case 1:
                            account.AccName = valueToUpdate;
                            Console.WriteLine("Account Updated Successfully");
                            return true;
                        case 2:
                            account.AccBank = valueToUpdate;
                            Console.WriteLine("Account Updated Successfully");
                            return true;
                        case 3:
                            account.AccAdhar = int.Parse(valueToUpdate);
                            Console.WriteLine("Account Updated Successfully");
                            return true;
                    }
                }
            }
            return false;

        }
    
    }

    
}
