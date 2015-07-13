using System;
using System.Collections.Generic;

namespace HMailServer.COM
{
    public class ServerApplication
    {
        private readonly dynamic _app;
        private DomainCollection _domains;

        public ServerApplication()
        {
            _app = Activator.CreateInstance(Type.GetTypeFromProgID("hMailServer.Application"));

            _domains = new DomainCollection(_app.Domains);
        }

        public void Authenticate(string username, string password)
        {
            _app.Authenticate(username, password);
        }
    }

    public class DomainCollection : List<Domain>
    {
        private readonly dynamic _domains;

        public DomainCollection(dynamic domains)
        {
            _domains = domains;
        }

        public Domain Add()
        {
            dynamic oDomain = _domains.Add();
            return new Domain(oDomain);
        }

        public void DeleteByDBID(long id)
        {
            
        }

        public void Refresh()
        {
            
        }
    }

    public class Domain
    {
        private dynamic _domain;

        public Domain(dynamic oDomain)
        {
            _domain = oDomain;
        }
    }
}
