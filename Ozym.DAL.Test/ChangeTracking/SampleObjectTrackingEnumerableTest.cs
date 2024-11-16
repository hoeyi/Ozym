using Ozym.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozym.Test.ChangeTracking
{
    [TestClass]
    [TestCategory("Unit")]
    public class SampleObjectTrackingEnumerableTest : TrackingEnumerableTest<SampleObject>
    {
        [TestMethod]
        public override void After_Add_GetChanges_Returns_AddedItem()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(new List<SampleObject>() { new() });

            // Act
            var added = new SampleObject();
            tracking.Add(added);
            var changes = tracking.GetChanges().ToList();

            // Assert
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(added, changes.First().Item1);
            Assert.IsTrue(changes.First().Item2 == TrackingState.Added);
        }

        [TestMethod]
        public void After_Add_HasChanges_Equals_True()
        {
            After_Add_HasChanges_Equals_True_Helper(() => new SampleObject());
        }

        [TestMethod]
        public void After_Init_HasChanges_Equals_False()
        {
            After_Init_HasChanges_Equals_False_Helper(() => new SampleObject());
        }

        [TestMethod]
        public override void After_Remove_GetChanges_Returns_RemovedItem()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(new List<SampleObject>() { new() });

            // Act
            var removed = tracking[0];
            tracking.Remove(removed);
            var changes = tracking.GetChanges().ToList();

            // Assert
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(removed, changes.First().Item1);
            Assert.IsTrue(changes.First().Item2 == TrackingState.Removed);

        }

        [TestMethod]
        public void After_Remove_HasChanges_Equals_True()
        {
            After_Remove_HasChanges_Equals_True_Helper(() => new SampleObject());
        }

        [TestMethod]
        public override void After_Reset_HasChanges_Equals_False()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(
                new List<SampleObject>() { new(), new() });

            var newList = new List<SampleObject>() { new(), new() };

            // Act
            tracking[0].SampleProperty = "New value";

            // TODO: Review this for improvement. The goal is to ensure HasChanges is not already 
            // false, else our assertion will be true, but still not expected behavior.
            if (tracking.HasChanges)
                tracking.ResetList(newList);

            else
                throw new InvalidOperationException(
                    $"Test assumption failed. {nameof(tracking.HasChanges)} was false.");

            // Assert
            Assert.IsFalse(tracking.HasChanges);
        }

        [TestMethod]
        public override void After_Update_GetChanges_Returns_UpdatedItem()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(new List<SampleObject>() { new() });

            // Act
            var updated = tracking[0];
            updated.SampleProperty = "New Value";
            var changes = tracking.GetChanges().ToList();

            // Assert
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(updated, changes.First().Item1);
            Assert.IsTrue(changes.First().Item2 == TrackingState.Updated);
        }

        [TestMethod]
        public void After_Update_HasChanges_Equals_True()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(
                new List<SampleObject>()
                {
                    new()
                });

            // Act
            tracking[0].SampleProperty = "New value";

            // Assert
            Assert.IsTrue(tracking.HasChanges);
        }
    }
}
