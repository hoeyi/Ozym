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
    }
}
