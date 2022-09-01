using NjordFinance.Model.Annotations;
using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model.ViewModel.Generic;
using System.Linq.Expressions;

namespace NjordFinance.Model.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    /// <summary>
    /// Represents a collection of <see cref="InvestmentStrategyTarget"/> instances with the same 
    /// <see cref="InvestmentStrategy" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class InvestmentModelTargetViewModel
        : AttributeEntryGrouping<InvestmentStrategy, InvestmentStrategyTarget>
    {
        internal InvestmentModelTargetViewModel(
            InvestmentStrategy parentStrategy, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(parentStrategy, modelAttribute, effectiveDate)
        {
        }

        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        protected override Func<InvestmentStrategy, ICollection<InvestmentStrategyTarget>> ParentEntryMemberFor 
            => x => x.InvestmentStrategyTargets;

        protected override Func<InvestmentStrategyTarget, bool> EntrySelector => x => 
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId) 
                && x.EffectiveDate == EffectiveDate;

        public override InvestmentStrategyTarget AddNewEntry()
        {
            InvestmentStrategyTarget newEntry = new()
            {
                InvestmentStrategyId = ParentObject.InvestmentStrategyId,
                EffectiveDate = EffectiveDate,
                Weight = default,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    AttributeId = ParentAttribute.AttributeId,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }

        protected override bool UpdateEffectiveDate(
            InvestmentStrategyTarget entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}