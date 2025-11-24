using PROG8051_A3_Account;
using PROG8051_A3_BankAccount;
using PROG8051_A3_GoodsAccount;
using PROG8051_A3_SharesAccount;
using PROG8051_A3_User;
namespace PROG8051_A3_PaymentGateway
{
    public class PaymentGateway()
    {
        static void Main()
        {
            //for later: to connect to the gateway, ask user to choose a user from a list of users
            // each of these users will have either 1 or more owners/ujsers
            // each of these users can have 3 types of accounts
            Console.WriteLine("=== Payment Gateway Test ===\n");

            // 1. Create Users
            User alice = new User("alice", "pass123", "Alice Smith");
            User bob = new User("bob", "pass456", "Bob Jones");

            // 2. Create Accounts
            BankAccount aliceBank = new BankAccount(new List<User> { alice }, 1001, "CAD");
            SharesAccount aliceShares = new SharesAccount(new List<User> { alice }, 2001, "CAD");
            GoodsAccount bobGoods = new GoodsAccount(new List<User> { bob }, 3001, "CAD");
            BankAccount sharedBank = new BankAccount(new List<User> { alice, bob }, 1003, "CAD");

            // 3. Add accounts to users
            alice.AddAccount(aliceBank);
            alice.AddAccount(aliceShares);
            alice.AddAccount(sharedBank);
            bob.AddAccount(bobGoods);
            bob.AddAccount(sharedBank);

            // 4. Connect user to gateway
            Console.WriteLine("--- Connecting User ---");
            alice.ConnectUser("pass123");
            Console.WriteLine();

            // 5. List all accounts for Alice
            Console.WriteLine("--- Alice's Accounts ---");
            alice.ViewAccounts();
            Console.WriteLine();

            // 6. Test BankAccount - Deposit and Withdraw
            Console.WriteLine("--- Testing BankAccount ---");
            aliceBank.Deposit(1000);
            aliceBank.Withdraw(200);
            Console.WriteLine($"Balance: ${aliceBank.GetBalance}");
            Console.WriteLine();

            // 7. Test SharesAccount - Buy and Sell
            Console.WriteLine("--- Testing SharesAccount ---");
            aliceShares.Buy("AAPL", 100, "10.0");
            aliceShares.Buy("MSFT", 50, "5.0");
            aliceShares.Sell("AAPL", 30);
            Console.WriteLine(aliceShares.ToString());

            // 8. Test GoodsAccount - Buy and Sell
            Console.WriteLine("--- Testing GoodsAccount ---");
            bobGoods.Buy("Gold", 500, "grams");
            bobGoods.Buy("Silver", 10, "kg");
            bobGoods.Sell("Gold", 200);
            Console.WriteLine(bobGoods.ToString());

            // 9. Print account statements
            Console.WriteLine("--- Account Statements ---");
            Console.WriteLine(aliceBank.ToString());
            Console.WriteLine(aliceShares.ToString());
            Console.WriteLine(bobGoods.ToString());

            // 10. Disconnect user
            Console.WriteLine("--- Disconnecting User ---");
            alice.DisconnectUser();

            Console.WriteLine("\n=== Test Complete ===");
            Console.ReadLine();

        }
    }
}
