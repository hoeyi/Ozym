using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozym.EntityModel;

namespace Ozym.Test.Context
{
    [TestClass]
    [TestCategory("Unit")]
    public class MigrationExtesnionsTest
    {
        [TestMethod]
        public void AddUserDefinedFunctions()
        {
            // Arrange
            var builder = new MigrationBuilder("SqlServer");

            // Act
            builder.AddUserDefinedFunctions();

            // Assert
            // pass
        }
    }
}
