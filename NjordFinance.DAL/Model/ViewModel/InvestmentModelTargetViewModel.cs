using NjordFinance.Model.Annotations;
using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model.ViewModel.Generic;

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
        public InvestmentModelTargetViewModel(
            InvestmentStrategy parentStrategy, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(parentStrategy, modelAttribute, effectiveDate)
        {
        }
        
        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        protected override IEnumerable<InvestmentStrategyTarget> SelectEntries(
            InvestmentStrategy parentEntity, ModelAttribute parentAttribute, DateTime effectiveDate) 
            => parentEntity.InvestmentStrategyTargets.Where(t =>
                t.AttributeMember.AttributeId == parentAttribute.AttributeId &&
                t.EffectiveDate == effectiveDate);
    }
}