using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ozym.Web.Components.Common;
using System.Text.Json;

namespace Ozym.Web.Test
{
    [TestClass]
    public class MenuTest
    {
        private static readonly MenuItem _menuItemsOneLevel = new()
        {
            Caption = "Menu",
            Children = new()
            {
                new() { Caption = "1.0" },
                new() { Caption = "1.1" }
            }
        };

        private static readonly MenuItem _menuItemsTwoLevel = new()
        {
            Caption = "MenuTwoLevel",
            Children = new()
            {
                new() { Caption = "2.0" },
                new() { Caption = "2.1" },
                new() { Caption = "2.2", Children = _menuItemsOneLevel.Children }
            }
        };

        private static readonly MenuItem _menuItemsThreeLevel = new()
        {
            Caption = "MenuThreeLevel",
            Children = new()
            {
                new() { Caption = "3.0" },
                new() { Caption = "3.1" },
                new() { Caption = "3.2", Children = _menuItemsOneLevel.Children },
                new() { Caption = "3.3", Children = _menuItemsTwoLevel.Children }
            }
        };

        [TestMethod]
        [TestCategory("Unit")]
        public void Menu_WithChildren_JsonSerialization_YieldsString()
        {
            var menu = new MenuRoot()
            {
                Children = new()
                {
                    _menuItemsOneLevel,
                    _menuItemsTwoLevel,
                    _menuItemsThreeLevel
                }
            };

            string json = JsonSerializer.Serialize(menu, typeof(MenuRoot), options: new()
            {
                WriteIndented = true
            });


            Assert.IsInstanceOfType(json, typeof(string));
        }
    }
}