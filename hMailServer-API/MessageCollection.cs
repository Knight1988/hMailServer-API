using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace hMailServerAPI
{
    public class MessageCollection : List<Message>
    {
        private readonly dynamic _messages;

        public MessageCollection(dynamic oMessages)
        {
            _messages = oMessages;

            for (int i = 0; i < _messages.Count; i++)
            {
                Add(new Message(_messages.Item[i]));
            }
        }

        public bool Remove(long id)
        {
            var msg = this.SingleOrDefault(p => p.Id == id);
            if (msg == null) return false;

            _messages.DeleteByDBID(id);
            return true;
        }

        public void ClearAll()
        {
            Clear();
            _messages.Clear();
        }

        public IEnumerable<string> GetNotSentEmails()
        {
            return GetEmailInMailerDaemon().Distinct();
        }

        private IEnumerable<string> GetEmailInMailerDaemon()
        {
            foreach (Message message in this)
            {
                if (message.From.Contains("mailer-daemon"))
                {
                    foreach (string email in GetEmails(message.Body))
                    {
                        yield return email;
                    }
                }
            }
        }

        private IEnumerable<string> GetEmails(string text)
        {
            var emails = Regex.Matches(text, @"[-._\w]+@[-._\w]+");
            foreach (Match email in emails)
            {
                yield return email.Value;
            }
        }
    }
}