/**
name: pBankTransactions
description: Returns the bank transactions for the given account(s) and date range.
returns: table descr
parameters:
  - name: AccountIds
    type: nvarhcar(100)
  - name: FromDate
    type: date
  - name: ThruDate
    type: date
  - name: AttributeId1
    type: int
  - name: AttributeId2
    type: int
remarks: AttributeId1 and AttributeId2 are optional parameters. If not provided , the corresponding attribute columns will be null.
**/
CREATE PROCEDURE [FinanceApp].[pReportBankTransactions] 
(
    @AccountIds nvarchar(100),
    @FromDate date,
    @ThruDate date,
    @AttributeId1 int = null,
    @AttributeId2 int = null
)
AS
BEGIN
    select
        [AccountId] = bt.AccountID,
        [AccountCode] = a.AccountObjectCode,
        [AccountName] = a.ObjectDisplayName,
        [TransactionID] = bt.TransactionID,
        [TransactionCode] = btc.TransactionCode,
        [DisplayName] = btc.DisplayName,
        [TransactionDate] = bt.TransactionDate,
        [Amount] = bt.Amount,
        [Comment] = bt.Comment,
        [Attribute1Name] = bt0.AttributeName,
        [Attribute1Value] = bt0.AttributeValue,
        [Attribute2Name] = bt1.AttributeName,
        [Attribute2Value] = bt1.AttributeValue
    from FinanceApp.BankTransaction bt
    join FinanceApp.BankTransactionCode btc on btc.TransactionCodeID = bt.TransactionCodeID
    join FinanceApp.AccountObject a on a.AccountObjectID = bt.AccountID
    left join FinanceApp.fBankTransactionAttributes(@AttributeID1) bt0 on 
        bt0.TransactionCodeID = bt.TransactionCodeID
        and bt.TransactionDate between bt0.EffectiveFromDate and bt0.EffectiveToDate
    left join FinanceApp.fBankTransactionAttributes(@AttributeID2) bt1 on 
        bt1.TransactionCodeID = bt.TransactionCodeID
        and bt.TransactionDate between bt1.EffectiveFromDate and bt1.EffectiveToDate
    and bt.TransactionDate between @FromDate and @ThruDate
    order by bt.AccountID asc, bt.TransactionDate asc, bt0.AttributeValueOrder asc, bt1.AttributeValueOrder asc
END