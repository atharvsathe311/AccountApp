using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public int AccNo {  get; set; }
        public string AccName { get; set; }
        public string AccBank {  get; set; }
        public double AccBal { get; set; }
        public long AccAdhar { get; set; }

        public const double MIN_BALANCE = 500;
        private static string _userMaxBalance;
        private static double _maxBalance;
        private bool _transactionBoolean = true;
        public Account()
        {

        }
        public Account(int accountNumber,string accountName,string bankName,long aadharCardNumber) :this(accountNumber,accountName,bankName,aadharCardNumber,MIN_BALANCE) 
        { }

        public Account(int accountNumber, string accountName, string bankName, long aadharCardNumber, double balance) 
        {

            //_accountNumber = accountNumber;
            //_bankName = bankName;
            //_accountName = accountName;
            //_accountAadharNumber = aadharCardNumber;

            AccNo = accountNumber;
            AccName = accountName;
            AccBank = bankName;
            AccAdhar = aadharCardNumber;


            if (balance < MIN_BALANCE)
            {
                AccBal = MIN_BALANCE;
            }
            else
            {
                AccBal = balance;
            }

            //MaximumBalanceUser(AccBal, AccNo);
        }

        private bool Deposit(double amount)
        {
            AccBal += amount;
            return true;
        }

        private bool Withdraw(double amount)
        {
            if (AccBal - amount < MIN_BALANCE)
            {
                return false ;
            }
            AccBal -= amount;
            return true;
        }
        
        private void GetBalance() { Console.WriteLine("The Balance of the Account is {0}", AccBal); }

        private void PrintAccountDetails()
        {
            Console.WriteLine("The Account Number is {0}",AccNo);
            Console.WriteLine("The Account Name is {0}",AccName);
            Console.WriteLine("The Bank Name is {0}", AccBank);
            Console.WriteLine("The Balance of the Account is {0}",AccBal);
            Console.WriteLine("The Addhar Card Number is {0}",AccAdhar);
        }

        private void MaximumBalanceUser()
        {
            List<Account> accounts = SerialDeserial.DeserialiseData();

            foreach (Account account in accounts)
            {
                if (account.AccBal > _maxBalance)
                {
                    _maxBalance = account.AccBal;
                    _userMaxBalance = account.AccName;
                }
            }

        }
        
        public void Trasactions()
        {
            Console.WriteLine("Welcome {0}",AccName);
            _transactionBoolean = true;
            while (_transactionBoolean)
            {
                DotLinePrinter();
                Console.WriteLine("Choose the Transactions from following: ");
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Display Balance");
                Console.WriteLine("4.Display Account Details");
                Console.WriteLine("5.Display Maximum Balance User");
                Console.WriteLine("6.Exit to Previous Menu");
                DotLinePrinter();

                int userInput = int.Parse(Console.ReadLine());
                TransactionsSwitch(userInput);

            }
        }

        public void TransactionsSwitch(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    DotLinePrinter();
                    Console.WriteLine("Enter the Amount to Deposit");
                    int amountToDeposit = int.Parse(Console.ReadLine());
                    DotLinePrinter();
                    if (Deposit(amountToDeposit))
                    {
                        Console.WriteLine("Money Deposited,so now Total Balance is {0}", AccBal);
                    }
                    else
                    {
                        Console.WriteLine("Error Money Not Deposited");
                    }
                    DotLinePrinter();
                    break;

                case 2:
                    DotLinePrinter();
                    Console.WriteLine("Enter the Amount to Withdraw");
                    int amountToWithdraw = int.Parse(Console.ReadLine());
                    DotLinePrinter();

                    if (Withdraw(amountToWithdraw))
                    {
                        Console.WriteLine("Money Withdrawn Successfully,so now Total Balance is {0}", AccBal);
                    }
                    else
                    {
                        Console.WriteLine("Error Money can't be Withdrawn");
                    }
                    DotLinePrinter();
                    break;

                case 3:
                    DotLinePrinter();
                    GetBalance();
                    DotLinePrinter();
                    break;

                case 4:
                    DotLinePrinter();
                    PrintAccountDetails();
                    DotLinePrinter();
                    break;

                case 5:
                    DotLinePrinter();
                    MaximumBalanceUser();
                    Console.WriteLine("The Account Name with Maximum Balance is {0} and Maximum Balance is {1}", _userMaxBalance, _maxBalance);
                    DotLinePrinter();
                    break;
                case 6:
                    DotLinePrinter();
                    Console.WriteLine("Logging Off this Bank Account");
                    Console.WriteLine("Thank You");
                    _transactionBoolean = false;
                    DotLinePrinter();
                    break;

                default:
                    DotLinePrinter();
                    Console.WriteLine("Invalid input. Please try again.");
                    DotLinePrinter();
                    break;

            }


        }

        public static void DotLinePrinter()
        {
            Console.WriteLine("..................................................");
        }
    }
}
