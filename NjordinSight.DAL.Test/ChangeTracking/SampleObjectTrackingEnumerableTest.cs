using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.ChangeTracking;
using NjordinSight.DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.ChangeTracking
{
    [TestClass]
    [TestCategory("Unit")]
    public class SampleObjectTrackingEnumerableTest : TrackingEnumerableTest<SampleObject>
    {
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
        public void After_Update_HasChanges_Equals_True()
        {
            // Arrange
            var tracking = new TrackingEnumerable<SampleObject>(
                new List<SampleObject>()
                {
                    new SampleObject()
                });

            // Act
            tracking[0].SampleProperty = "New value";

            // Assert
            Assert.IsTrue(tracking.HasChanges);
        }
    }
}
