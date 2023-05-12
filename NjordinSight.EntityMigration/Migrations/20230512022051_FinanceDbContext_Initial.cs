using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.Migrations
{
    public partial class FinanceDbContext_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FinanceApp");

            migrationBuilder.CreateSequence(
                name: "seqAuditEventID",
                schema: "FinanceApp",
                minValue: 1L);

            migrationBuilder.CreateSequence<int>(
                name: "seqModelAttributeMember",
                schema: "FinanceApp");

            migrationBuilder.CreateTable(
                name: "AccountCustodian",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountCustodianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustodianCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCustodian", x => x.AccountCustodianID);
                });

            migrationBuilder.CreateTable(
                name: "AccountObject",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountObjectCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ObjectType = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "date", nullable: true),
                    ObjectDisplayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    ObjectDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PrefixedObjectCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, computedColumnSql: "(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountObject", x => x.AccountObjectID);
                    table.CheckConstraint("CK_AccountObject_ObjectType", "[ObjectType] IN ('c','a')");
                });

            migrationBuilder.CreateTable(
                name: "AuditEvent",
                schema: "FinanceApp",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false),
                    EventTimeUTC = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuditUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEvent", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactionCode",
                schema: "FinanceApp",
                columns: table => new
                {
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionSymbol", x => x.TransactionCodeID);
                });

            migrationBuilder.CreateTable(
                name: "BrokerTransactionCode",
                schema: "FinanceApp",
                columns: table => new
                {
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CashEffect = table.Column<short>(type: "smallint", nullable: false),
                    ContributionWithdrawalEffect = table.Column<short>(type: "smallint", nullable: false),
                    QuantityEffect = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerTransactionCode", x => x.TransactionCodeID);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentStrategy",
                schema: "FinanceApp",
                columns: table => new
                {
                    InvestmentStrategyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentStrategy", x => x.InvestmentStrategyID);
                });

            migrationBuilder.CreateTable(
                name: "MarketHoliday",
                schema: "FinanceApp",
                columns: table => new
                {
                    MarketHolidayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketHolidayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketHoliday", x => x.MarketHolidayID);
                });

            migrationBuilder.CreateTable(
                name: "MarketIndex",
                schema: "FinanceApp",
                columns: table => new
                {
                    IndexID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IndexDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketIndex", x => x.IndexID);
                });

            migrationBuilder.CreateTable(
                name: "ModelAttribute",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttribute", x => x.AttributeID);
                });

            migrationBuilder.CreateTable(
                name: "ReportConfiguration",
                schema: "FinanceApp",
                columns: table => new
                {
                    ConfigurationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ConfigurationDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    XmlDefinition = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSetting", x => x.ConfigurationID);
                });

            migrationBuilder.CreateTable(
                name: "ReportStyleSheet",
                schema: "FinanceApp",
                columns: table => new
                {
                    StyleSheetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleSheetCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StyleSheetDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    XmlDefinition = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStyleSheet", x => x.StyleSheetID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceImage",
                schema: "FinanceApp",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ImageBinary = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceImage", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "SecurityExchange",
                schema: "FinanceApp",
                columns: table => new
                {
                    ExchangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExchangeDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityExchange", x => x.ExchangeID);
                });

            migrationBuilder.CreateTable(
                name: "SecuritySymbolType",
                schema: "FinanceApp",
                columns: table => new
                {
                    SymbolTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolTypeName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuritySymbolType", x => x.SymbolTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true, collation: "Latin1_General_BIN2"),
                    AccountCustodianID = table.Column<int>(type: "int", nullable: true),
                    BooksClosedDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsComplianceTradable = table.Column<bool>(type: "bit", nullable: false),
                    HasWallet = table.Column<bool>(type: "bit", nullable: false),
                    HasBankTransaction = table.Column<bool>(type: "bit", nullable: false),
                    HasBrokerTransaction = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_AccountCustodian",
                        column: x => x.AccountCustodianID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountCustodian",
                        principalColumn: "AccountCustodianID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Account_AccountObject_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountComposite",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountCompositeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountComposite", x => x.AccountCompositeID);
                    table.ForeignKey(
                        name: "FK_AccountComposite_AccountObject",
                        column: x => x.AccountCompositeID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID");
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPerformanceEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountObjectID = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false),
                    MarketValue = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    NetContribution = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AverageCapital = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Gain = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IRR = table.Column<decimal>(type: "decimal(9,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPerformanceEntry", x => new { x.AccountObjectID, x.FromDate });
                    table.ForeignKey(
                        name: "FK_InvestmentPerformanceEntry_AccountObject",
                        column: x => x.AccountObjectID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketHolidayObservance",
                schema: "FinanceApp",
                columns: table => new
                {
                    MarketHolidayID = table.Column<int>(type: "int", nullable: false),
                    ObservanceDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketHolidayObservance", x => new { x.MarketHolidayID, x.ObservanceDate });
                    table.ForeignKey(
                        name: "FK_MarketHolidayObservance_MarketHoliday",
                        column: x => x.MarketHolidayID,
                        principalSchema: "FinanceApp",
                        principalTable: "MarketHoliday",
                        principalColumn: "MarketHolidayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketIndexPrice",
                schema: "FinanceApp",
                columns: table => new
                {
                    IndexPriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketIndexID = table.Column<int>(type: "int", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "date", nullable: false),
                    PriceCode = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketIndexPrice", x => x.IndexPriceID);
                    table.CheckConstraint("CK_MarketIndexPrice_PriceCode", "[PriceCode] IN ('p','t')");
                    table.ForeignKey(
                        name: "FK_MarketIndexPrice_MarketIndex",
                        column: x => x.MarketIndexID,
                        principalSchema: "FinanceApp",
                        principalTable: "MarketIndex",
                        principalColumn: "IndexID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelAttributeMember",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttributeMember", x => x.AttributeMemberID);
                    table.ForeignKey(
                        name: "FK_ModelAttributeMember_ModelAttribute",
                        column: x => x.AttributeID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttribute",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelAttributeScope",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    ScopeCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttributeScope", x => new { x.AttributeID, x.ScopeCode });
                    table.CheckConstraint("CK_ModelAttributeScope_ScopeCode", "[ScopeCode] in ('acc', 'bnk', 'brk', 'cou', 'cus', 'exc', 'sec')");
                    table.ForeignKey(
                        name: "FK_ModelAttributeScope_ModelAttribute",
                        column: x => x.AttributeID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttribute",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                schema: "FinanceApp",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true),
                    TransactionVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_BankTransaction_Account",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_BankTransaction_BankTransactionCode",
                        column: x => x.TransactionCodeID,
                        principalSchema: "FinanceApp",
                        principalTable: "BankTransactionCode",
                        principalColumn: "TransactionCodeID");
                });

            migrationBuilder.CreateTable(
                name: "AccountCompositeMember",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountCompositeID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "date", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCompositeMember", x => new { x.AccountCompositeID, x.AccountID, x.EntryDate });
                    table.ForeignKey(
                        name: "FK_AccountCommpositeMember_Account",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_AccountCommpositeMember_AccountComposite",
                        column: x => x.AccountCompositeID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountComposite",
                        principalColumn: "AccountCompositeID");
                });

            migrationBuilder.CreateTable(
                name: "AccountAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    AccountObjectID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAttributeMemberEntry", x => new { x.AttributeMemberID, x.AccountObjectID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_AccountAttributeMemberEntry_AccountObjectID",
                        column: x => x.AccountObjectID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactionCodeAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionCodeAttributeMemberEntry", x => new { x.AttributeMemberID, x.TransactionCodeID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_BankTransactionCodeAttributeMemberEntry_BankTransactionCode",
                        column: x => x.TransactionCodeID,
                        principalSchema: "FinanceApp",
                        principalTable: "BankTransactionCode",
                        principalColumn: "TransactionCodeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactionCodeAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrokerTransactionCodeAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerTransactionCodeAttributeMemberEntry", x => new { x.AttributeMemberID, x.TransactionCodeID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_BrokerTransactionCodeAttributeMemberEntry_BrokerTransactionCode",
                        column: x => x.TransactionCodeID,
                        principalSchema: "FinanceApp",
                        principalTable: "BrokerTransactionCode",
                        principalColumn: "TransactionCodeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrokerTransactionCodeAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "FinanceApp",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    IsoCode3 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_ModelAttributeMember",
                        column: x => x.CountryID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPerformanceAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountObjectID = table.Column<int>(type: "int", nullable: false),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false),
                    MarketValue = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    NetContribution = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AverageCapital = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Gain = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IRR = table.Column<decimal>(type: "decimal(9,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPerformanceAttributeMemberEntry", x => new { x.AccountObjectID, x.AttributeMemberID, x.FromDate });
                    table.ForeignKey(
                        name: "FK_InvestmentPerformanceAttributeMemberEntry_AccountObject",
                        column: x => x.AccountObjectID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentPerformanceAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID");
                });

            migrationBuilder.CreateTable(
                name: "InvestmentStrategyTarget",
                schema: "FinanceApp",
                columns: table => new
                {
                    InvestmentStrategyID = table.Column<int>(type: "int", nullable: false),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentStrategyTarget", x => new { x.InvestmentStrategyID, x.AttributeMemberID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_InvestmentStrategyTarget_InvestmentStrategy",
                        column: x => x.InvestmentStrategyID,
                        principalSchema: "FinanceApp",
                        principalTable: "InvestmentStrategy",
                        principalColumn: "InvestmentStrategyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentStrategyTarget_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID");
                });

            migrationBuilder.CreateTable(
                name: "SecurityTypeGroup",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityTypeGroupID = table.Column<int>(type: "int", nullable: false),
                    SecurityTypeGroupName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    Transactable = table.Column<bool>(type: "bit", nullable: false),
                    DepositSource = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTypeGroup", x => x.SecurityTypeGroupID);
                    table.ForeignKey(
                        name: "FK_SecurityTypeGroup_ModelAttributeMember",
                        column: x => x.SecurityTypeGroupID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID");
                });

            migrationBuilder.CreateTable(
                name: "CountryAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAttributeMemberEntry", x => new { x.AttributeMemberID, x.CountryID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_CountryAttributeMemberEntry_Country",
                        column: x => x.CountryID,
                        principalSchema: "FinanceApp",
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityType",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityTypeID = table.Column<int>(type: "int", nullable: false),
                    SecurityTypeGroupID = table.Column<int>(type: "int", nullable: false),
                    SecurityTypeName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    ValuationFactor = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    CanHaveDerivative = table.Column<bool>(type: "bit", nullable: false),
                    CanHavePosition = table.Column<bool>(type: "bit", nullable: false),
                    HeldInWallet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityType", x => x.SecurityTypeID);
                    table.ForeignKey(
                        name: "FK_SecurityType_ModelAttributeMember",
                        column: x => x.SecurityTypeID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID");
                    table.ForeignKey(
                        name: "FK_SecurityType_SecurityTypeGroup",
                        column: x => x.SecurityTypeGroupID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecurityTypeGroup",
                        principalColumn: "SecurityTypeGroupID");
                });

            migrationBuilder.CreateTable(
                name: "Security",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityTypeID = table.Column<int>(type: "int", nullable: false),
                    SecurityExchangeID = table.Column<int>(type: "int", nullable: true),
                    SecurityDescription = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    HasPerpetualMarket = table.Column<bool>(type: "bit", nullable: false),
                    HasPerpetualPrice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.SecurityID);
                    table.ForeignKey(
                        name: "FK_Security_SecurityExchange",
                        column: x => x.SecurityExchangeID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecurityExchange",
                        principalColumn: "ExchangeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Security_SecurityType",
                        column: x => x.SecurityTypeID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecurityType",
                        principalColumn: "SecurityTypeID");
                });

            migrationBuilder.CreateTable(
                name: "AccountWallet",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountWalletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    AddressCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, collation: "Latin1_General_BIN2"),
                    AddressTag = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, collation: "Latin1_General_BIN2"),
                    DenominationSecurityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountWallet", x => x.AccountWalletID);
                    table.ForeignKey(
                        name: "FK_AccountWallet_Account",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_AccountWallet_Security",
                        column: x => x.DenominationSecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID");
                });

            migrationBuilder.CreateTable(
                name: "BrokerTransaction",
                schema: "FinanceApp",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "date", nullable: false),
                    SettleDate = table.Column<DateTime>(type: "date", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "date", nullable: true),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(19,6)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    Withholding = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    DepSecurityID = table.Column<int>(type: "int", nullable: false),
                    TaxLotID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_BrokerTransaction_Account",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_BrokerTransaction_BrokerTransaction",
                        column: x => x.TaxLotID,
                        principalSchema: "FinanceApp",
                        principalTable: "BrokerTransaction",
                        principalColumn: "TransactionID");
                    table.ForeignKey(
                        name: "FK_BrokerTransaction_BrokerTransactionCode",
                        column: x => x.TransactionCodeID,
                        principalSchema: "FinanceApp",
                        principalTable: "BrokerTransactionCode",
                        principalColumn: "TransactionCodeID");
                    table.ForeignKey(
                        name: "FK_BrokerTransaction_DepSecurityID",
                        column: x => x.DepSecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID");
                    table.ForeignKey(
                        name: "FK_BrokerTransaction_SecurityID",
                        column: x => x.SecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID");
                });

            migrationBuilder.CreateTable(
                name: "SecurityAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAttributeMemberEntry", x => new { x.AttributeMemberID, x.SecurityID, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_SecurityAttributeMemberEntry_ModelAttributeMember",
                        column: x => x.AttributeMemberID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttributeMember",
                        principalColumn: "AttributeMemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityAttributeMemberEntry_Security",
                        column: x => x.SecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityPrice",
                schema: "FinanceApp",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "date", nullable: false),
                    PriceClose = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    PriceOpen = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceHigh = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceLow = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Volume = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityPrice", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK_SecurityPrice_Security",
                        column: x => x.SecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecuritySymbol",
                schema: "FinanceApp",
                columns: table => new
                {
                    SymbolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    SymbolTypeID = table.Column<int>(type: "int", nullable: false),
                    SymbolCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, computedColumnSql: "(case when [SymbolTypeID]=(-10) then [Cusip] when [SymbolTypeID]=(-20) then [CustomSymbol] when [SymbolTypeID]=(-30) then [OptionTicker] when [SymbolTypeID]=(-40) then [Ticker]  end)", stored: true),
                    Cusip = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: true),
                    CustomSymbol = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    OptionTicker = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Ticker = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuritySymbol", x => x.SymbolID);
                    table.ForeignKey(
                        name: "FK_SecuritySymbol_Security",
                        column: x => x.SecurityID,
                        principalSchema: "FinanceApp",
                        principalTable: "Security",
                        principalColumn: "SecurityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecuritySymbol_SecuritySymbolType",
                        column: x => x.SymbolTypeID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecuritySymbolType",
                        principalColumn: "SymbolTypeID");
                });

            migrationBuilder.CreateTable(
                name: "SecuritySymbolMap",
                schema: "FinanceApp",
                columns: table => new
                {
                    SymbolMapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCustodianID = table.Column<int>(type: "int", nullable: false),
                    CustodianSymbol = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    SecuritySymbolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuritySymbolMap", x => x.SymbolMapID);
                    table.ForeignKey(
                        name: "FK_SecuritySymbolMap_AccountCustodian",
                        column: x => x.AccountCustodianID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountCustodian",
                        principalColumn: "AccountCustodianID");
                    table.ForeignKey(
                        name: "FK_SecuritySymbolMap_SecuritySymbol",
                        column: x => x.SecuritySymbolID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecuritySymbol",
                        principalColumn: "SymbolID");
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransactionCode",
                columns: new[] { "TransactionCodeID", "CashEffect", "ContributionWithdrawalEffect", "DisplayName", "QuantityEffect", "TransactionCode" },
                values: new object[,]
                {
                    { -26, (short)1, (short)0, "Capital return", (short)0, "cap" },
                    { -25, (short)-1, (short)-1, "Accrued interest", (short)0, "ain" },
                    { -24, (short)1, (short)1, "Plan contribution", (short)0, "plc" },
                    { -23, (short)1, (short)1, "Change in value", (short)1, "chn" },
                    { -22, (short)-1, (short)-1, "Withdrawal", (short)0, "wth" },
                    { -21, (short)1, (short)0, "Short sale", (short)-1, "ssl" },
                    { -20, (short)1, (short)0, "Sale", (short)-1, "sll" },
                    { -19, (short)-1, (short)0, "Pay-down", (short)-1, "pdn" },
                    { -18, (short)0, (short)-1, "Deliver-out", (short)-1, "dlo" },
                    { -17, (short)0, (short)1, "Deliver-in", (short)1, "dli" },
                    { -16, (short)1, (short)0, "Interest", (short)0, "int" },
                    { -15, (short)0, (short)-1, "Forfeit shares", (short)-1, "frt" },
                    { -14, (short)-1, (short)-1, "Expense", (short)0, "exp" },
                    { -13, (short)1, (short)0, "Dividend", (short)0, "div" },
                    { -12, (short)1, (short)1, "Deposit", (short)0, "dep" },
                    { -11, (short)-1, (short)0, "Buy", (short)1, "buy" },
                    { -10, (short)-1, (short)0, "Buy to cover", (short)1, "btc" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketHoliday",
                columns: new[] { "MarketHolidayID", "MarketHolidayName" },
                values: new object[,]
                {
                    { -18, "Thanksgiving Day" },
                    { -17, "President's Day" },
                    { -16, "New Years Day" },
                    { -15, "Memorial Day" },
                    { -14, "Martin Luther King, Jr. Day" },
                    { -13, "Labor Day" },
                    { -12, "Independence Day" },
                    { -11, "Good Friday" },
                    { -10, "Christmas Day" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                columns: new[] { "AttributeID", "DisplayName" },
                values: new object[,]
                {
                    { -60, "Country Exposure" },
                    { -50, "Transaction Class" },
                    { -40, "Transaction Category" },
                    { -30, "Security Type" },
                    { -20, "Security Type Group" },
                    { -10, "Asset Class" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecuritySymbolType",
                columns: new[] { "SymbolTypeID", "SymbolTypeName" },
                values: new object[,]
                {
                    { -40, "Ticker" },
                    { -30, "Option Ticker" },
                    { -20, "Custom Identifier" },
                    { -10, "CUSIP" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketHolidayObservance",
                columns: new[] { "MarketHolidayID", "ObservanceDate" },
                values: new object[,]
                {
                    { -18, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -17, new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -16, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -15, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -14, new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -13, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -12, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -10, new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -848, -60, "ALA", (short)248 },
                    { -847, -60, "ZWE", (short)247 },
                    { -846, -60, "ZMB", (short)246 },
                    { -845, -60, "YEM", (short)245 },
                    { -844, -60, "ESH", (short)244 },
                    { -843, -60, "WLF", (short)243 },
                    { -842, -60, "VIR", (short)242 },
                    { -841, -60, "VGB", (short)241 },
                    { -840, -60, "VNM", (short)240 },
                    { -839, -60, "VEN", (short)239 },
                    { -838, -60, "VUT", (short)238 },
                    { -837, -60, "UZB", (short)237 },
                    { -836, -60, "URY", (short)236 },
                    { -835, -60, "USA", (short)235 },
                    { -834, -60, "UMI", (short)234 },
                    { -833, -60, "GBR", (short)233 },
                    { -832, -60, "ARE", (short)232 },
                    { -831, -60, "UKR", (short)231 },
                    { -830, -60, "UGA", (short)230 },
                    { -829, -60, "TUV", (short)229 },
                    { -828, -60, "TCA", (short)228 },
                    { -827, -60, "TKM", (short)227 },
                    { -826, -60, "TUR", (short)226 },
                    { -825, -60, "TUN", (short)225 },
                    { -824, -60, "TTO", (short)224 },
                    { -823, -60, "TON", (short)223 },
                    { -822, -60, "TKL", (short)222 },
                    { -821, -60, "TGO", (short)221 },
                    { -820, -60, "TLS", (short)220 },
                    { -819, -60, "THA", (short)219 },
                    { -818, -60, "TZA", (short)218 },
                    { -817, -60, "TJK", (short)217 },
                    { -816, -60, "TWN", (short)216 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -815, -60, "SYR", (short)215 },
                    { -814, -60, "CHE", (short)214 },
                    { -813, -60, "SWE", (short)213 },
                    { -812, -60, "SJM", (short)212 },
                    { -811, -60, "SUR", (short)211 },
                    { -810, -60, "SDN", (short)210 },
                    { -809, -60, "LKA", (short)209 },
                    { -808, -60, "ESP", (short)208 },
                    { -807, -60, "SSD", (short)207 },
                    { -806, -60, "SGS", (short)206 },
                    { -805, -60, "ZAF", (short)205 },
                    { -804, -60, "SOM", (short)204 },
                    { -803, -60, "SLB", (short)203 },
                    { -802, -60, "SVN", (short)202 },
                    { -801, -60, "SVK", (short)201 },
                    { -800, -60, "SXM", (short)200 },
                    { -799, -60, "SGP", (short)199 },
                    { -798, -60, "SLE", (short)198 },
                    { -797, -60, "SYC", (short)197 },
                    { -796, -60, "SRB", (short)196 },
                    { -795, -60, "SEN", (short)195 },
                    { -794, -60, "SAU", (short)194 },
                    { -793, -60, "STP", (short)193 },
                    { -792, -60, "SMR", (short)192 },
                    { -791, -60, "WSM", (short)191 },
                    { -790, -60, "VCT", (short)190 },
                    { -789, -60, "SPM", (short)189 },
                    { -788, -60, "MAF", (short)188 },
                    { -787, -60, "LCA", (short)187 },
                    { -786, -60, "KNA", (short)186 },
                    { -785, -60, "SHN", (short)185 },
                    { -784, -60, "BLM", (short)184 },
                    { -783, -60, "REU", (short)183 },
                    { -782, -60, "RWA", (short)182 },
                    { -781, -60, "RUS", (short)181 },
                    { -780, -60, "ROU", (short)180 },
                    { -779, -60, "QAT", (short)179 },
                    { -778, -60, "PRI", (short)178 },
                    { -777, -60, "PRT", (short)177 },
                    { -776, -60, "POL", (short)176 },
                    { -775, -60, "PCN", (short)175 },
                    { -774, -60, "PHL", (short)174 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -773, -60, "PER", (short)173 },
                    { -772, -60, "PRY", (short)172 },
                    { -771, -60, "PNG", (short)171 },
                    { -770, -60, "PAN", (short)170 },
                    { -769, -60, "PSE", (short)169 },
                    { -768, -60, "PLW", (short)168 },
                    { -767, -60, "PAK", (short)167 },
                    { -766, -60, "OMN", (short)166 },
                    { -765, -60, "NOR", (short)165 },
                    { -764, -60, "MNP", (short)164 },
                    { -763, -60, "NFK", (short)163 },
                    { -762, -60, "NIU", (short)162 },
                    { -761, -60, "NGA", (short)161 },
                    { -760, -60, "NER", (short)160 },
                    { -759, -60, "NIC", (short)159 },
                    { -758, -60, "NZL", (short)158 },
                    { -757, -60, "NCL", (short)157 },
                    { -756, -60, "NLD", (short)156 },
                    { -755, -60, "NPL", (short)155 },
                    { -754, -60, "NRU", (short)154 },
                    { -753, -60, "NAM", (short)153 },
                    { -752, -60, "MMR", (short)152 },
                    { -751, -60, "MOZ", (short)151 },
                    { -750, -60, "MAR", (short)150 },
                    { -749, -60, "MSR", (short)149 },
                    { -748, -60, "MNE", (short)148 },
                    { -747, -60, "MNG", (short)147 },
                    { -746, -60, "MCO", (short)146 },
                    { -745, -60, "MDA", (short)145 },
                    { -744, -60, "FSM", (short)144 },
                    { -743, -60, "MEX", (short)143 },
                    { -742, -60, "MYT", (short)142 },
                    { -741, -60, "MUS", (short)141 },
                    { -740, -60, "MRT", (short)140 },
                    { -739, -60, "MTQ", (short)139 },
                    { -738, -60, "MHL", (short)138 },
                    { -737, -60, "MLT", (short)137 },
                    { -736, -60, "MLI", (short)136 },
                    { -735, -60, "MDV", (short)135 },
                    { -734, -60, "MYS", (short)134 },
                    { -733, -60, "MWI", (short)133 },
                    { -732, -60, "MDG", (short)132 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -731, -60, "MKD", (short)131 },
                    { -730, -60, "MAC", (short)130 },
                    { -729, -60, "LUX", (short)129 },
                    { -728, -60, "LTU", (short)128 },
                    { -727, -60, "LIE", (short)127 },
                    { -726, -60, "LBY", (short)126 },
                    { -725, -60, "LBR", (short)125 },
                    { -724, -60, "LSO", (short)124 },
                    { -723, -60, "LBN", (short)123 },
                    { -722, -60, "LVA", (short)122 },
                    { -721, -60, "LAO", (short)121 },
                    { -720, -60, "KGZ", (short)120 },
                    { -719, -60, "KWT", (short)119 },
                    { -718, -60, "KOR", (short)118 },
                    { -717, -60, "PRK", (short)117 },
                    { -716, -60, "KIR", (short)116 },
                    { -715, -60, "KEN", (short)115 },
                    { -714, -60, "KAZ", (short)114 },
                    { -713, -60, "JOR", (short)113 },
                    { -712, -60, "JEY", (short)112 },
                    { -711, -60, "JPN", (short)111 },
                    { -710, -60, "JAM", (short)110 },
                    { -709, -60, "ITA", (short)109 },
                    { -708, -60, "ISR", (short)108 },
                    { -707, -60, "IMN", (short)107 },
                    { -706, -60, "IRL", (short)106 },
                    { -705, -60, "IRQ", (short)105 },
                    { -704, -60, "IRN", (short)104 },
                    { -703, -60, "IDN", (short)103 },
                    { -702, -60, "IND", (short)102 },
                    { -701, -60, "ISL", (short)101 },
                    { -700, -60, "HUN", (short)100 },
                    { -699, -60, "HKG", (short)99 },
                    { -698, -60, "HND", (short)98 },
                    { -697, -60, "VAT", (short)97 },
                    { -696, -60, "HMD", (short)96 },
                    { -695, -60, "HTI", (short)95 },
                    { -694, -60, "GUY", (short)94 },
                    { -693, -60, "GNB", (short)93 },
                    { -692, -60, "GIN", (short)92 },
                    { -691, -60, "GGY", (short)91 },
                    { -690, -60, "GTM", (short)90 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -689, -60, "GUM", (short)89 },
                    { -688, -60, "GLP", (short)88 },
                    { -687, -60, "GRD", (short)87 },
                    { -686, -60, "GRL", (short)86 },
                    { -685, -60, "GRC", (short)85 },
                    { -684, -60, "GIB", (short)84 },
                    { -683, -60, "GHA", (short)83 },
                    { -682, -60, "DEU", (short)82 },
                    { -681, -60, "GEO", (short)81 },
                    { -680, -60, "GMB", (short)80 },
                    { -679, -60, "GAB", (short)79 },
                    { -678, -60, "ATF", (short)78 },
                    { -677, -60, "PYF", (short)77 },
                    { -676, -60, "GUF", (short)76 },
                    { -675, -60, "FRA", (short)75 },
                    { -674, -60, "FIN", (short)74 },
                    { -673, -60, "FJI", (short)73 },
                    { -672, -60, "FRO", (short)72 },
                    { -671, -60, "FLK", (short)71 },
                    { -670, -60, "ETH", (short)70 },
                    { -669, -60, "SWZ", (short)69 },
                    { -668, -60, "EST", (short)68 },
                    { -667, -60, "ERI", (short)67 },
                    { -666, -60, "GNQ", (short)66 },
                    { -665, -60, "SLV", (short)65 },
                    { -664, -60, "EGY", (short)64 },
                    { -663, -60, "ECU", (short)63 },
                    { -662, -60, "DOM", (short)62 },
                    { -661, -60, "DMA", (short)61 },
                    { -660, -60, "DJI", (short)60 },
                    { -659, -60, "DNK", (short)59 },
                    { -658, -60, "CIV", (short)58 },
                    { -657, -60, "CZE", (short)57 },
                    { -656, -60, "CYP", (short)56 },
                    { -655, -60, "CUW", (short)55 },
                    { -654, -60, "CUB", (short)54 },
                    { -653, -60, "HRV", (short)53 },
                    { -652, -60, "CRI", (short)52 },
                    { -651, -60, "COK", (short)51 },
                    { -650, -60, "COG", (short)50 },
                    { -649, -60, "COD", (short)49 },
                    { -648, -60, "COM", (short)48 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -647, -60, "COL", (short)47 },
                    { -646, -60, "CCK", (short)46 },
                    { -645, -60, "CXR", (short)45 },
                    { -644, -60, "CHN", (short)44 },
                    { -643, -60, "CHL", (short)43 },
                    { -642, -60, "TCD", (short)42 },
                    { -641, -60, "CAF", (short)41 },
                    { -640, -60, "CYM", (short)40 },
                    { -639, -60, "CAN", (short)39 },
                    { -638, -60, "CMR", (short)38 },
                    { -637, -60, "KHM", (short)37 },
                    { -636, -60, "CPV", (short)36 },
                    { -635, -60, "BDI", (short)35 },
                    { -634, -60, "BFA", (short)34 },
                    { -633, -60, "BGR", (short)33 },
                    { -632, -60, "BRN", (short)32 },
                    { -631, -60, "IOT", (short)31 },
                    { -630, -60, "BRA", (short)30 },
                    { -629, -60, "BVT", (short)29 },
                    { -628, -60, "BWA", (short)28 },
                    { -627, -60, "BIH", (short)27 },
                    { -626, -60, "BES", (short)26 },
                    { -625, -60, "BOL", (short)25 },
                    { -624, -60, "BTN", (short)24 },
                    { -623, -60, "BMU", (short)23 },
                    { -622, -60, "BEN", (short)22 },
                    { -621, -60, "BLZ", (short)21 },
                    { -620, -60, "BEL", (short)20 },
                    { -619, -60, "BLR", (short)19 },
                    { -618, -60, "BRB", (short)18 },
                    { -617, -60, "BGD", (short)17 },
                    { -616, -60, "BHR", (short)16 },
                    { -615, -60, "BHS", (short)15 },
                    { -614, -60, "AZE", (short)14 },
                    { -613, -60, "AUT", (short)13 },
                    { -612, -60, "AUS", (short)12 },
                    { -611, -60, "ABW", (short)11 },
                    { -610, -60, "ARM", (short)10 },
                    { -609, -60, "ARG", (short)9 },
                    { -608, -60, "ATG", (short)8 },
                    { -607, -60, "ATA", (short)7 },
                    { -606, -60, "AIA", (short)6 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -605, -60, "AGO", (short)5 },
                    { -604, -60, "AND", (short)4 },
                    { -603, -60, "ASM", (short)3 },
                    { -602, -60, "DZA", (short)2 },
                    { -601, -60, "ALB", (short)1 },
                    { -600, -60, "AFG", (short)0 },
                    { -506, -50, "Writeoff", (short)5 },
                    { -505, -50, "Transfer", (short)3 },
                    { -504, -50, "Balance", (short)0 },
                    { -503, -50, "Income", (short)2 },
                    { -502, -50, "Trade", (short)1 },
                    { -501, -50, "Expense", (short)4 },
                    { -414, -40, "Margin Sales", (short)2 },
                    { -413, -40, "Sales", (short)3 },
                    { -412, -40, "Principal Pay-Down", (short)1 },
                    { -411, -40, "Interest", (short)1 },
                    { -410, -40, "Writeoffs", (short)0 },
                    { -409, -40, "Expenses", (short)2 },
                    { -408, -40, "Dividends", (short)0 },
                    { -407, -40, "Withdrawals", (short)1 },
                    { -406, -40, "Contributions", (short)0 },
                    { -405, -40, "Starting Balance", (short)0 },
                    { -404, -40, "Gain/Loss", (short)2 },
                    { -403, -40, "Margin Purchases", (short)1 },
                    { -402, -40, "Purchases", (short)0 },
                    { -401, -40, "Interest Charge", (short)0 },
                    { -321, -30, "None/External", (short)21 },
                    { -320, -30, "Expense", (short)20 },
                    { -319, -30, "Cash", (short)19 },
                    { -318, -30, "Fiat Currency", (short)18 },
                    { -317, -30, "Money-Market Fund", (short)17 },
                    { -316, -30, "Student Debt", (short)16 },
                    { -315, -30, "Revolving Debt", (short)15 },
                    { -314, -30, "Retirement Plan", (short)14 },
                    { -313, -30, "Exchange-Traded Note", (short)13 },
                    { -312, -30, "Cryptocurrency", (short)12 },
                    { -311, -30, "Put Option", (short)11 },
                    { -310, -30, "Call Option", (short)10 },
                    { -309, -30, "Bond Mutual Fund", (short)9 },
                    { -308, -30, "Bond ETF", (short)8 },
                    { -307, -30, "Certificate of Deposit", (short)7 },
                    { -306, -30, "U.S. Goverment Bond/Bill", (short)6 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -305, -30, "Municipal Bond", (short)5 },
                    { -304, -30, "Corporate Bond", (short)4 },
                    { -303, -30, "Equity Mutual Fund", (short)3 },
                    { -302, -30, "Equity ETF", (short)2 },
                    { -301, -30, "American Depository Receipt", (short)1 },
                    { -300, -30, "Common Stock", (short)0 },
                    { -212, -20, "None/External", (short)12 },
                    { -211, -20, "Expense", (short)11 },
                    { -210, -20, "Cash Deposit", (short)10 },
                    { -209, -20, "Cash Funds & Currency", (short)9 },
                    { -208, -20, "Long-Term Debt", (short)8 },
                    { -207, -20, "Short-Term Debt", (short)7 },
                    { -206, -20, "Other Funds & ETPs", (short)6 },
                    { -205, -20, "Digital Assets", (short)5 },
                    { -204, -20, "Option Contracts", (short)4 },
                    { -203, -20, "Fixed Icome Funds & ETFs", (short)3 },
                    { -202, -20, "Individual Bonds & CDs", (short)2 },
                    { -201, -20, "Equity Funds & ETFs", (short)1 },
                    { -200, -20, "Individual Stocks", (short)0 },
                    { -107, -10, "Not Classified", (short)7 },
                    { -106, -10, "Debt & Liability", (short)6 },
                    { -105, -10, "Blended Funds & Products", (short)5 },
                    { -104, -10, "Cash & Equivalents", (short)4 },
                    { -103, -10, "Other", (short)3 },
                    { -102, -10, "Derivatives", (short)2 },
                    { -101, -10, "Fixed Income", (short)1 },
                    { -100, -10, "Equities", (short)0 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                columns: new[] { "AttributeID", "ScopeCode" },
                values: new object[,]
                {
                    { -60, "sec" },
                    { -50, "brk" },
                    { -40, "brk" },
                    { -30, "sec" },
                    { -20, "sec" },
                    { -10, "sec" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransactionCodeAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID", "Weight" },
                values: new object[,]
                {
                    { -506, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15, 1m },
                    { -505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -24, 1m },
                    { -505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -22, 1m },
                    { -505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -18, 1m },
                    { -505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -17, 1m },
                    { -505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, 1m },
                    { -504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23, 1m },
                    { -503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -26, 1m },
                    { -503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -19, 1m },
                    { -503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, 1m },
                    { -503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, 1m },
                    { -502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21, 1m },
                    { -502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, 1m },
                    { -502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, 1m },
                    { -502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, 1m },
                    { -501, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -25, 1m },
                    { -501, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -14, 1m },
                    { -414, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, 1m },
                    { -412, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -19, 1m },
                    { -411, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, 1m },
                    { -410, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15, 1m },
                    { -409, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -14, 1m },
                    { -408, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, 1m },
                    { -407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -22, 1m },
                    { -407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21, 1m },
                    { -407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -18, 1m },
                    { -406, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -24, 1m },
                    { -406, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -17, 1m },
                    { -406, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, 1m },
                    { -405, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23, 1m },
                    { -404, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -26, 1m },
                    { -403, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, 1m },
                    { -402, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, 1m },
                    { -401, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -25, 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -848, "Åland Islands", "ALA" },
                    { -847, "Zimbabwe", "ZWE" },
                    { -846, "Zambia", "ZMB" },
                    { -845, "Yemen", "YEM" },
                    { -844, "Western Sahara", "ESH" },
                    { -843, "Wallis and Futuna", "WLF" },
                    { -842, "Virgin Islands (U.S.)", "VIR" },
                    { -841, "Virgin Islands (British)", "VGB" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -840, "Viet Nam", "VNM" },
                    { -839, "Venezuela (Bolivarian Republic of)", "VEN" },
                    { -838, "Vanuatu", "VUT" },
                    { -837, "Uzbekistan", "UZB" },
                    { -836, "Uruguay", "URY" },
                    { -835, "United States of America (the)", "USA" },
                    { -834, "United States Minor Outlying Islands (the)", "UMI" },
                    { -833, "United Kingdom of Great Britain and Northern Ireland (the)", "GBR" },
                    { -832, "United Arab Emirates (the)", "ARE" },
                    { -831, "Ukraine", "UKR" },
                    { -830, "Uganda", "UGA" },
                    { -829, "Tuvalu", "TUV" },
                    { -828, "Turks and Caicos Islands (the)", "TCA" },
                    { -827, "Turkmenistan", "TKM" },
                    { -826, "Turkey", "TUR" },
                    { -825, "Tunisia", "TUN" },
                    { -824, "Trinidad and Tobago", "TTO" },
                    { -823, "Tonga", "TON" },
                    { -822, "Tokelau", "TKL" },
                    { -821, "Togo", "TGO" },
                    { -820, "Timor-Leste", "TLS" },
                    { -819, "Thailand", "THA" },
                    { -818, "Tanzania, United Republic of", "TZA" },
                    { -817, "Tajikistan", "TJK" },
                    { -816, "Taiwan", "TWN" },
                    { -815, "Syrian Arab Republic", "SYR" },
                    { -814, "Switzerland", "CHE" },
                    { -813, "Sweden", "SWE" },
                    { -812, "Svalbard and Jan Mayen", "SJM" },
                    { -811, "Suriname", "SUR" },
                    { -810, "Sudan (the)", "SDN" },
                    { -809, "Sri Lanka", "LKA" },
                    { -808, "Spain", "ESP" },
                    { -807, "South Sudan", "SSD" },
                    { -806, "South Georgia and the South Sandwich Islands", "SGS" },
                    { -805, "South Africa", "ZAF" },
                    { -804, "Somalia", "SOM" },
                    { -803, "Solomon Islands", "SLB" },
                    { -802, "Slovenia", "SVN" },
                    { -801, "Slovakia", "SVK" },
                    { -800, "Sint Maarten (Dutch part)", "SXM" },
                    { -799, "Singapore", "SGP" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -798, "Sierra Leone", "SLE" },
                    { -797, "Seychelles", "SYC" },
                    { -796, "Serbia", "SRB" },
                    { -795, "Senegal", "SEN" },
                    { -794, "Saudi Arabia", "SAU" },
                    { -793, "Sao Tome and Principe", "STP" },
                    { -792, "San Marino", "SMR" },
                    { -791, "Samoa", "WSM" },
                    { -790, "Saint Vincent and the Grenadines", "VCT" },
                    { -789, "Saint Pierre and Miquelon", "SPM" },
                    { -788, "Saint Martin (French part)", "MAF" },
                    { -787, "Saint Lucia", "LCA" },
                    { -786, "Saint Kitts and Nevis", "KNA" },
                    { -785, "Saint Helena, Ascension and Tristan da Cunha", "SHN" },
                    { -784, "Saint Barthélemy", "BLM" },
                    { -783, "Réunion", "REU" },
                    { -782, "Rwanda", "RWA" },
                    { -781, "Russian Federation (the)", "RUS" },
                    { -780, "Romania", "ROU" },
                    { -779, "Qatar", "QAT" },
                    { -778, "Puerto Rico", "PRI" },
                    { -777, "Portugal", "PRT" },
                    { -776, "Poland", "POL" },
                    { -775, "Pitcairn", "PCN" },
                    { -774, "Philippines (the)", "PHL" },
                    { -773, "Peru", "PER" },
                    { -772, "Paraguay", "PRY" },
                    { -771, "Papua New Guinea", "PNG" },
                    { -770, "Panama", "PAN" },
                    { -769, "Palestine, State of", "PSE" },
                    { -768, "Palau", "PLW" },
                    { -767, "Pakistan", "PAK" },
                    { -766, "Oman", "OMN" },
                    { -765, "Norway", "NOR" },
                    { -764, "Northern Mariana Islands (the)", "MNP" },
                    { -763, "Norfolk Island", "NFK" },
                    { -762, "Niue", "NIU" },
                    { -761, "Nigeria", "NGA" },
                    { -760, "Niger (the)", "NER" },
                    { -759, "Nicaragua", "NIC" },
                    { -758, "New Zealand", "NZL" },
                    { -757, "New Caledonia", "NCL" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -756, "Netherlands (the)", "NLD" },
                    { -755, "Nepal", "NPL" },
                    { -754, "Nauru", "NRU" },
                    { -753, "Namibia", "NAM" },
                    { -752, "Myanmar", "MMR" },
                    { -751, "Mozambique", "MOZ" },
                    { -750, "Morocco", "MAR" },
                    { -749, "Montserrat", "MSR" },
                    { -748, "Montenegro", "MNE" },
                    { -747, "Mongolia", "MNG" },
                    { -746, "Monaco", "MCO" },
                    { -745, "Moldova (the Republic of)", "MDA" },
                    { -744, "Micronesia (Federated States of)", "FSM" },
                    { -743, "Mexico", "MEX" },
                    { -742, "Mayotte", "MYT" },
                    { -741, "Mauritius", "MUS" },
                    { -740, "Mauritania", "MRT" },
                    { -739, "Martinique", "MTQ" },
                    { -738, "Marshall Islands (the)", "MHL" },
                    { -737, "Malta", "MLT" },
                    { -736, "Mali", "MLI" },
                    { -735, "Maldives", "MDV" },
                    { -734, "Malaysia", "MYS" },
                    { -733, "Malawi", "MWI" },
                    { -732, "Madagascar", "MDG" },
                    { -731, "Macedonia (the former Yugoslav Republic of)", "MKD" },
                    { -730, "Macao", "MAC" },
                    { -729, "Luxembourg", "LUX" },
                    { -728, "Lithuania", "LTU" },
                    { -727, "Liechtenstein", "LIE" },
                    { -726, "Libya", "LBY" },
                    { -725, "Liberia", "LBR" },
                    { -724, "Lesotho", "LSO" },
                    { -723, "Lebanon", "LBN" },
                    { -722, "Latvia", "LVA" },
                    { -721, "Lao People's Democratic Republic (the)", "LAO" },
                    { -720, "Kyrgyzstan", "KGZ" },
                    { -719, "Kuwait", "KWT" },
                    { -718, "Korea (the Republic of)", "KOR" },
                    { -717, "Korea (the Democratic People's Republic of)", "PRK" },
                    { -716, "Kiribati", "KIR" },
                    { -715, "Kenya", "KEN" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -714, "Kazakhstan", "KAZ" },
                    { -713, "Jordan", "JOR" },
                    { -712, "Jersey", "JEY" },
                    { -711, "Japan", "JPN" },
                    { -710, "Jamaica", "JAM" },
                    { -709, "Italy", "ITA" },
                    { -708, "Israel", "ISR" },
                    { -707, "Isle of Man", "IMN" },
                    { -706, "Ireland", "IRL" },
                    { -705, "Iraq", "IRQ" },
                    { -704, "Iran (Islamic Republic of)", "IRN" },
                    { -703, "Indonesia", "IDN" },
                    { -702, "India", "IND" },
                    { -701, "Iceland", "ISL" },
                    { -700, "Hungary", "HUN" },
                    { -699, "Hong Kong", "HKG" },
                    { -698, "Honduras", "HND" },
                    { -697, "Holy See (the)", "VAT" },
                    { -696, "Heard Island and McDonald Islands", "HMD" },
                    { -695, "Haiti", "HTI" },
                    { -694, "Guyana", "GUY" },
                    { -693, "Guinea-Bissau", "GNB" },
                    { -692, "Guinea", "GIN" },
                    { -691, "Guernsey", "GGY" },
                    { -690, "Guatemala", "GTM" },
                    { -689, "Guam", "GUM" },
                    { -688, "Guadeloupe", "GLP" },
                    { -687, "Grenada", "GRD" },
                    { -686, "Greenland", "GRL" },
                    { -685, "Greece", "GRC" },
                    { -684, "Gibraltar", "GIB" },
                    { -683, "Ghana", "GHA" },
                    { -682, "Germany", "DEU" },
                    { -681, "Georgia", "GEO" },
                    { -680, "Gambia (the)", "GMB" },
                    { -679, "Gabon", "GAB" },
                    { -678, "French Southern Territories (the)", "ATF" },
                    { -677, "French Polynesia", "PYF" },
                    { -676, "French Guiana", "GUF" },
                    { -675, "France", "FRA" },
                    { -674, "Finland", "FIN" },
                    { -673, "Fiji", "FJI" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -672, "Faroe Islands (the)", "FRO" },
                    { -671, "Falkland Islands (the) [Malvinas]", "FLK" },
                    { -670, "Ethiopia", "ETH" },
                    { -669, "Eswatini", "SWZ" },
                    { -668, "Estonia", "EST" },
                    { -667, "Eritrea", "ERI" },
                    { -666, "Equatorial Guinea", "GNQ" },
                    { -665, "El Salvador", "SLV" },
                    { -664, "Egypt", "EGY" },
                    { -663, "Ecuador", "ECU" },
                    { -662, "Dominican Republic (the)", "DOM" },
                    { -661, "Dominica", "DMA" },
                    { -660, "Djibouti", "DJI" },
                    { -659, "Denmark", "DNK" },
                    { -658, "Côte d'Ivoire", "CIV" },
                    { -657, "Czechia", "CZE" },
                    { -656, "Cyprus", "CYP" },
                    { -655, "Curaçao", "CUW" },
                    { -654, "Cuba", "CUB" },
                    { -653, "Croatia", "HRV" },
                    { -652, "Costa Rica", "CRI" },
                    { -651, "Cook Islands (the)", "COK" },
                    { -650, "Congo (the)", "COG" },
                    { -649, "Congo (the Democratic Republic of the)", "COD" },
                    { -648, "Comoros (the)", "COM" },
                    { -647, "Colombia", "COL" },
                    { -646, "Cocos (Keeling) Islands (the)", "CCK" },
                    { -645, "Christmas Island", "CXR" },
                    { -644, "China", "CHN" },
                    { -643, "Chile", "CHL" },
                    { -642, "Chad", "TCD" },
                    { -641, "Central African Republic (the)", "CAF" },
                    { -640, "Cayman Islands (the)", "CYM" },
                    { -639, "Canada", "CAN" },
                    { -638, "Cameroon", "CMR" },
                    { -637, "Cambodia", "KHM" },
                    { -636, "Cabo Verde", "CPV" },
                    { -635, "Burundi", "BDI" },
                    { -634, "Burkina Faso", "BFA" },
                    { -633, "Bulgaria", "BGR" },
                    { -632, "Brunei Darussalam", "BRN" },
                    { -631, "British Indian Ocean Territory (the)", "IOT" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -630, "Brazil", "BRA" },
                    { -629, "Bouvet Island", "BVT" },
                    { -628, "Botswana", "BWA" },
                    { -627, "Bosnia and Herzegovina", "BIH" },
                    { -626, "Bonaire, Sint Eustatius and Saba", "BES" },
                    { -625, "Bolivia (Plurinational State of)", "BOL" },
                    { -624, "Bhutan", "BTN" },
                    { -623, "Bermuda", "BMU" },
                    { -622, "Benin", "BEN" },
                    { -621, "Belize", "BLZ" },
                    { -620, "Belgium", "BEL" },
                    { -619, "Belarus", "BLR" },
                    { -618, "Barbados", "BRB" },
                    { -617, "Bangladesh", "BGD" },
                    { -616, "Bahrain", "BHR" },
                    { -615, "Bahamas (the)", "BHS" },
                    { -614, "Azerbaijan", "AZE" },
                    { -613, "Austria", "AUT" },
                    { -612, "Australia", "AUS" },
                    { -611, "Aruba", "ABW" },
                    { -610, "Armenia", "ARM" },
                    { -609, "Argentina", "ARG" },
                    { -608, "Antigua and Barbuda", "ATG" },
                    { -607, "Antarctica", "ATA" },
                    { -606, "Anguilla", "AIA" },
                    { -605, "Angola", "AGO" },
                    { -604, "Andorra", "AND" },
                    { -603, "American Samoa", "ASM" },
                    { -602, "Algeria", "DZA" },
                    { -601, "Albania", "ALB" },
                    { -600, "Afghanistan", "AFG" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                columns: new[] { "SecurityTypeGroupID", "DepositSource", "SecurityTypeGroupName", "Transactable" },
                values: new object[,]
                {
                    { -212, true, "None/External", false },
                    { -211, false, "Expense", true },
                    { -210, true, "Cash Deposit", true },
                    { -209, false, "Cash Funds & Currency", true },
                    { -208, false, "Long-Term Debt", true },
                    { -207, false, "Short-Term Debt", true },
                    { -206, false, "Other Funds & ETPs", true },
                    { -205, false, "Digital Assets", true },
                    { -204, false, "Option Contracts", true },
                    { -203, false, "Fixed Icome Funds & ETFs", true },
                    { -202, false, "Individual Bonds & CDs", true }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                columns: new[] { "SecurityTypeGroupID", "DepositSource", "SecurityTypeGroupName", "Transactable" },
                values: new object[] { -201, false, "Equity Funds & ETFs", true });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                columns: new[] { "SecurityTypeGroupID", "DepositSource", "SecurityTypeGroupName", "Transactable" },
                values: new object[] { -200, false, "Individual Stocks", true });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityType",
                columns: new[] { "SecurityTypeID", "CanHaveDerivative", "CanHavePosition", "HeldInWallet", "SecurityTypeGroupID", "SecurityTypeName", "ValuationFactor" },
                values: new object[,]
                {
                    { -321, false, false, false, -212, "None/External", 1m },
                    { -320, false, false, false, -211, "Expense", 1m },
                    { -319, false, true, false, -210, "Cash", 1m },
                    { -318, false, true, false, -209, "Fiat Currency", 1m },
                    { -317, false, true, false, -209, "Money-Market Fund", 1m },
                    { -316, false, true, false, -208, "Student Debt", 1m },
                    { -315, false, true, false, -207, "Revolving Debt", 1m },
                    { -314, false, true, false, -206, "Retirement Plan", 1m },
                    { -313, false, true, false, -206, "Exchange-Traded Note", 1m },
                    { -312, false, true, true, -205, "Cryptocurrency", 1m },
                    { -311, false, true, false, -204, "Put Option", 100m },
                    { -310, false, true, false, -204, "Call Option", 100m },
                    { -309, false, true, false, -203, "Bond Mutual Fund", 1m },
                    { -308, true, true, false, -203, "Bond ETF", 1m },
                    { -307, false, true, false, -202, "Certificate of Deposit", 1m },
                    { -306, false, true, false, -202, "U.S. Goverment Bond/Bill", 0.01m },
                    { -305, false, true, false, -202, "Municipal Bond", 0.01m },
                    { -304, false, true, false, -202, "Corporate Bond", 0.01m },
                    { -303, false, true, false, -201, "Equity Mutual Fund", 1m },
                    { -302, true, true, false, -201, "Equity ETF", 1m },
                    { -301, true, true, false, -200, "American Depository Receipt", 1m },
                    { -300, true, true, false, -200, "Common Stock", 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Security",
                columns: new[] { "SecurityID", "HasPerpetualMarket", "HasPerpetualPrice", "Issuer", "SecurityDescription", "SecurityExchangeID", "SecurityTypeID" },
                values: new object[] { -102, false, false, null, "Foreign tax withholding", null, -320 });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Security",
                columns: new[] { "SecurityID", "HasPerpetualMarket", "HasPerpetualPrice", "Issuer", "SecurityDescription", "SecurityExchangeID", "SecurityTypeID" },
                values: new object[] { -101, false, true, null, "Broker cash", null, -319 });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Security",
                columns: new[] { "SecurityID", "HasPerpetualMarket", "HasPerpetualPrice", "Issuer", "SecurityDescription", "SecurityExchangeID", "SecurityTypeID" },
                values: new object[] { -100, false, false, null, "None", null, -321 });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountCustodianID",
                schema: "FinanceApp",
                table: "Account",
                column: "AccountCustodianID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttributeMemberEntry_AccountObjectID",
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                column: "AccountObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAttributeMemberEntry_AttributeMemberID",
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCompositeMember_AccountCompositeID",
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                column: "AccountCompositeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCompositeMember_AccountID",
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountCustodian_CustodianCode",
                schema: "FinanceApp",
                table: "AccountCustodian",
                column: "CustodianCode",
                unique: true,
                filter: "([CustodianCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountCustodian_DisplayName",
                schema: "FinanceApp",
                table: "AccountCustodian",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountObject_AccountObjectCode",
                schema: "FinanceApp",
                table: "AccountObject",
                column: "AccountObjectCode",
                unique: true,
                filter: "([AccountObjectCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AccountWallet_AccountID",
                schema: "FinanceApp",
                table: "AccountWallet",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountWallet_RowDef",
                schema: "FinanceApp",
                table: "AccountWallet",
                columns: new[] { "DenominationSecurityID", "AccountID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_AccountID",
                schema: "FinanceApp",
                table: "BankTransaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_TransactionCodeID",
                schema: "FinanceApp",
                table: "BankTransaction",
                column: "TransactionCodeID");

            migrationBuilder.CreateIndex(
                name: "UNI_BankTransactionCode_DisplayName",
                schema: "FinanceApp",
                table: "BankTransactionCode",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_BankTransactionCode_TransactionCode",
                schema: "FinanceApp",
                table: "BankTransactionCode",
                column: "TransactionCode",
                unique: true,
                filter: "([TransactionCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionCodeAttributeMemberEntry_AttributeMemberID",
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionCodeAttributeMemberEntry_TransactionCodeID",
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                column: "TransactionCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransaction_AccountID",
                schema: "FinanceApp",
                table: "BrokerTransaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransaction_DepSecurityID",
                schema: "FinanceApp",
                table: "BrokerTransaction",
                column: "DepSecurityID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransaction_SecurityID",
                schema: "FinanceApp",
                table: "BrokerTransaction",
                column: "SecurityID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransaction_TaxLotID",
                schema: "FinanceApp",
                table: "BrokerTransaction",
                column: "TaxLotID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransaction_TransactionCodeID",
                schema: "FinanceApp",
                table: "BrokerTransaction",
                column: "TransactionCodeID");

            migrationBuilder.CreateIndex(
                name: "UNI_BrokerTransactionCode_DisplayName",
                schema: "FinanceApp",
                table: "BrokerTransactionCode",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_BrokerTransactionCode_TransactionCode",
                schema: "FinanceApp",
                table: "BrokerTransactionCode",
                column: "TransactionCode",
                unique: true,
                filter: "([TransactionCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransactionCodeAttributeMemberEntry_AttributeMemberID",
                schema: "FinanceApp",
                table: "BrokerTransactionCodeAttributeMemberEntry",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerTransactionCodeAttributeMemberEntry_TransactionCodeID",
                schema: "FinanceApp",
                table: "BrokerTransactionCodeAttributeMemberEntry",
                column: "TransactionCodeID");

            migrationBuilder.CreateIndex(
                name: "UNI_Country_DisplayName",
                schema: "FinanceApp",
                table: "Country",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_Country_IsoCode3",
                schema: "FinanceApp",
                table: "Country",
                column: "IsoCode3",
                unique: true,
                filter: "([IsoCode3] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_CountryAttributeMemberEntry_CountryID",
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPerformanceAttributeMemberEntry_AccountObjectID",
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                column: "AccountObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPerformanceAttributeMemberEntry_AttributeMemberID",
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPerformanceEntry_AccountObjectID",
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                column: "AccountObjectID");

            migrationBuilder.CreateIndex(
                name: "UNI_InvestmentStrategy_DisplayName",
                schema: "FinanceApp",
                table: "InvestmentStrategy",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentStrategyTarget_AttributeMemberID",
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentStrategyTarget_InvestmentStrategyID",
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                column: "InvestmentStrategyID");

            migrationBuilder.CreateIndex(
                name: "UNI_MarketHoliday_MarketHolidayName",
                schema: "FinanceApp",
                table: "MarketHoliday",
                column: "MarketHolidayName",
                unique: true,
                filter: "([MarketHolidayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_MarketHolidaySchedule_MarketHolidayID",
                schema: "FinanceApp",
                table: "MarketHolidayObservance",
                column: "MarketHolidayID");

            migrationBuilder.CreateIndex(
                name: "UNI_MarketIndex_IndexCode",
                schema: "FinanceApp",
                table: "MarketIndex",
                column: "IndexCode",
                unique: true,
                filter: "([IndexCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndexPrice_MarketIndexID",
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                column: "MarketIndexID");

            migrationBuilder.CreateIndex(
                name: "UNI_MarketIndexPrice_RowDef",
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "PriceDate", "MarketIndexID", "PriceCode" },
                unique: true,
                filter: "([PriceCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_ModelAttribute_DisplayName",
                schema: "FinanceApp",
                table: "ModelAttribute",
                column: "DisplayName",
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ModelAttributeMember_AttributeID",
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                column: "AttributeID");

            migrationBuilder.CreateIndex(
                name: "UNI_ModelAttributeMember_RowDef",
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "DisplayName", "AttributeID" },
                unique: true,
                filter: "([DisplayName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_ReportConfiguration_ConfigurationCode",
                schema: "FinanceApp",
                table: "ReportConfiguration",
                column: "ConfigurationCode",
                unique: true,
                filter: "([ConfigurationCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_ReportStyleSheet_StyleSheetCode",
                schema: "FinanceApp",
                table: "ReportStyleSheet",
                column: "StyleSheetCode",
                unique: true,
                filter: "([StyleSheetCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Security_SecurityExchangeID",
                schema: "FinanceApp",
                table: "Security",
                column: "SecurityExchangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Security_SecurityTypeID",
                schema: "FinanceApp",
                table: "Security",
                column: "SecurityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAttributeMemberEntry_AttributeMemberID",
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                column: "AttributeMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAttributeMemberEntry_SecurityID",
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                column: "SecurityID");

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityExchange_ExchangeCode",
                schema: "FinanceApp",
                table: "SecurityExchange",
                column: "ExchangeCode",
                unique: true,
                filter: "([ExchangeCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityPrice_SecurityID",
                schema: "FinanceApp",
                table: "SecurityPrice",
                column: "SecurityID");

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityPrice_RowDef",
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceDate", "SecurityID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecuritySymbol_SymbolTypeID",
                schema: "FinanceApp",
                table: "SecuritySymbol",
                column: "SymbolTypeID");

            migrationBuilder.CreateIndex(
                name: "UNI_SecuritySymbol_Column",
                schema: "FinanceApp",
                table: "SecuritySymbol",
                columns: new[] { "SecurityID", "EffectiveDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecuritySymbolMap_AccountCustodianID",
                schema: "FinanceApp",
                table: "SecuritySymbolMap",
                column: "AccountCustodianID");

            migrationBuilder.CreateIndex(
                name: "UNI_SecuritySymbolMap_RowDef",
                schema: "FinanceApp",
                table: "SecuritySymbolMap",
                columns: new[] { "SecuritySymbolID", "AccountCustodianID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_SecuritySymbolType_TypeName",
                schema: "FinanceApp",
                table: "SecuritySymbolType",
                column: "SymbolTypeName",
                unique: true,
                filter: "([SymbolTypeName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityType_SecurityTypeGroupID",
                schema: "FinanceApp",
                table: "SecurityType",
                column: "SecurityTypeGroupID");

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityType_SecurityTypeName",
                schema: "FinanceApp",
                table: "SecurityType",
                column: "SecurityTypeName",
                unique: true,
                filter: "([SecurityTypeName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityTypeGroup_SecurityTypeGroupName",
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                column: "SecurityTypeGroupName",
                unique: true,
                filter: "([SecurityTypeGroupName] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AccountCompositeMember",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AccountWallet",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AuditEvent",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BankTransaction",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BankTransactionCodeAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BrokerTransaction",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BrokerTransactionCodeAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "CountryAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "InvestmentPerformanceAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "InvestmentPerformanceEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "InvestmentStrategyTarget",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "MarketHolidayObservance",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "MarketIndexPrice",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ModelAttributeScope",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ReportConfiguration",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ReportStyleSheet",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ResourceImage",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecurityAttributeMemberEntry",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecurityPrice",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecuritySymbolMap",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AccountComposite",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BankTransactionCode",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "BrokerTransactionCode",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "InvestmentStrategy",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "MarketHoliday",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "MarketIndex",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecuritySymbol",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AccountCustodian",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "AccountObject",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "Security",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecuritySymbolType",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecurityExchange",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecurityType",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "SecurityTypeGroup",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ModelAttributeMember",
                schema: "FinanceApp");

            migrationBuilder.DropTable(
                name: "ModelAttribute",
                schema: "FinanceApp");

            migrationBuilder.DropSequence(
                name: "seqAuditEventID",
                schema: "FinanceApp");

            migrationBuilder.DropSequence(
                name: "seqModelAttributeMember",
                schema: "FinanceApp");
        }
    }
}
