using NjordinSight.BusinessLogic.Brokerage;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordinSight.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Unit")]
    public class BrokerTransactionBLLTest
    {
        private static readonly List<BrokerTransactionCode> _exampleTransactionCodes = new()
        {
            new()
            {
                DisplayName = "QuantityEffect-Zero",
                TransactionCodeId = 0,
                QuantityEffect = 0
            },
            new()
            {
                DisplayName = "QuantityEffect-MinusOne",
                TransactionCodeId = -1,
                QuantityEffect = -1
            },
            new()
            {
                DisplayName = "QuantityEffect-PlusOne",
                TransactionCodeId = -1,
                QuantityEffect = 1
            }
        };

        private static readonly Account _exampleAccount = new()
        {
            AccountId = -1
        };

        [TestMethod]
        public void Constructor_WithRelatedTransactionCodeObject_ReturnsInstance()
        {
            BrokerTransactionBLL brokerTranssactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new ()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        TradeDate = DateTime.UtcNow.Date.AddDays(new Random().NextDouble() * -1D),
                        AcquisitionDate = DateTime.UtcNow.Date,
                        Quantity = 100M,
                        Amount = 1000M,
                        TransactionCode = new()
                        {
                            TransactionCodeId = 0,
                            QuantityEffect = 0
                        }
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);

            Assert.IsInstanceOfType(brokerTranssactionBLL, typeof(BrokerTransactionBLL));
        }

        [TestMethod]
        public void Constructor_WithoutRelatedTrasnactionCodeObject_ThrowInvalidOperationException()
        {
            static BrokerTransactionBLL brokerTranssactionBLLBuilder() => new(
                new List<BrokerTransaction>()
                {
                    new ()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        TradeDate = DateTime.UtcNow.Date.AddDays(new Random().NextDouble() * -1D),
                        AcquisitionDate = DateTime.UtcNow.Date,
                        Quantity = 100M,
                        Amount = 1000M,
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);


            Assert.ThrowsException<InvalidOperationException>(brokerTranssactionBLLBuilder);
        }

        [TestMethod]
        public void GetAllTaxLots_HasOnlyOpeningActivity_ReturnsTaxLotCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    // Add transactions that create taxlots
                    SampleTransaction_QuantityEffect_IsAboveZero,
                    SampleTransaction_QuantityEffect_IsAboveZero_FromTradeDate
                },
                _exampleTransactionCodes,
                _exampleAccount);

            TaxLotStatus include = TaxLotStatus.Open | TaxLotStatus.Closed;

            var taxLots = brokerTransactionBLL.GetTaxLots(include);

            Assert.IsTrue(taxLots.Count() == 2);
        }

        [TestMethod]
        public void GetAllTaxLots_HasOnlyNonAffectingActivity_ReturnsEmptyCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    // Add transactions that do not create taxlots
                    SampleTransaction_QuantityEffect_IsZero,
                    SampleTransaction_QuantityEffect_IsBelowZero
                },
                _exampleTransactionCodes,
                _exampleAccount);

            var taxLots = brokerTransactionBLL.GetTaxLots(TaxLotStatus.Open | TaxLotStatus.Closed);

            Assert.IsTrue(!taxLots.Any());
        }

        [TestMethod]
        public void GetAllTaxLots_HasOpeningAndNonAffectingActivity_ReturnsExpectedCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    // Add transactions that create taxlots
                    SampleTransaction_QuantityEffect_IsAboveZero,
                    SampleTransaction_QuantityEffect_IsAboveZero_FromTradeDate,

                    // Add transactions that do not create taxlots
                    SampleTransaction_QuantityEffect_IsZero,
                    SampleTransaction_QuantityEffect_IsBelowZero
                },
                _exampleTransactionCodes,
                _exampleAccount);

            var taxLots = brokerTransactionBLL.GetTaxLots(TaxLotStatus.Open | TaxLotStatus.Closed);

            Assert.IsTrue(taxLots.Count() == 2);
        }

        [TestMethod]
        public void GetOpenTaxLots_HasOnlyOpeningActivity_ReturnsExpectedCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    SampleTransaction_QuantityEffect_IsAboveZero,
                    SampleTransaction_QuantityEffect_IsAboveZero_FromTradeDate
                },
                _exampleTransactionCodes,
                _exampleAccount);

            var taxLots = brokerTransactionBLL.GetTaxLots(TaxLotStatus.Open);

            Assert.IsTrue(taxLots.Count() == 2);
        }

        [TestMethod]
        public void GetOpenTaxLots_SingleTaxLot_HasPartialClosure_ReturnsExpectedTaxLot()
        {
            // Set up the test data and instance. Use variable for tax-lot acquisition date to
            // ensure tests run close to UTC midnight do not corrupt the test.
            var taxLotDate = DateTime.UtcNow.Date;

            // Create test instance. Both BrokerTransaction records will have the same
            // AccountId, SecurityId, and TransactionId of the opening action must match 
            // the TaxLotId of the closing action.
            BrokerTransactionBLL transactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new()
                    {
                        TransactionId = 0,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 1000,
                        AcquisitionDate = taxLotDate,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 10,
                        Amount = 500,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -2,
                            QuantityEffect = -1
                        },
                        TaxLotId = 0
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);

            // Define the expected tax lot, which:
            // - Lowers the unclosed quantity by 10
            // - Lowers the uncloseed cost basis by 100
            var expectedTaxLot = new BrokerTaxLot()
            {
                TaxLotId = 0,
                AccountId = -1,
                SecurityId = -1,
                AcquisitionDate = taxLotDate,
                OriginalCostBasis = 1000,
                OriginalQuantity = 100,
                UnclosedQuantity = 90
            };

            // Execute the test method.
            var taxLots = transactionBLL.GetTaxLots(TaxLotStatus.Open);

            // Confirm the count is correct.
            Assert.IsTrue(taxLots.Count() == 1);

            var observedTaxLot = taxLots.First();

            // Confirm the return tax lot matches the expected tax lot.
            Assert.AreEqual(expectedTaxLot, observedTaxLot);

            // Confirm the calculated unclosed cost basis matches the expected value.
            Assert.AreEqual(900, observedTaxLot.UnclosedCostBasis);
        }

        [TestMethod]
        public void GetOpenTaxLots_SingleTaxLot_HasCompleteClosure_ReturnsEmptyCollection()
        {
            // Set up the test data and instance. Use variable for tax-lot acquisition date to
            // ensure tests run close to UTC midnight do not corrupt the test.
            var taxLotDate = DateTime.UtcNow.Date;

            // Create test instance. Both BrokerTransaction records will have the same
            // AccountId, SecurityId, and TransactionId of the opening action must match 
            // the TaxLotId of the closing action. Quantity opened equals quantity closed.
            BrokerTransactionBLL transactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new()
                    {
                        TransactionId = 0,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 1000,
                        AcquisitionDate = taxLotDate,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 500,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -2,
                            QuantityEffect = -1
                        },
                        TaxLotId = 0
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);

            // Execute the test method.
            var taxLots = transactionBLL.GetTaxLots(TaxLotStatus.Open);

            // Confirm the collection is empty.
            Assert.IsTrue(!taxLots.Any());
        }

        [TestMethod]
        public void GetClosedTaxLots_SingleTaxLot_HasCompleteClosure_ReturnsExpectedTaxLot()
        {
            // Set up the test data and instance. Use variable for tax-lot acquisition date to
            // ensure tests run close to UTC midnight do not corrupt the test.
            var taxLotDate = DateTime.UtcNow.Date;

            // Create test instance. Both BrokerTransaction records will have the same
            // AccountId, SecurityId, and TransactionId of the opening action must match 
            // the TaxLotId of the closing action.
            BrokerTransactionBLL transactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new()
                    {
                        TransactionId = 0,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 1000,
                        AcquisitionDate = taxLotDate,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 500,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -2,
                            QuantityEffect = -1
                        },
                        TaxLotId = 0
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);

            // Define the expected tax lot, which:
            // - Lowers the unclosed quantity by 10
            // - Lowers the uncloseed cost basis by 100
            var expectedTaxLot = new BrokerTaxLot()
            {
                TaxLotId = 0,
                AccountId = -1,
                SecurityId = -1,
                AcquisitionDate = taxLotDate,
                OriginalCostBasis = 1000,
                OriginalQuantity = 100,
                UnclosedQuantity = 0
            };

            // Execute the test method.
            var taxLots = transactionBLL.GetTaxLots(TaxLotStatus.Closed);

            // Confirm the count is correct.
            Assert.IsTrue(taxLots.Count() == 1);

            var observedTaxLot = taxLots.First();

            // Confirm the return tax lot matches the expected tax lot.
            Assert.AreEqual(expectedTaxLot, observedTaxLot);

            // Confirm the calculated unclosed cost basis matches the expected value.
            Assert.AreEqual(0, observedTaxLot.UnclosedCostBasis);
        }

        [TestMethod]
        public void GetClosedTaxLots_SingleTaxLot_HasPartialClosure_ReturnsEmptyCollection()
        {
            // Set up the test data and instance. Use variable for tax-lot acquisition date to
            // ensure tests run close to UTC midnight do not corrupt the test.
            var taxLotDate = DateTime.UtcNow.Date;

            // Create test instance. Both BrokerTransaction records will have the same
            // AccountId, SecurityId, and TransactionId of the opening action must match 
            // the TaxLotId of the closing action. Quantity opened is greater than quantity closed.
            BrokerTransactionBLL transactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new()
                    {
                        TransactionId = 0,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 1000,
                        AcquisitionDate = taxLotDate,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 10,
                        Amount = 500,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -2,
                            QuantityEffect = -1
                        },
                        TaxLotId = 0
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);

            // Execute the test method.
            var taxLots = transactionBLL.GetTaxLots(TaxLotStatus.Closed);

            // Confirm the collection is empty.
            Assert.IsTrue(!taxLots.Any());
        }

        [TestMethod]
        public void PostAllocation_AgainstTwoLots_Returns()
        {
            // Create test instance. Both BrokerTransaction records will have the same
            // AccountId, SecurityId, and TransactionId of the opening action must match 
            // the TaxLotId of the closing action. Quantity opened is greater than quantity closed.
            BrokerTransactionBLL transactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new()
                    {
                        TransactionId = 10,
                        TransactionCodeId = -1,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 100,
                        Amount = 1000,
                        AcquisitionDate = DateTime.Now.AddDays(-21).AddYears(-1),
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        TransactionId = 11,
                        AccountId = -1,
                        SecurityId = -1,
                        Quantity = 250,
                        Amount = 1375,
                        AcquisitionDate = DateTime.Now.AddDays(-7),
                        TransactionCode = new()
                        {
                            TransactionCodeId = -1,
                            QuantityEffect = 1
                        }
                    },
                    new()
                    {
                        TransactionCodeId = -2,
                        AccountId = -1,
                        SecurityId = -1,
                        TradeDate = DateTime.Now,
                        Quantity = 75,
                        Amount = 500,
                        TransactionCode = new()
                        {
                            TransactionCodeId = -2,
                            QuantityEffect = -1
                        },
                        TaxLotId = 0
                    }
                },
                _exampleTransactionCodes,
                _exampleAccount);


            var allocationTable = new AllocationInstructionTable()
            {
                Instructions = transactionBLL.GetTaxLots(taxLotStatus: TaxLotStatus.Open)
                    .Where(a => a.SecurityId == -1)
                    .Select(x => new AllocationInstructionRow()
                    {
                        TaxLot = x,
                        ClosingQuantity = 0M
                    })
                    .ToList(),
                AvailableTaxLots = transactionBLL
                    .GetTaxLots(taxLotStatus: TaxLotStatus.Open)
                    .Where(a => a.SecurityId == -1)
                    .ToList(),
                Transaction = transactionBLL.Entries.Last()
            };

            allocationTable.Instructions[0].ClosingQuantity = 25M;
            allocationTable.Instructions[1].ClosingQuantity = 50M;

            var response = transactionBLL.PostAllocation(allocationTable);

            Assert.IsTrue(response.UpdateStatus == TransactionUpdateStatus.Completed);

        }
        
        /// <summary>
        /// Gets a new sample instance of the <see cref="BrokerTransaction"/> class, representing 
        /// a transaction that creates a tax-lot from a prior purchase or acquisition, i.e., 
        /// TradeDate != AcquisitionDate.
        /// </summary>
        private static BrokerTransaction SampleTransaction_QuantityEffect_IsAboveZero => 
            new()
            {
                AccountId = -1,
                SecurityId = -1,
                TradeDate = DateTime.UtcNow.Date.AddDays(new Random().NextDouble() * -1D),
                AcquisitionDate = DateTime.UtcNow.Date,
                Quantity = 100M,
                Amount = 1000M,
                TransactionCode = new()
                {
                    TransactionCodeId = -1,
                    QuantityEffect = 1
                }
            };

        /// <summary>
        /// Gets a new sample instance of the <see cref="BrokerTransaction"/> class, representing 
        /// a transaction that creates a tax-lot from a purchase, i.e., TradeDate == AcquisitionDate.
        /// </summary>
        private static BrokerTransaction SampleTransaction_QuantityEffect_IsAboveZero_FromTradeDate 
            => new()
            {
                AccountId = -1,
                SecurityId = -1,
                TradeDate = DateTime.UtcNow.Date,
                Quantity = 100M,
                Amount = 1000M,
                TransactionCode = new()
                {
                    TransactionCodeId = -1,
                    QuantityEffect = 1
                }
            };

        /// <summary>
        /// Gets a new sample instance of the <see cref="BrokerTransaction"/> class, representing 
        /// a transaction that has no effect on tax-lots.
        /// </summary>
        private static BrokerTransaction SampleTransaction_QuantityEffect_IsZero => 
            new()
            {
                AccountId = -1,
                SecurityId = -1,
                Amount = 1000M,
                TransactionCode = new()
                {
                    TransactionCodeId = -1,
                    QuantityEffect = 0
                }
            };

        /// <summary>
        /// Gets a new sample instance of the <see cref="BrokerTransaction"/> class, representing 
        /// a transaction that has a closing effect on tax lots.
        /// </summary>
        private static BrokerTransaction SampleTransaction_QuantityEffect_IsBelowZero => 
            new()
            {
                AccountId = -1,
                SecurityId = -1,
                Quantity = 10M,
                Amount = 1000M,
                TransactionCode = new()
                {
                    TransactionCodeId = -1,
                    QuantityEffect = -1
                }
            };
    }
}
