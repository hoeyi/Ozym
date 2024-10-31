/**
name: fAccountAttributes
description: Returns the set of account-level attributes effective on the given date.
returns: table of effective account attributes as of the given date.
parameters:
  - name: AttributeId
    type: int
  - name: AsOfDate
    type: date
**/
CREATE FUNCTION [FinanceApp].[fAccountAttributes]
(
    @AttributeId int,
    @AsOfDate date
)
RETURNS TABLE AS RETURN
(
    select
        [AccountObjectID] = a0.AccountObjectID,
        [AttributeID] = m.AttributeID,
        [AttributeName] = m.DisplayName,
        [AttributeValue] = m0.DisplayName,
        [AttributeValueOrder] = m0.DisplayOrder,
        [AttributeMemberID] = a0.AttributeMemberID,
        [PercentWeight] = a0.[Weight],
        [EffectiveFromDate] = a0.EffectiveDate,
        [EffectiveToDate] = isnull(dateadd(day, -1, n.EffectiveDate), getdate())
    from FinanceApp.AccountAttributeMemberEntry a0
    join FinanceApp.ModelAttributeMember m0 on m0.AttributeMemberID = a0.AttributeMemberID
    join FinanceApp.ModelAttribute m on m.AttributeID = m0.AttributeID
    -- determine the next effective date
    outer apply (
        select top 1
            a1.EffectiveDate
        from FinanceApp.AccountAttributeMemberEntry a1
        join FinanceApp.ModelAttributeMember m1 on m1.AttributeMemberID = a1.AttributeMemberID
        where a1.AccountObjectID = a0.AccountObjectID
        and m1.AttributeID = m0.AttributeID
        and a1.EffectiveDate > a0.EffectiveDate
        order by a1.EffectiveDate asc
    ) n
    where m.AttributeID = @AttributeId
    and a0.EffectiveDate <= @AsOfDate
    and (n.EffectiveDate is null or @AsOfDate < n.EffectiveDate)
)
