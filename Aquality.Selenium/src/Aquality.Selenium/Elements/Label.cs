﻿using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;

namespace Aquality.Selenium.Elements
{
    /// <summary>
    /// Defines Label UI element.
    /// </summary>
    public class Label : Element, ILabel
    {
        protected internal Label(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        protected override string ElementType => throw new NotImplementedException();
    }
}
