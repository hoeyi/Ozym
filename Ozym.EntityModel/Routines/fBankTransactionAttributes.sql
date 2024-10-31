/**
name: fBankTransactionAttributes
description: Returns the set of bank transaction code-level attribute effective date ranges.
returns: table of effective bank transaction attributes as of the given date.
parameters:
  - name: AttributeId
    type: int
**/
CREATE FUNCTION [FinanceApp].[fBankTransactionAttributes]
(
    @AttributeId int
)
RETURNS TABLE AS RETURN
(
    select
        [TransactionCodeID] = a0.TransactionCodeID,
        [AttributeID] = m.AttributeID,
        [AttributeName] = m.DisplayName,
        [AttributeValue] = m0.DisplayName,
        [AttributeValueOrder] = m0.DisplayOrder,
        [AttributeMemberID] = a0.AttributeMemberID,
        [PercentWeight] = a0.[Weight],
        [EffectiveFromDate] = a0.EffectiveDate,
        [EffectiveToDate] = isnull(dateadd(day, -1, n.EffectiveDate), getdate())
    from FinanceApp.BankTransactionCodeAttributeMemberEntry a0
    join FinanceApp.ModelAttributeMember m0 on m0.AttributeMemberID = a0.AttributeMemberID
    join FinanceApp.ModelAttribute m on m.AttributeID = m0.AttributeID
    -- determine the next effective date
    outer apply (
        select top 1
            a1.EffectiveDate
        from FinanceApp.BankTransactionCodeAttributeMemberEntry a1
        join FinanceApp.ModelAttributeMember m1 on m1.AttributeMemberID = a1.AttributeMemberID
        where a1.TransactionCodeID = a0.TransactionCodeID
        and m1.AttributeID = m0.AttributeID
        and a1.EffectiveDate > a0.EffectiveDate
        order by a1.EffectiveDate asc
    ) n
    where m.AttributeId = @AttributeId
)
