using System;
using System.Collections.Generic;

namespace hMailServerAPI
{
    public class DomainCollection
    {
        private readonly dynamic _domains;

        public DomainCollection(dynamic domains)
        {
            _domains = domains;
        }

        public void DeleteByDBID(long id)
        {
            _domains.DeleteByDBID(id);
        }

        public void Refresh()
        {
            _domains.Refresh();
        }

        public Domain this[long index]
        {
            get { return _domains.Item(index); }
        }

        public Domain GetItemByDBID(long id)
        {
            dynamic oDomain = _domains.ItemByDBID(id);
            return new Domain(oDomain);
        }

        public Domain GetItemByName(string name)
        {
            try
            {
                dynamic oDomain = _domains.ItemByName(name);
                return new Domain(oDomain);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Domain Add()
        {
            dynamic oDomain = _domains.Add();
            return new Domain(oDomain);
        }
    }
}