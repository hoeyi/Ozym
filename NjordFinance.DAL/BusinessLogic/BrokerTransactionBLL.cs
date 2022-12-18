using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.BusinessLogic
{
    public class BrokerTransactionBLL
    {
        private readonly IList<BrokerTransaction> _brokerTransactions;
        public BrokerTransactionBLL(IList<BrokerTransaction> brokerTransactions)
        {
            if (brokerTransactions is null)
                throw new ArgumentNullException(paramName: nameof(brokerTransactions));

            if (brokerTransactions.Any(x => x.TransactionCode is null))
                throw new InvalidOperationException(message:
                    string.Format(
                        ExceptionString.BrokerTransactionBLL_IncompleteObjectGraph, 
                        nameof(BrokerTransaction.TransactionCode)));

            _brokerTransactions = brokerTransactions;
        }

        public IEnumerable<BrokerTaxLot> GetBrokerTaxLots()
        {
            var taxLots = from x in _brokerTransactions.Where(
                                        x => x.TransactionCode.QuantityEffect > 0)
                          select new BrokerTaxLot
                          {
                              SecurityId = x.SecurityId,
                              AccountId = x.AccountId,
                              AcquisitionDate = x.AcquisitionDate ?? x.TradeDate,
                              CostBasis = x.Amount,
                              Quantity = x.Quantity ?? default
                          };

            return taxLots;
        }
    }
}
