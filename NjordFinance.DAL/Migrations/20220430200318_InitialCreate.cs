using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordFinance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FinanceApp");

            migrationBuilder.CreateSequence(
                name: "seqAuditEventID",
                schema: "FinanceApp",
                minValue: 1L);

            migrationBuilder.CreateTable(
                name: "AccountCustodian",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountCustodianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustodianCode = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(72)", unicode: false, maxLength: 72, nullable: true)
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
                    AccountObjectCode = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    ObjectType = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "date", nullable: true),
                    ObjectDisplayName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    ObjectDescription = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    PrefixedObjectCode = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true, computedColumnSql: "(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountObject", x => x.AccountObjectID);
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
                    TransactionCode = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
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
                    TransactionCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    CashEffect = table.Column<byte>(type: "tinyint", nullable: false),
                    ContributionWithdrawalEffect = table.Column<byte>(type: "tinyint", nullable: false),
                    QuantityEffect = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerTransactionCode", x => x.TransactionCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "FinanceApp",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsoCode3 = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentStrategy",
                schema: "FinanceApp",
                columns: table => new
                {
                    InvestmentStrategyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
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
                    MarketHolidayName = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: true)
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
                    IndexCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IndexDescription = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true)
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
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
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
                    ConfigurationCode = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    ConfigurationDescription = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    XmlDefinition = table.Column<string>(type: "xml", nullable: true)
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
                    StyleSheetCode = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    StyleSheetDescription = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    XmlDefinition = table.Column<string>(type: "xml", nullable: true)
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
                    ImageDescription = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ImageBinary = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true)
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
                    ExchangeCode = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    ExchangeDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
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
                    SymbolTypeName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuritySymbolType", x => x.SymbolTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SecurityTypeGroup",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityTypeGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityTypeGroupName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    DisplayOrder = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityTypeGroup", x => x.SecurityTypeGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true, collation: "Latin1_General_BIN2"),
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
                        name: "FK_Account_AccountObject",
                        column: x => x.AccountID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID");
                });

            migrationBuilder.CreateTable(
                name: "AccountComposite",
                schema: "FinanceApp",
                columns: table => new
                {
                    AccountCompositeID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
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
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_InvestmentPerformanceEntry", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_InvestmentPerformanceEntry_AccountObject",
                        column: x => x.AccountObjectID,
                        principalSchema: "FinanceApp",
                        principalTable: "AccountObject",
                        principalColumn: "AccountObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketHolidaySchedule",
                schema: "FinanceApp",
                columns: table => new
                {
                    MarketHolidayEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketHolidayID = table.Column<int>(type: "int", nullable: false),
                    ObservanceDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketHolidayScheduleEntry", x => x.MarketHolidayEntryID);
                    table.ForeignKey(
                        name: "FK_MarketHolidayScheduleMarketHoliday",
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
                    PriceCode = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketIndexPrice", x => x.IndexPriceID);
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
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: true)
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
                    AttributeScopeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    ScopeCode = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttributeScope", x => x.AttributeScopeID);
                    table.ForeignKey(
                        name: "FK_ModelAttributeScope_ModelAttribute",
                        column: x => x.AttributeID,
                        principalSchema: "FinanceApp",
                        principalTable: "ModelAttribute",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityType",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityTypeGroupID = table.Column<int>(type: "int", nullable: false),
                    SecurityTypeName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    ValuationFactor = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    CanHaveDerivative = table.Column<bool>(type: "bit", nullable: false),
                    CanHavePosition = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityType", x => x.SecurityTypeID);
                    table.ForeignKey(
                        name: "FK_SecurityType_SecurityTypeGroup",
                        column: x => x.SecurityTypeGroupID,
                        principalSchema: "FinanceApp",
                        principalTable: "SecurityTypeGroup",
                        principalColumn: "SecurityTypeGroupID");
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
                    Comment = table.Column<string>(type: "varchar(72)", unicode: false, maxLength: 72, nullable: true),
                    TransactionVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCompositeID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "date", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCommpositeMember", x => x.MemberID);
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
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    AccountObjectID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAttributeMemberEntry", x => x.EntryID);
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
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionCodeAttributeMemberEntry", x => x.EntryID);
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
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    TransactionCodeID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerTransactionAttributeMemberEntry", x => x.EntryID);
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
                name: "CountryAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAttributeMemberEntry", x => x.EntryID);
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
                name: "InvestmentPerformanceAttributeMemberEntry",
                schema: "FinanceApp",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_InvestmentPerformanceAttributeMemberEntry", x => x.EntryID);
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
                    InvestmentStrategyTargetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestmentStrategyID = table.Column<int>(type: "int", nullable: false),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    TargetPercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentStrategyTarget", x => x.InvestmentStrategyTargetID);
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
                name: "Security",
                schema: "FinanceApp",
                columns: table => new
                {
                    SecurityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityTypeID = table.Column<int>(type: "int", nullable: false),
                    SecurityExchangeID = table.Column<int>(type: "int", nullable: true),
                    SecurityDescription = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
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
                    AddressCode = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true, collation: "Latin1_General_BIN2"),
                    AddressTag = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true, collation: "Latin1_General_BIN2"),
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
                    TransactionCodeID = table.Column<int>(type: "int", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "date", nullable: false),
                    SettleDate = table.Column<DateTime>(type: "date", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "date", nullable: true),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(19,6)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
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
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeMemberID = table.Column<int>(type: "int", nullable: false),
                    SecurityID = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAttributeMemberEntry", x => x.EntryID);
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
                    SymbolCode = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, computedColumnSql: "(case when [SecuritySymbol].[SymbolTypeID]=(-10) then [SecuritySymbol].[Cusip] when [SecuritySymbol].[SymbolTypeID]=(-20) then [SecuritySymbol].[CustomSymbol] when [SecuritySymbol].[SymbolTypeID]=(-30) then [SecuritySymbol].[OptionTicker] when [SecuritySymbol].[SymbolTypeID]=(-40) then [SecuritySymbol].[Ticker]  end)", stored: false),
                    Cusip = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: true),
                    CustomSymbol = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    OptionTicker = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    Ticker = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
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
                    SymbolMapID = table.Column<int>(type: "int", nullable: false),
                    AccountCustodianID = table.Column<int>(type: "int", nullable: false),
                    CustodianSymbol = table.Column<string>(type: "varchar(72)", unicode: false, maxLength: 72, nullable: true),
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
                table: "AccountCustodian",
                columns: new[] { "AccountCustodianID", "CustodianCode", "DisplayName" },
                values: new object[,]
                {
                    { -102, "CRYPTO", "Cryptopotamus Coin Exchange" },
                    { -101, "SOMENAME", "Some Name Securities Broker" },
                    { -100, "SOMEWHERE", "SomeWhere Bank LLC" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountObject",
                columns: new[] { "AccountObjectID", "AccountObjectCode", "CloseDate", "ObjectDescription", "ObjectDisplayName", "ObjectType", "StartDate" },
                values: new object[,]
                {
                    { -102, "TESTCRYPTO", null, "For testing functionality of crypto broker account records.", "Testt Crypto Account", "a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -101, "TESTBANK", null, "For testing functionality of bank account records.", "Test Bank Account", "a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -100, "TESTBROKER", null, "For testing functionality of broker acccount records.", "Test Broker Account", "a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[,]
                {
                    { -400, "Japan", "JPN" },
                    { -300, "Canada", "CAN" },
                    { -200, "Germany", "DEU" },
                    { -100, "United States of America", "USA" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityExchange",
                columns: new[] { "ExchangeID", "ExchangeCode", "ExchangeDescription" },
                values: new object[,]
                {
                    { -200, "NASDAQ", "Nasdaq Stock Market" },
                    { -100, "NYSE", "New York Stock Exchange" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecuritySymbolType",
                columns: new[] { "SymbolTypeID", "SymbolTypeName" },
                values: new object[,]
                {
                    { -40, "Ticker" },
                    { -30, "Option Ticker" },
                    { -20, "Custom Identifer" },
                    { -10, "CUSIP" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                columns: new[] { "SecurityTypeGroupID", "DisplayOrder", "SecurityTypeGroupName" },
                values: new object[,]
                {
                    { -300, (byte)2, "Digital Assets" },
                    { -200, (byte)1, "Option Contracts" },
                    { -100, (byte)0, "Individual Stock" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Account",
                columns: new[] { "AccountID", "AccountCustodianID", "AccountNumber", "BooksClosedDate", "HasBankTransaction", "HasBrokerTransaction", "HasWallet", "IsComplianceTradable" },
                values: new object[,]
                {
                    { -102, -102, null, null, false, true, true, true },
                    { -101, -102, null, null, false, true, false, true },
                    { -100, null, null, null, true, false, false, false }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityType",
                columns: new[] { "SecurityTypeID", "CanHaveDerivative", "CanHavePosition", "DisplayOrder", "SecurityTypeGroupID", "SecurityTypeName", "ValuationFactor" },
                values: new object[,]
                {
                    { -500, false, false, (byte)3, -200, "Cryptocurrency", 1m },
                    { -400, false, false, (byte)3, -200, "Cash", 1m },
                    { -300, false, true, (byte)2, -200, "Put option", 1m },
                    { -200, false, true, (byte)1, -200, "Call option", 1m },
                    { -100, true, true, (byte)0, -100, "Common stock", 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Security",
                columns: new[] { "SecurityID", "HasPerpetualMarket", "HasPerpetualPrice", "Issuer", "SecurityDescription", "SecurityExchangeID", "SecurityTypeID" },
                values: new object[,]
                {
                    { -105, true, false, null, "Ether", null, -500 },
                    { -104, true, false, null, "Litecoin", null, -500 },
                    { -103, true, false, null, "Bitcoin", null, -500 },
                    { -102, false, false, null, "JP Morgan Chase Co.", null, -100 },
                    { -101, false, false, null, "Apple Inc.", -200, -100 },
                    { -100, false, false, null, "Microsoft Inc.", -200, -100 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                columns: new[] { "SymbolID", "Cusip", "CustomSymbol", "EffectiveDate", "OptionTicker", "SecurityID", "SymbolTypeID", "Ticker" },
                values: new object[,]
                {
                    { -105, null, "ETH", new DateTime(2013, 6, 7, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(180), null, -105, -20, null },
                    { -104, null, "LTC", new DateTime(2016, 3, 3, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(148), null, -104, -20, null },
                    { -103, null, "BTC", new DateTime(2013, 5, 17, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(140), null, -103, -20, null },
                    { -102, null, null, new DateTime(2001, 11, 27, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(134), null, -102, -40, "JPM" },
                    { -101, null, null, new DateTime(2001, 6, 13, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(129), null, -101, -40, "AAPL" },
                    { -100, null, null, new DateTime(2003, 4, 12, 16, 3, 18, 603, DateTimeKind.Local).AddTicks(88), null, -100, -40, "MSFT" }
                });

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
                name: "UNI_AccountAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                columns: new[] { "EffectiveDate", "AccountObjectID", "AttributeMemberID" },
                unique: true);

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
                name: "UNI_AccountCompositeMember_RowDef",
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                columns: new[] { "EntryDate", "AccountID", "AccountCompositeID" });

            migrationBuilder.CreateIndex(
                name: "UNI_AccountCustodian_CustodianCode",
                schema: "FinanceApp",
                table: "AccountCustodian",
                column: "CustodianCode",
                unique: true,
                filter: "[CustodianCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountCustodian_DisplayName",
                schema: "FinanceApp",
                table: "AccountCustodian",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_AccountObject_AccountObjectCode",
                schema: "FinanceApp",
                table: "AccountObject",
                column: "AccountObjectCode",
                unique: true,
                filter: "[AccountObjectCode] IS NOT NULL");

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
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_BankTransactionCode_TransactionCode",
                schema: "FinanceApp",
                table: "BankTransactionCode",
                column: "TransactionCode",
                unique: true,
                filter: "[TransactionCode] IS NOT NULL");

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
                name: "UNI_BankTransactionCodeAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                columns: new[] { "EffectiveDate", "TransactionCodeID", "AttributeMemberID" },
                unique: true);

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
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_BrokerTransactionCode_TransactionCode",
                schema: "FinanceApp",
                table: "BrokerTransactionCode",
                column: "TransactionCode",
                unique: true,
                filter: "[TransactionCode] IS NOT NULL");

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
                name: "UNI_BrokerTransactionCodeAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "BrokerTransactionCodeAttributeMemberEntry",
                columns: new[] { "EffectiveDate", "TransactionCodeID", "AttributeMemberID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_Country_DisplayName",
                schema: "FinanceApp",
                table: "Country",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_Country_IsoCode3",
                schema: "FinanceApp",
                table: "Country",
                column: "IsoCode3",
                unique: true,
                filter: "[IsoCode3] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CountryAttributeMemberEntry_CountryID",
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UNI_CountryAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                unique: true);

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
                name: "UNI_InvestmentPerformanceAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "FromDate", "AccountObjectID", "AttributeMemberID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPerformanceEntry_AccountObjectID",
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                column: "AccountObjectID");

            migrationBuilder.CreateIndex(
                name: "UNI_InvestmentPerformanceEntry_RowDef",
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                columns: new[] { "FromDate", "AccountObjectID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_InvestmentStrategy_DisplayName",
                schema: "FinanceApp",
                table: "InvestmentStrategy",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

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
                name: "UNI_InvestmentStrategyTarget_RowDef",
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                columns: new[] { "EffectiveDate", "AttributeMemberID", "InvestmentStrategyID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_MarketHoliday_MarketHolidayName",
                schema: "FinanceApp",
                table: "MarketHoliday",
                column: "MarketHolidayName",
                unique: true,
                filter: "[MarketHolidayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MarketHolidaySchedule_MarketHolidayID",
                schema: "FinanceApp",
                table: "MarketHolidaySchedule",
                column: "MarketHolidayID");

            migrationBuilder.CreateIndex(
                name: "UNI_MarketHolidaySchedule_RowDef",
                schema: "FinanceApp",
                table: "MarketHolidaySchedule",
                columns: new[] { "ObservanceDate", "MarketHolidayID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_MarketIndex_IndexCode",
                schema: "FinanceApp",
                table: "MarketIndex",
                column: "IndexCode",
                unique: true,
                filter: "[IndexCode] IS NOT NULL");

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
                filter: "[PriceCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_ModelAttribute_DisplayName",
                schema: "FinanceApp",
                table: "ModelAttribute",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

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
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_ModelAttributeScope_AttributeID_ScopeCode",
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                columns: new[] { "AttributeID", "ScopeCode" },
                unique: true,
                filter: "[ScopeCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_ReportConfiguration_ConfigurationCode",
                schema: "FinanceApp",
                table: "ReportConfiguration",
                column: "ConfigurationCode",
                unique: true,
                filter: "[ConfigurationCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_ReportStyleSheet_StyleSheetCode",
                schema: "FinanceApp",
                table: "ReportStyleSheet",
                column: "StyleSheetCode",
                unique: true,
                filter: "[StyleSheetCode] IS NOT NULL");

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
                name: "UNI_SecurityAttributeMemberEntry_RowDef",
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                columns: new[] { "EffectiveDate", "SecurityID", "AttributeMemberID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityExchange_ExchangeCode",
                schema: "FinanceApp",
                table: "SecurityExchange",
                column: "ExchangeCode",
                unique: true,
                filter: "[ExchangeCode] IS NOT NULL");

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
                filter: "[SymbolTypeName] IS NOT NULL");

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
                filter: "[SecurityTypeName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNI_SecurityTypeGroup_SecurityTypeGroupName",
                schema: "FinanceApp",
                table: "SecurityTypeGroup",
                column: "SecurityTypeGroupName",
                unique: true,
                filter: "[SecurityTypeGroupName] IS NOT NULL");
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
                name: "MarketHolidaySchedule",
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
                name: "ModelAttributeMember",
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
                name: "ModelAttribute",
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

            migrationBuilder.DropSequence(
                name: "seqAuditEventID",
                schema: "FinanceApp");
        }
    }
}
