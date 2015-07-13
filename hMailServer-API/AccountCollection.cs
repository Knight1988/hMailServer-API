using System;

namespace hMailServerAPI
{
    public class AccountCollection
    {
        private readonly dynamic _accounts;

        public AccountCollection(dynamic accounts)
        {
            _accounts = accounts;
        }

        public Account GetItemByAddress(string username)
        {
            try
            {
                var oAccount = _accounts.ItemByAddress(username);
                return new Account(oAccount);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}