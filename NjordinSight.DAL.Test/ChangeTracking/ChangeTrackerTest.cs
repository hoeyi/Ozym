using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.EntityModelService.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.ChangeTracking
{
    [TestClass]
    [TestCategory("Unit")]
    public class ChangeTrackerTest
    {
        [TestMethod]
        public void Collection_AddThenExecute_Added_ReturnsObject()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>();

            changeTracker.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            var expected = 5;
            var observed = changeTracker.Added().First();

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_WhenNotEmpty_ItemRemoved_Removed_ReturnsObject()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>() { 5 };

            changeTracker.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));

            var expected = 5;
            var observed = changeTracker.Removed().First();

            Assert.AreEqual(expected, observed);
        }

    }
}
