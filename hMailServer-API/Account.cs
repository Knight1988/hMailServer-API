namespace HMailServer.COM
{
    public class Account
    {
        private readonly dynamic _account;
        private readonly MessageCollection _messageCollection;

        public Account(dynamic oAccount)
        {
            _account = oAccount;

            dynamic oMessages = _account.Messages;

            _messageCollection = new MessageCollection(oMessages);
        }

        public MessageCollection Messages
        {
            get { return _messageCollection; }
        }

        public string Address
        {
            get { return _account.Address; }
            set { _account.Address = value; }
        }

        public bool ValidatePassword(string password)
        {
            return _account.ValidatePassword(password);
        }
    }
}