﻿using Aquality.Selenium.Browsers;
using Aquality.Selenium.Tests.Integration.TestApp.TheInternet.Forms;
using NUnit.Framework;
using System;

namespace Aquality.Selenium.Tests.Integration.Elements
{
    internal class LinkTests : UITest
    {
        private readonly RedirectorForm redirectorForm = new RedirectorForm();

        [SetUp]
        public void BeforeTest()
        {
            redirectorForm.Open();
        }

        [Test]
        public void Should_BePossibleTo_Click()
        {
            var link = redirectorForm.RedirectLink;
            link.Click();
            WaitForRedirect();
            Assert.AreEqual(new StatusCodesForm().Url.ToLower(), AqualityServices.Browser.CurrentUrl.ToLower());
        }

        [Test]
        public void Should_BePossibleTo_GetHref()
        {
            var link = redirectorForm.RedirectLink;
            AqualityServices.Browser.GoTo(link.Href);
            WaitForRedirect();
            Assert.AreEqual(new StatusCodesForm().Url.ToLower(), AqualityServices.Browser.CurrentUrl.ToLower());
        }

        private void WaitForRedirect()
        {
            AqualityServices.ConditionalWait.WaitFor(() => AqualityServices.Browser.CurrentUrl.Equals(new StatusCodesForm().Url, StringComparison.OrdinalIgnoreCase));
        }
    }
}
