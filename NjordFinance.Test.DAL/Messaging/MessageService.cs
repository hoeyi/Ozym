﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Messaging;

namespace NjordFinance.Test.Messaging
{
    [TestClass]
    public class MessageServiceTest
    {
        [TestMethod]
        public void MessageSerivce_MessagePublished_InvokesDelegate()
        {
            // Set-up
            IMessageService service = new MessageService()
            {
            };

            static void Service_ContentPublished(object sender, Message e)
            {
                Assert.IsTrue(e is not null);
            }

            service.ContentPublished += Service_ContentPublished;

            service.Publish("Header", "Body message.");
        }

    }
}