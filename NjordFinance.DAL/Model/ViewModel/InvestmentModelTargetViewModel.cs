using NjordFinance.ModelMetadata.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Represents a collection of <see cref="InvestmentStrategyTarget"/> instances with the same 
    /// <see cref="InvestmentStrategy" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class InvestmentModelTargetViewModel
        : AttributeEntryCollectionViewModel<InvestmentStrategyTarget, InvestmentStrategy>
    {
        public InvestmentModelTargetViewModel(
            InvestmentStrategy parentStrategy, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(parentStrategy, modelAttribute, effectiveDate)
        {
            MemberEntries.AddRange(
                parentStrategy.InvestmentStrategyTargets.Where(a => 
                    a.AttributeMember.AttributeId == modelAttribute.AttributeId &&
                    a.EffectiveDate == EffectiveDate));
        }

        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        public override InvestmentStrategyTarget[] ToEntities() =>
            MemberEntries.Select(
                s => new InvestmentStrategyTarget()
                {
                    AttributeMemberId = s.AttributeMemberId,
                    InvestmentStrategyId = ParentObject.InvestmentStrategyId,
                    EffectiveDate = EffectiveDate,
                    Weight = s.Weight
                })
            .ToArray();
    }
}