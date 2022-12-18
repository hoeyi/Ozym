using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.BusinessLogic;
using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Unit")]
    public class BrokerTransactionBLLTest
    {
        [TestMethod]
        public void Constructor_WithRelatedTransactionCodeObject_ReturnsInstance()
        {
            BrokerTransactionBLL brokerTranssactionBLL = new(
                new List<BrokerTransaction>()
                {
                    new ()
                    {
                        AccountId = 0,
                        SecurityId = 0,
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
                });

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
                        AccountId = 0,
                        SecurityId = 0,
                        TradeDate = DateTime.UtcNow.Date.AddDays(new Random().NextDouble() * -1D),
                        AcquisitionDate = DateTime.UtcNow.Date,
                        Quantity = 100M,
                        Amount = 1000M,
                    }
                });

            Assert.ThrowsException<InvalidOperationException>(brokerTranssactionBLLBuilder);
        }

        [TestMethod]
        public void GetAllBrokerTaxLots_HasOpeningTransactions_ReturnsTaxLotCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    // Add transactions that create taxlots
                    SampleTransaction_QuantityEffect_IsAboveZero,
                    SampleTransaction_QuantityEffect_IsAboveZero_FromTradeDate
                });

            var taxLots = brokerTransactionBLL.GetBrokerTaxLots();

            Assert.IsInstanceOfType(taxLots, typeof(IEnumerable<BrokerTaxLot>));
            Assert.IsTrue(taxLots.Count() == 2);
        }

        [TestMethod]
        public void GetAllBrokerTaxLots_HasNoOpeningTransactions_ReturnsEmptyCollection()
        {
            BrokerTransactionBLL brokerTransactionBLL = new(
                new List<BrokerTransaction>()
                {
                    // Add transactions that do not create taxlots
                    SampleTransaction_QuantityEffect_IsZero,
                    SampleTransaction_QuantityEffect_IsBelowZero
                });

            var taxLots = brokerTransactionBLL.GetBrokerTaxLots();

            Assert.IsInstanceOfType(taxLots, typeof(IEnumerable<BrokerTaxLot>));
            Assert.IsTrue(!taxLots.Any());
        }

        [TestMethod]
        public void GetAllBrokerTaxLots_HasOpeningAndNonOpeningTransactions_ReturnsExpectedCollection()
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
                });

            var taxLots = brokerTransactionBLL.GetBrokerTaxLots();

            Assert.IsInstanceOfType(taxLots, typeof(IEnumerable<BrokerTaxLot>));
            Assert.IsTrue(taxLots.Count() == 2);
        }

        /// <summary>
        /// Gets a new sample instance of the <see cref="BrokerTransaction"/> class, representing 
        /// a transaction that creates a tax-lot from a prior purchase or acquisition, i.e., 
        /// TradeDate != AcquisitionDate.
        /// </summary>
        private static BrokerTransaction SampleTransaction_QuantityEffect_IsAboveZero => 
            new()
            {
                AccountId = 0,
                SecurityId = 0,
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
                AccountId = 0,
                SecurityId = 0,
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
                AccountId = 0,
                SecurityId = 0,
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
                AccountId = 0,
                SecurityId = 0,
                Amount = 1000M,
                TransactionCode = new()
                {
                    TransactionCodeId = -1,
                    QuantityEffect = -1
                }
            };
    }
}
