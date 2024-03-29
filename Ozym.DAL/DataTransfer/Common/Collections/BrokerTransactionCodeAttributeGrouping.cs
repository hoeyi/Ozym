﻿using Ozym.DataTransfer.Common.Generic;
using System;
using System.Collections.Generic;

namespace Ozym.DataTransfer.Common.Collections
{
    public class BrokerTransactionCodeAttributeGrouping
        : AttributeEntryUnweightedGrouping<BrokerTransactionCodeDto, BrokerTransactionCodeAttributeDto>,
        IAttributeEntryUnweightedGrouping<BrokerTransactionCodeDto, BrokerTransactionCodeAttributeDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrokerTransactionCodeAttributeGrouping"/> 
        /// class.
        /// </summary>
        /// <param name="parentEntity">The <see cref="BrokerCodeAttributeDtoCollection"/> to which entries in the instance apply.</param>
        /// <param name="modelAttribute">The <see cref="ModelAttributeDtoBase"/> that entries in the instance describe.</param>
        /// <param name="effectiveDate">The effective date for entries in the instance.</param>
        public BrokerTransactionCodeAttributeGrouping(
            BrokerTransactionCodeDto parentEntity, ModelAttributeDtoBase modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCodeDto, ICollection<BrokerTransactionCodeAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCodeAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId;

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCodeAttributeDto, decimal> WeightSelector =>
            x => x.PercentWeight;

        /// <inheritdoc/>
        public override BrokerTransactionCodeAttributeDto AddNewEntry()
        {
            BrokerTransactionCodeAttributeDto newEntry = new()
            {
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = DateTime.UtcNow.Date,
                PercentWeight = 1M,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }
    }
}
