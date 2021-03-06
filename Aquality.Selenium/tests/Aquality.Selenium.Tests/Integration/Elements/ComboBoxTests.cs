﻿using Aquality.Selenium.Browsers;
using Aquality.Selenium.Tests.Integration.TestApp.TheInternet.Forms;
using NUnit.Framework;

namespace Aquality.Selenium.Tests.Integration.Elements
{
    internal class ComboBoxTests : UITest
    {
        private static readonly string Option2 = "Option 2";

        private readonly DropdownForm dropdownForm = new DropdownForm();

        [SetUp]
        public void BeforeTest()
        {
            dropdownForm.Open();
        }

        [Test]
        public void Should_BePossibleTo_SelectValueByIndex()
        {
            var comboBox = dropdownForm.ComboBox;
            var values = comboBox.Values;
            var itemIndex = values.Count - 1;
            comboBox.SelectByIndex(itemIndex);
            Assert.AreEqual(values[itemIndex], comboBox.SelectedValue);
        }

        [Test]
        public void Should_BePossibleTo_SelectByText()
        {
            var comboBox = dropdownForm.ComboBox;
            var selectedText = comboBox.SelectedText;
            comboBox.SelectByText(Option2);
            AqualityServices.ConditionalWait.WaitFor(() => !selectedText.Equals(comboBox.SelectedText));
            Assert.AreEqual(comboBox.Texts[2], comboBox.JsActions.GetSelectedText());
        }

        [Test]
        public void Should_BePossibleTo_SelectByValue()
        {
            var comboBox = dropdownForm.ComboBox;
            var selectedText = comboBox.SelectedText;
            comboBox.SelectByValue("2");
            AqualityServices.ConditionalWait.WaitFor(() => !selectedText.Equals(comboBox.SelectedText));
            Assert.AreEqual(comboBox.Texts[2], comboBox.JsActions.GetSelectedText());
        }

        [Test]
        public void Should_BePossibleTo_SelectByContainingText()
        {
            var comboBox = dropdownForm.ComboBox;
            comboBox.SelectByContainingText("1");
            Assert.AreEqual(comboBox.Texts[1], comboBox.SelectedText);
        }

        [Test]
        public void Should_BePossibleTo_SelectByContainingValue()
        {
            var comboBox = dropdownForm.ComboBox;
            comboBox.SelectByContainingValue("2");
            Assert.AreEqual(comboBox.Values[2], comboBox.SelectedValue);
        }

        [Test]
        public void Should_BePossibleTo_GetTextsViaJsActions()
        {
            var comboBox = dropdownForm.ComboBox;
            CollectionAssert.AreEqual(comboBox.Texts, comboBox.JsActions.GetTexts());
        }

        [Test]
        public void Should_BePossibleTo_GetSelectedTextViaJsActions()
        {
            var comboBox = dropdownForm.ComboBox;
            Assert.AreEqual(comboBox.SelectedText, comboBox.JsActions.GetSelectedText());
        }

        [Test]
        public void Should_BePossibleTo_SelectValueViaJsActions()
        {
            var comboBox = dropdownForm.ComboBox;
            comboBox.JsActions.SelectValueByText(Option2);
            Assert.AreEqual(comboBox.SelectedText, Option2);
        }
    }
}
