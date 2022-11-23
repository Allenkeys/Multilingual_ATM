using System;

namespace Multilingual_ATM
{
    internal class User
    {
        private static List<Accounts> accounts = new List<Accounts>();


        public static void Run()
        {
            Accounts account1 = new Accounts("Joshua");
            Accounts account2 = new Accounts("Harryson");
            Accounts account3 = new Accounts("Alex");
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);
            Accounts owner = new Accounts("test");

            
            void Login()
            {
                Console.WriteLine("Welcome, please login");
                Console.Write("Account number: ");
                var accountNumber = Console.ReadLine();
                Console.Write("Secret Pin: ");
                var secretPin = Console.ReadLine();

                foreach (var item in accounts)
                {
                    if (item.Number == accountNumber && item.Pin == secretPin)
                    {
                        owner = item;
                        Operation(owner);
                        return;
                    }

                    Console.WriteLine("Invalid login details please try again...");
                    Login();
                }
            }
            Login();
            

            void Operation(Accounts owner)
            {
                DateTime date = DateTime.Now;

                Console.WriteLine($"Awesome {owner.AccountName}, please choose an operation");
                Console.WriteLine("1. Withdrawal\n2. Balance\n3. Transfer\n4. Account Statement\n5. Logout\n6. Exit");
                var selection = Console.ReadLine();
                if (int.TryParse(selection, out int userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Please enter amount");
                            var amount = Console.ReadLine();
                            if (double.TryParse(amount, out double amountInput))
                            {
                                owner.Withdraw(amountInput, date, "POS - Terminal withdral");
                                owner.Checkbalance();
                                Operation(owner);
                            }
                            else
                            {
                                Console.WriteLine("Failed transaction, please try again");
                                Operation(owner);
                            }
                            break;

                        case 2:
                            owner.Checkbalance(); Operation(owner); break;

                        case 3:
                            Console.WriteLine("Please enter amount");
                            var transferAmount = Console.ReadLine();

                            Console.WriteLine("Please enter account number");
                            var recieverAccount = Console.ReadLine();

                            Console.WriteLine("Please enter message");
                            var message = Console.ReadLine();

                            if (double.TryParse(transferAmount, out double transferAmountInput))
                            {
                                owner.Transfer(transferAmountInput, date, message, recieverAccount);
                                Operation(owner);
                            }
                            else
                            {
                                Operation(owner);
                            }
                            break;

                        case 4: owner.AccountStatement(); Operation(owner); break;
                        case 5: Login(); Operation(owner); break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Your input appears to be invalid, please try a numeric value");
                    Operation(owner);
                }
            }
            

        }
    }
}
