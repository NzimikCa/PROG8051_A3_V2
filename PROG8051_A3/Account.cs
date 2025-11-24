using PROG8051_A3_User;
namespace PROG8051_A3_Account
{
    public abstract class Account
    {
        // Attributes
        private List<User> owners;
        bool isShared;
        private uint accountId;
        string currency;
        // Constructors
        public Account(List<User> ownersProvided, uint idProvided, string providedCurrency)
        {
            this.owners = ownersProvided;
            this.isShared = owners.Count > 1;
            this.accountId = idProvided;
            this.currency = providedCurrency;
        }
        // Properties
        public List<User> Owners { get { return this.owners; } }
        public string IsShared { get { return isShared ? "This is a shared account." : "This is not a shared account"; } }
        public uint Id { get { return this.accountId; } }

        // Methods
        public override abstract string ToString();
    }
}
