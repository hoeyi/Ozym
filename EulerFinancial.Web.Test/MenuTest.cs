﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerFinancial.Web.Components.Shared;
using System.Text.Json;

namespace EulerFinancial.Test.Web
{
    [TestClass]
    public class MenuTest
    {
        private static readonly AppMenuItem _menuItemsOneLevel = new()
        {
            Caption = "Menu",
            Children = new()
            {
                { 0, new() { Caption = "1.0" } },
                { 1, new() { Caption = "1.1" } }
            }
        };

        private static readonly AppMenuItem _menuItemsTwoLevel = new()
        {
            Caption = "MenuTwoLevel",
            Children = new()
            {
                { 0, new() { Caption = "2.0" } },
                { 1, new() { Caption = "2.1" } },
                { 2, new() { Caption = "2.2", Children = _menuItemsOneLevel.Children } }
            }
        };

        private static readonly AppMenuItem _menuItemsThreeLevel = new()
        {
            Caption = "MenuThreeLevel",
            Children = new()
            {
                { 0, new() { Caption = "3.0" } },
                { 1, new() { Caption = "3.1" } },
                { 2, new() { Caption = "3.2", Children = _menuItemsOneLevel.Children } },
                { 3, new() { Caption = "3.3", Children = _menuItemsTwoLevel.Children } }
            }
        };

        [TestMethod]
        public void Menu_WithChildren_JsonSerialization_YieldsString()
        {
            var menu = new Menu()
            {
                Children = new()
                {
                    { 0, _menuItemsOneLevel },
                    { 1, _menuItemsTwoLevel },
                    { 2, _menuItemsThreeLevel }
                }
            };

            string json = JsonSerializer.Serialize(menu, typeof(Menu), options: new()
            {
                WriteIndented = true
            });


            Assert.IsInstanceOfType(json, typeof(string));
        }

        //[TestMethod]
        //public void Menu_WithChildren__JsonDeserialization_YieldsMenu()
        //{
        //}
    }
}