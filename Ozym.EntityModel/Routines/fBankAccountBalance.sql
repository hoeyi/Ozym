/**
name: fBankAccountBalance
description: Calculates the net bank balance for the given account and date.
returns: float
parameters:
  - name: AccountId
    type: int
  - name: Date
    type: date
remarks: Does not attempt to validate whether the account is a bank account.
**/
CREATE FUNCTION [FinanceApp].[fBankAccountBalance]
(
    @AccountId int,
	@Date date
)
RETURNS float
AS
BEGIN
    declare @balance float

    select
       @balance = sum(bt.Amount)
    from FinanceApp.BankTransaction bt
    where 
        bt.AccountId = @AccountId
        and bt.TransactionDate <= @Date

    return @balance
END
