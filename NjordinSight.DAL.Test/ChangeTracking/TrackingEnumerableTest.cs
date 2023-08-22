using NjordinSight.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NjordinSight.Test.ChangeTracking
{
    [TestCategory("Unit")]
    public abstract class TrackingEnumerableTest<T>
        where T : class, INotifyPropertyChanged
    {
        public void After_Add_HasChanges_Equals_True_Helper(Func<T> constructor)
        {
            // Arrange
            #pragma warning disable IDE0028 // Simplify collection initialization
            var tracking = new TrackingEnumerable<T>();

            // Act
            tracking.Add(constructor.Invoke());
            #pragma warning restore IDE0028 // Simplify collection initialization

            // Assert
            Assert.IsTrue(tracking.HasChanges);
        }

        public void After_Init_HasChanges_Equals_False_Helper(Func<T> constructor)
        {
            // Arrange
            var tracking = new TrackingEnumerable<T>(new List<T>(){ constructor.Invoke() });

            // Assert
            Assert.IsFalse(tracking.HasChanges);
        }

        public void After_Remove_HasChanges_Equals_True_Helper(Func<T> constructor)
        {
            // Arrange
            var tracking = new TrackingEnumerable<T>(new List<T> { constructor.Invoke() });

            // Act
            tracking.Remove(tracking[0]);

            // Assert
            Assert.IsTrue(tracking.HasChanges);
        }

        public abstract void After_Reset_HasChanges_Equals_False();

        public abstract void After_Add_GetChanges_Returns_AddedItem();

        public abstract void After_Update_GetChanges_Returns_UpdatedItem();

        public abstract void After_Remove_GetChanges_Returns_RemovedItem();
    }
}
