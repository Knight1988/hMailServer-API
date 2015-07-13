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
    }
}
