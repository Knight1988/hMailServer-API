using System;
using hMailServerAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hMailServerTests
{
    [TestClass]
    public class ScenarioTests
    {
        [TestMethod]
        public void SendingAMessage()
        {
            Message.SendMessage("test1@mt2015.com", "Test Subject", "Test body", false, new[]
            {
                new Recipient(){Address = "test1@mt2015.com", Name = "Test 1"},
            });
        }

        [TestMethod]
        public void ValidatePasswordTests()
        {
            var username = "test@knight1988.no-ip.info";
            var password = "1234";
            var domainName = username.Split('@')[1];

            var app = new ServerApplication("Administrator", "fantasy8");
            var domain = app.Domains.GetItemByName(domainName);

            var acc = domain.Accounts.GetItemByAddress(username);
            var valid = acc.ValidatePassword(password);

            Assert.AreEqual(true, valid);
        }
    }
}
