using System;

namespace hMailServerAPI
{
    public class ServerApplication
    {
        private readonly dynamic _app;
        private readonly DomainCollection _domains;

        public ServerApplication(string username, string password)
        {
            _app = Activator.CreateInstance(Type.GetTypeFromProgID("hMailServer.Application"));

            _app.Authenticate(username, password);

            _domains = new DomainCollection(_app.Domains);
        }

        public DomainCollection Domains
        {
            get { return _domains; }
        }
    }
}
