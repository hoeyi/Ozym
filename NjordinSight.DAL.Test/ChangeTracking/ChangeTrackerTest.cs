using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.EntityModelService.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NjordinSight.Test.ChangeTracking
{
    [TestClass]
    [TestCategory("Unit")]
    public class ChangeTrackerTest
    {
        [TestMethod]
        public void Collection_AddThenExecute_GetChangesAdded_ReturnsObject()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>();

            changeTracker.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            var changes = changeTracker.GetChanges();

            var expected = 5;
            var observed = changes.Removed.FirstOrDefault();

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_WhenNotEmpty_ItemRemoved_GetChangesRemoved_ReturnsObject()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>() { 5 };

            changeTracker.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));

            var changes = changeTracker.GetChanges();

            var expected = 5;
            var observed = changes.Removed.FirstOrDefault();

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_WhenItemAddedThenUndone_GetChangesAdded_ReturnsEmptyCollection()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>();

            changeTracker.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            changeTracker.UndoCommand();

            var changes = changeTracker.GetChanges();

            Assert.IsFalse(changes.Added.Any());
        }

        [TestMethod]
        public void Collection_WhenItemRemovedThenUndone_GetChangesAdded_ReturnsEmptyCollection()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>() { 5 };

            changeTracker.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));
            changeTracker.UndoCommand();

            var changes = changeTracker.GetChanges();

            Assert.IsFalse(changes.Added.Any());
        }

        [TestMethod]
        public void Collection_WhenItemAddedThenRemoved_GetChanges_ReturnsEmptyCollections()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>();

            changeTracker.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            changeTracker.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));

            var changes = changeTracker.GetChanges();

            var observedAdds = changes.Added;
            var observedRemoves = changes.Removed;

            Assert.IsFalse(observedAdds.Any() && observedRemoves.Any());
        }

        [TestMethod]
        public void Collection_WhenOneItemAdded_OneItemRemoved_GetChanges_ReturnsTwoChanges()
        {
            var changeTracker = new CommandHistory<int>();
            var collection = new List<int>() { 4 };

            changeTracker.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            changeTracker.AddThenExecute(new RemoveCommand<int>(collection, 4, "Remove 4"));

            var changes = changeTracker.GetChanges();

            var observedAdds = changes.Added;
            var observedRemoves = changes.Removed;

            Assert.IsTrue(observedAdds.Count == 1 && observedRemoves.Count == 1);
        }
    }
}
