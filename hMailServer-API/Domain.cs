namespace hMailServerAPI
{
    public class Domain
    {
        private readonly dynamic _domain;

        public Domain(dynamic oDomain)
        {
            _domain = oDomain;
        }

        public void Delete()
        {
            _domain.Delete();
        }

        public void Save()
        {
            _domain.Save();
        }

        public bool Active
        {
            get { return _domain.Active; }
            set { _domain.Active = value; }
        }

        public string ADDomainName
        {
            get { return _domain.ADDomainName; }
            set { _domain.ADDomainName = value; }
        }

        public bool AddSignaturesToLocalMail
        {
            get { return _domain.AddSignaturesToLocalMail; }
            set { _domain.AddSignaturesToLocalMail = value; }
        }

        public bool AddSignaturesToReplies
        {
            get { return _domain.AddSignaturesToReplies; }
            set { _domain.AddSignaturesToReplies = value; }
        }

        public long AllocatedSize
        {
            get { return _domain.AllocatedSize; }
            set { _domain.AllocatedSize = value; }
        }

        public long Id
        {
            get { return _domain.ID; }
            set { _domain.ID = value; }
        }

        public bool AntiSpamEnableGreylisting
        {
            get { return _domain.AntiSpamEnableGreylisting; }
            set { _domain.AntiSpamEnableGreylisting = value; }
        }
    }
}