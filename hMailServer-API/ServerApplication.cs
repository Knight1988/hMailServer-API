using System;

namespace hMailServerAPI
{
    public class ServerApplication
    {
        private readonly dynamic _app;
        private readonly DomainCollection _domains;

        public ServerApplication()
        {
            _app = Activator.CreateInstance(Type.GetTypeFromProgID("hMailServer.Application"));

            _domains = new DomainCollection(_app.Domains);
        }

        public void Authenticate(string username, string password)
        {
            _app.Authenticate(username, password);
        }

        public DomainCollection Domains
        {
            get { return _domains; }
        }
    }
}
