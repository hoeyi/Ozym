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
    /// Represents a collection of <see cref="InvestmentStrategyTarget"/> with the same 
    /// strategy, model attribute, and effective date.
    /// </summary>
    public class InvestmentPlanTargetViewModel
        : AttributeEntryCollectionViewModel<InvestmentStrategyTarget, InvestmentStrategy>
    {
        public InvestmentPlanTargetViewModel(
            InvestmentStrategy parentStrategy, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(parentStrategy, modelAttribute, effectiveDate)
        {
            MemberEntries.AddRange(
                parentStrategy.InvestmentStrategyTargets.Where(a => 
                    a.AttributeMember.AttributeId == modelAttribute.AttributeId &&
                    a.EffectiveDate == EffectiveDate));
        }

        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        public IEnumerable<InvestmentStrategyTarget> CurrentMemberEntries =>
            MemberEntries.Where(a => a.EffectiveDate <= DateTime.Now);
        
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