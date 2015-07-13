using System;
using System.Collections.Generic;

namespace HMailServer.COM
{
    public class Message
    {
        /// <summary>
        ///     The COM Message obj
        /// </summary>
        private readonly dynamic _message;

        /// <summary>
        ///     The plain text contents of the e-mail.
        /// </summary>
        public string Body
        {
            get { return _message.Body; }
            set { _message.Body = value; }
        }

        /// <summary>
        ///     The sender of the e-mail.
        /// </summary>
        public string From
        {
            get { return _message.From; }
            set { _message.From = value; }
        }

        /// <summary>
        ///     The sender address of the message.
        /// </summary>
        public string FromAddress
        {
            get { return _message.FromAddress; }
            set { _message.FromAddress = value; }
        }

        /// <summary>
        ///     The HTML contents of the e-mail.
        /// </summary>
        public string HTMLBody
        {
            get { return _message.HTMLBody; }
            set { _message.HTMLBody = value; }
        }

        /// <summary>
        ///     The HTML contents of the e-mail.
        /// </summary>
        public long Id
        {
            get { return _message.ID; }
            set { _message.ID = value; }
        }

        /// <summary>
        ///     The subject of the e-mail.
        /// </summary>
        public string Subject
        {
            get { return _message.Subject; }
            set { _message.Subject = value; }
        }

        public Message()
        {
            Recipients = new List<Recipient>();
            const string progId = "hMailServer.Message";
            _message = Activator.CreateInstance(Type.GetTypeFromProgID(progId));
        }

        public Message(object oMessage) : this()
        {
            _message = oMessage;
        }

        public List<Recipient> Recipients { get; set; }

        /// <summary>
        ///     Saves the email. If this is a new email, it will be delivered after save.
        ///     Can not use by client
        /// </summary>
        public void Save()
        {
            var log = Logger.CreateLogger();
            log.Debug("Add recipient");
            foreach (Recipient recipient in Recipients)
            {
                _message.AddRecipient(recipient.Name, recipient.Address);
            }
            log.Debug("Send mail");
            _message.Save();
        }

        /// <summary>
        /// Send a email
        /// </summary>
        /// <param name="from">the sender address</param>
        /// <param name="subject">subject</param>
        /// <param name="body">body</param>
        /// <param name="isHtmlBody"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        public static void SendMessage(string from, string subject, string body, bool isHtmlBody, Recipient[] recipients)
        {
            var msg = new Message
            {
                From = from,
                FromAddress = from,
                Subject = subject,
            };
            if (isHtmlBody) msg.HTMLBody = body;
            else msg.Body = body;
            foreach (Recipient recipient in recipients)
            {
                msg.Recipients.Add(recipient);
            }
            msg.Save();
        }
    }
}