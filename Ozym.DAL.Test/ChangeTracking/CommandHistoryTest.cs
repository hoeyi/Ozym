using System;
using System.Collections.Generic;
using Ozym.ChangeTracking;

namespace Ozym.Test.ChangeTracking
{
    [TestClass]
    [TestCategory("Unit")]
    public class CommandHistoryTest
    {
        [TestMethod]
        public void Collection_AddThenExecute_CurrentEntry_IsAddedValue()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            var expected = new CommandHistoryEntry
            {
                Index = 0,
                Description = "Add 5"
            };

            var observed = commandHistory.Current;

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_AddThenExecute_CanUndo_IsTrue_CanRedo_IsFalse()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            Assert.IsTrue(commandHistory.CanUndo);
            Assert.IsFalse(commandHistory.CanRedo);
        }

        [TestMethod]
        public void Collection_AddThenUndo_CurrentEntry_IsNull()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.UndoCommand();

            Assert.IsNull(commandHistory.Current);
        }

        [TestMethod]
        public void Collection_AddThenUndo_CanUndo_IsFalse()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.UndoCommand();

            Assert.IsFalse(commandHistory.CanUndo);
            Assert.IsTrue(commandHistory.CanRedo);
        }

        [TestMethod]
        public void Collection_AddThenUndoThenRedo_CurrentEntry_IsAddedValue()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.UndoCommand();
            commandHistory.RedoCommand();

            var expected = new CommandHistoryEntry
            {
                Index = 0,
                Description = "Add 5"
            };

            var observed = commandHistory.Current;

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_AddThenRemoveThenUndo_CurrentEntry_IsLastValueAdded()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));
            commandHistory.UndoCommand();

            var expected = new CommandHistoryEntry
            {
                Index = 0,
                Description = "Add 5"
            };

            var observed = commandHistory.Current;

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Collection_AddThenRemoveThenUndo_Count_EqualsTwo()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.AddThenExecute(new RemoveCommand<int>(collection, 5, "Remove 5"));
            
            // Every command added is recorded.
            Assert.AreEqual(2, commandHistory.Count);
            
            commandHistory.UndoCommand();

            // When a command is undone, the collection is unmodified.
            Assert.AreEqual(2, commandHistory.Count);
        }

        [TestMethod]
        public void Collection_WhenIsEmpty_WhenCanUndoIsFalse_UndoCommand_ThrowsInvalidOperationException()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            Assert.IsFalse(commandHistory.CanUndo);
            Assert.ThrowsException<InvalidOperationException>(() => commandHistory.UndoCommand());
        }

        [TestMethod]
        public void Collection_WhenIsEmpty_And_WhenCanRedoIsFalse_RedoCommand_ThrowsInvalidOperationException()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            Assert.IsFalse(commandHistory.CanRedo);
            Assert.ThrowsException<InvalidOperationException>(() => commandHistory.RedoCommand());
        }

        [TestMethod]
        public void Collection_WhenNotEmpty_And_WhenCanUndoIsFalse_UndoCommand_ThrowsInvalidOperationException()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));
            commandHistory.UndoCommand();

            Assert.IsFalse(commandHistory.CanUndo);
            Assert.ThrowsException<InvalidOperationException>(() => commandHistory.UndoCommand());
        }

        [TestMethod]
        public void Collection_WhenNotEmpty_And_WhenCanRedoIsFalse_RedoCommand_ThrowsInvalidOperationException()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            Assert.IsFalse(commandHistory.CanRedo);
            Assert.ThrowsException<InvalidOperationException>(() => commandHistory.RedoCommand());
        }

        [TestMethod]
        public void Collection_WhenNotEmpty_After_Clear_CountEqualsZero()
        {
            var commandHistory = new CommandHistory<int>();
            var collection = new List<int>();

            commandHistory.AddThenExecute(new AddCommand<int>(collection, 5, "Add 5"));

            commandHistory.Clear();

            Assert.AreEqual(0, commandHistory.Count);
        }
    }
}
