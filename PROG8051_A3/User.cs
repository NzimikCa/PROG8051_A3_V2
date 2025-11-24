using PROG8051_A3_Account; 
using PROG8051_A3_IConnection;
using System.Formats.Asn1;
namespace PROG8051_A3_User
{
    public class User : IConnection
    {
        // Attributes
        private string username;
        private string password;
        private string name;
        private List<Account> accounts;
        // Constructors
        public User(string usernameProvided, string passwordProvided, string nameProvided)
        {
            this.username = usernameProvided;
            this.password = passwordProvided;
            this.name = nameProvided;
            this.accounts = new List<Account>();//empty list created to store
        }
        // Properties
        public string Username
        {
            get { return this.username; }
        }
        public string Name
        {
            get { return this.name; }
        }
        
        // Methods
        public bool ConnectUser(string passwordProvided)
        {
            if (passwordProvided == this.password)
            {
                Console.WriteLine($"Connected to the payment gateway. Welcome {this.name}. ");
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to connect user {this.Username}: Incorrect Password.");
                return false;
            }
        }

        public void DisconnectUser()
        {
            Console.WriteLine($"Disconnected user {this.name} to the payment gateway.");
        }
        public Account AccountAccess(uint idProvided)
        // Returns Account instance corresponding to the ID entered, null if no matching account
        {
            Account accountAccessed = null;
            foreach (Account acct in accounts)
            {
                if (acct.Id == idProvided)
                {
                    accountAccessed = acct;
                    break;
                }
            }
            return accountAccessed;
        }
        public void ViewAccounts()
        {
            if(accounts.Count == 0)
            {
                Console.WriteLine($"{this.Username} has no accounts");
            }
            else
            {
                Console.WriteLine($"{this.Username} accounts:");
                foreach (Account acct in this.accounts)
                {
                    Console.WriteLine(acct);
                }
            }
        }
        // to get all accounts associated with a user
        public List<Account> GetAccounts()
        {
            return this.accounts;
        }
        public void AddAccount(Account acc)
        {
            this.accounts.Add(acc);
        }
        

    }
}
