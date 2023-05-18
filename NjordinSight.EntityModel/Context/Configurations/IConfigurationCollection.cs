using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.ConstraintType;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    /// Allows for storing multiple <see cref="IEntityConfiguration{TEntity}"/> instances for 
    /// different entity types to be applied later by the caller.
    /// </summary>
    public partial interface IConfigurationCollection : IEnumerable<Action<ModelBuilder>>
    {
        /// <summary>
        /// Adds a new <see cref="Action"/> accepting <see cref="ModelBuilder"/> input that applies 
        /// the given <see cref="IEntityConfiguration{TEntity}"/>. The action is invoked by the caller, 
        /// typically be iterating over the <see cref="IConfigurationCollection"/> instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"><paramref name="configuration"/> was null.</exception>
        void AddConfiguration<T>(IEntityConfiguration<T> configuration) where T : class;

        /// <summary>
        /// Tests the <see cref="IConfigurationCollection"/> for valid 
        /// <see cref="IEntityConfiguration{TEntity}"/> registrations. 
        /// </summary>
        /// <param name="validationMessages">Output collection descriing validations failures. 
        /// The first entry is a summary message. If valid the collection is empty.</param>
        /// <returns>True if there are no conflicting keys found in the registrations, else false.</returns>
        bool IsValid(out IEnumerable<string> validationMessages);

        /// <summary>
        /// Creates a new instance of <see cref="IConfigurationCollection"/> with built-in 
        /// entities configured for seeding the data store.
        /// </summary>
        /// <returns>A <see cref="IConfigurationCollection"/>.</returns>
        /// <remarks>
        /// The entities configuration by the <see cref="IConfigurationCollection"/> returned are:
        /// <list type="bullet">
        /// <item><see cref="BrokerTransactionCode"/></item>
        /// <item><see cref="BrokerTransactionCodeAttributeMemberEntry"/></item>
        /// <item><see cref="Country"/></item>
        /// <item><see cref="MarketHoliday"/></item>
        /// <item><see cref="MarketHolidayObservance"/></item>
        /// <item><see cref="ModelAttribute"/></item>
        /// <item><see cref="ModelAttributeMember"/></item>
        /// <item><see cref="ModelAttributeScope"/></item>
        /// <item><see cref="Security"/></item>
        /// <item><see cref="SecurityType"/></item>
        /// <item><see cref="SecurityTypeGroup"/></item>
        /// <item><see cref="SecuritySymbolType"/></item>
        /// </list>
        /// </remarks>
        public static IConfigurationCollection GetBuiltInDataConfiguration()
        {
            Guid guid = Guid.Parse("{3BB2DFAB-16C8-416B-B448-987AF5644FA0}");
            var _configurationCollection = new ConfigurationCollection();

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<BrokerTransactionCode>(
                    sourceGuid: guid,
                    new BrokerTransactionCode[]
                    {
                        new()
                        {
                            TransactionCodeId = -10,
                            TransactionCode = "btc",
                            DisplayName = "Buy to cover",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = 1
                        },
                        new()
                        {
                            TransactionCodeId = -11,
                            TransactionCode = "buy",
                            DisplayName = "Buy",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = 1
                        },
                        new()
                        {
                            TransactionCodeId = -12,
                            TransactionCode = "dep",
                            DisplayName = "Deposit",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 1,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -13,
                            TransactionCode = "div",
                            DisplayName = "Dividend",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -14,
                            TransactionCode = "exp",
                            DisplayName = "Expense",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = -1,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -15,
                            TransactionCode = "frt",
                            DisplayName = "Forfeit shares",
                            CashEffect = 0,
                            ContributionWithdrawalEffect = -1,
                            QuantityEffect = -1
                        },
                        new()
                        {
                            TransactionCodeId = -16,
                            TransactionCode = "int",
                            DisplayName = "Interest",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -17,
                            TransactionCode = "dli",
                            DisplayName = "Deliver-in",
                            CashEffect = 0,
                            ContributionWithdrawalEffect = 1,
                            QuantityEffect = 1
                        },
                        new()
                        {
                            TransactionCodeId = -18,
                            TransactionCode = "dlo",
                            DisplayName = "Deliver-out",
                            CashEffect = 0,
                            ContributionWithdrawalEffect = -1,
                            QuantityEffect = -1
                        },
                        new()
                        {
                            TransactionCodeId = -19,
                            TransactionCode = "pdn",
                            DisplayName = "Pay-down",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = -1
                        },
                        new()
                        {
                            TransactionCodeId = -20,
                            TransactionCode = "sll",
                            DisplayName = "Sale",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = -1
                        },
                        new()
                        {
                            TransactionCodeId = -21,
                            TransactionCode = "ssl",
                            DisplayName = "Short sale",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = -1
                        },
                        new()
                        {
                            TransactionCodeId = -22,
                            TransactionCode = "wth",
                            DisplayName = "Withdrawal",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = -1,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -23,
                            TransactionCode = "chn",
                            DisplayName = "Change in value",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 1,
                            QuantityEffect = 1
                        },
                        new()
                        {
                            TransactionCodeId = -24,
                            TransactionCode = "plc",
                            DisplayName = "Plan contribution",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 1,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -25,
                            TransactionCode = "ain",
                            DisplayName = "Accrued interest",
                            CashEffect = -1,
                            ContributionWithdrawalEffect = -1,
                            QuantityEffect = 0
                        },
                        new()
                        {
                            TransactionCodeId = -26,
                            TransactionCode = "cap",
                            DisplayName = "Capital return",
                            CashEffect = 1,
                            ContributionWithdrawalEffect = 0,
                            QuantityEffect = 0
                        }
                    }
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<BrokerTransactionCodeAttributeMemberEntry>(
                    sourceGuid: guid,
                    new BrokerTransactionCodeAttributeMemberEntry[]
                    {
                        // Transaction category attribute assignment
                        new(){ AttributeMemberId = -401, TransactionCodeId = -25, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -402, TransactionCodeId = -11, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -403, TransactionCodeId = -10, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -404, TransactionCodeId = -26, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -405, TransactionCodeId = -23, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -406, TransactionCodeId = -17, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -407, TransactionCodeId = -18, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -406, TransactionCodeId = -12, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -408, TransactionCodeId = -13, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -409, TransactionCodeId = -14, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -410, TransactionCodeId = -15, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -411, TransactionCodeId = -16, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -412, TransactionCodeId = -19, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -406, TransactionCodeId = -24, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -414, TransactionCodeId = -20, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -407, TransactionCodeId = -21, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -407, TransactionCodeId = -22, EffectiveDate = DateTime.MinValue, Weight = 1M },

                        // Transaction class attribute assignment
                        new(){ AttributeMemberId = -501, TransactionCodeId = -25, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -502, TransactionCodeId = -11, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -502, TransactionCodeId = -10, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -503, TransactionCodeId = -26, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -504, TransactionCodeId = -23, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -505, TransactionCodeId = -17, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -505, TransactionCodeId = -18, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -505, TransactionCodeId = -12, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -503, TransactionCodeId = -13, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -501, TransactionCodeId = -14, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -506, TransactionCodeId = -15, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -503, TransactionCodeId = -16, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -503, TransactionCodeId = -19, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -505, TransactionCodeId = -24, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -502, TransactionCodeId = -20, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -502, TransactionCodeId = -21, EffectiveDate = DateTime.MinValue, Weight = 1M },
                        new(){ AttributeMemberId = -505, TransactionCodeId = -22, EffectiveDate = DateTime.MinValue, Weight = 1M }
                    }
                ));

            var Countries = new Country[]
            {
                new(){ CountryId = -600, DisplayName = "Afghanistan", IsoCode3 = "AFG" },
                new(){ CountryId = -601, DisplayName = "Albania", IsoCode3 = "ALB" },
                new(){ CountryId = -602, DisplayName = "Algeria", IsoCode3 = "DZA" },
                new(){ CountryId = -603, DisplayName = "American Samoa", IsoCode3 = "ASM" },
                new(){ CountryId = -604, DisplayName = "Andorra", IsoCode3 = "AND" },
                new(){ CountryId = -605, DisplayName = "Angola", IsoCode3 = "AGO" },
                new(){ CountryId = -606, DisplayName = "Anguilla", IsoCode3 = "AIA" },
                new(){ CountryId = -607, DisplayName = "Antarctica", IsoCode3 = "ATA" },
                new(){ CountryId = -608, DisplayName = "Antigua and Barbuda", IsoCode3 = "ATG" },
                new(){ CountryId = -609, DisplayName = "Argentina", IsoCode3 = "ARG" },
                new(){ CountryId = -610, DisplayName = "Armenia", IsoCode3 = "ARM" },
                new(){ CountryId = -611, DisplayName = "Aruba", IsoCode3 = "ABW" },
                new(){ CountryId = -612, DisplayName = "Australia", IsoCode3 = "AUS" },
                new(){ CountryId = -613, DisplayName = "Austria", IsoCode3 = "AUT" },
                new(){ CountryId = -614, DisplayName = "Azerbaijan", IsoCode3 = "AZE" },
                new(){ CountryId = -615, DisplayName = "Bahamas (the)", IsoCode3 = "BHS" },
                new(){ CountryId = -616, DisplayName = "Bahrain", IsoCode3 = "BHR" },
                new(){ CountryId = -617, DisplayName = "Bangladesh", IsoCode3 = "BGD" },
                new(){ CountryId = -618, DisplayName = "Barbados", IsoCode3 = "BRB" },
                new(){ CountryId = -619, DisplayName = "Belarus", IsoCode3 = "BLR" },
                new(){ CountryId = -620, DisplayName = "Belgium", IsoCode3 = "BEL" },
                new(){ CountryId = -621, DisplayName = "Belize", IsoCode3 = "BLZ" },
                new(){ CountryId = -622, DisplayName = "Benin", IsoCode3 = "BEN" },
                new(){ CountryId = -623, DisplayName = "Bermuda", IsoCode3 = "BMU" },
                new(){ CountryId = -624, DisplayName = "Bhutan", IsoCode3 = "BTN" },
                new(){ CountryId = -625, DisplayName = "Bolivia (Plurinational State of)", IsoCode3 = "BOL" },
                new(){ CountryId = -626, DisplayName = "Bonaire, Sint Eustatius and Saba", IsoCode3 = "BES" },
                new(){ CountryId = -627, DisplayName = "Bosnia and Herzegovina", IsoCode3 = "BIH" },
                new(){ CountryId = -628, DisplayName = "Botswana", IsoCode3 = "BWA" },
                new(){ CountryId = -629, DisplayName = "Bouvet Island", IsoCode3 = "BVT" },
                new(){ CountryId = -630, DisplayName = "Brazil", IsoCode3 = "BRA" },
                new(){ CountryId = -631, DisplayName = "British Indian Ocean Territory (the)", IsoCode3 = "IOT" },
                new(){ CountryId = -632, DisplayName = "Brunei Darussalam", IsoCode3 = "BRN" },
                new(){ CountryId = -633, DisplayName = "Bulgaria", IsoCode3 = "BGR" },
                new(){ CountryId = -634, DisplayName = "Burkina Faso", IsoCode3 = "BFA" },
                new(){ CountryId = -635, DisplayName = "Burundi", IsoCode3 = "BDI" },
                new(){ CountryId = -636, DisplayName = "Cabo Verde", IsoCode3 = "CPV" },
                new(){ CountryId = -637, DisplayName = "Cambodia", IsoCode3 = "KHM" },
                new(){ CountryId = -638, DisplayName = "Cameroon", IsoCode3 = "CMR" },
                new(){ CountryId = -639, DisplayName = "Canada", IsoCode3 = "CAN" },
                new(){ CountryId = -640, DisplayName = "Cayman Islands (the)", IsoCode3 = "CYM" },
                new(){ CountryId = -641, DisplayName = "Central African Republic (the)", IsoCode3 = "CAF" },
                new(){ CountryId = -642, DisplayName = "Chad", IsoCode3 = "TCD" },
                new(){ CountryId = -643, DisplayName = "Chile", IsoCode3 = "CHL" },
                new(){ CountryId = -644, DisplayName = "China", IsoCode3 = "CHN" },
                new(){ CountryId = -645, DisplayName = "Christmas Island", IsoCode3 = "CXR" },
                new(){ CountryId = -646, DisplayName = "Cocos (Keeling) Islands (the)", IsoCode3 = "CCK" },
                new(){ CountryId = -647, DisplayName = "Colombia", IsoCode3 = "COL" },
                new(){ CountryId = -648, DisplayName = "Comoros (the)", IsoCode3 = "COM" },
                new(){ CountryId = -649, DisplayName = "Congo (the Democratic Republic of the)", IsoCode3 = "COD" },
                new(){ CountryId = -650, DisplayName = "Congo (the)", IsoCode3 = "COG" },
                new(){ CountryId = -651, DisplayName = "Cook Islands (the)", IsoCode3 = "COK" },
                new(){ CountryId = -652, DisplayName = "Costa Rica", IsoCode3 = "CRI" },
                new(){ CountryId = -653, DisplayName = "Croatia", IsoCode3 = "HRV" },
                new(){ CountryId = -654, DisplayName = "Cuba", IsoCode3 = "CUB" },
                new(){ CountryId = -655, DisplayName = "Curaçao", IsoCode3 = "CUW" },
                new(){ CountryId = -656, DisplayName = "Cyprus", IsoCode3 = "CYP" },
                new(){ CountryId = -657, DisplayName = "Czechia", IsoCode3 = "CZE" },
                new(){ CountryId = -658, DisplayName = "Côte d'Ivoire", IsoCode3 = "CIV" },
                new(){ CountryId = -659, DisplayName = "Denmark", IsoCode3 = "DNK" },
                new(){ CountryId = -660, DisplayName = "Djibouti", IsoCode3 = "DJI" },
                new(){ CountryId = -661, DisplayName = "Dominica", IsoCode3 = "DMA" },
                new(){ CountryId = -662, DisplayName = "Dominican Republic (the)", IsoCode3 = "DOM" },
                new(){ CountryId = -663, DisplayName = "Ecuador", IsoCode3 = "ECU" },
                new(){ CountryId = -664, DisplayName = "Egypt", IsoCode3 = "EGY" },
                new(){ CountryId = -665, DisplayName = "El Salvador", IsoCode3 = "SLV" },
                new(){ CountryId = -666, DisplayName = "Equatorial Guinea", IsoCode3 = "GNQ" },
                new(){ CountryId = -667, DisplayName = "Eritrea", IsoCode3 = "ERI" },
                new(){ CountryId = -668, DisplayName = "Estonia", IsoCode3 = "EST" },
                new(){ CountryId = -669, DisplayName = "Eswatini", IsoCode3 = "SWZ" },
                new(){ CountryId = -670, DisplayName = "Ethiopia", IsoCode3 = "ETH" },
                new(){ CountryId = -671, DisplayName = "Falkland Islands (the) [Malvinas]", IsoCode3 = "FLK" },
                new(){ CountryId = -672, DisplayName = "Faroe Islands (the)", IsoCode3 = "FRO" },
                new(){ CountryId = -673, DisplayName = "Fiji", IsoCode3 = "FJI" },
                new(){ CountryId = -674, DisplayName = "Finland", IsoCode3 = "FIN" },
                new(){ CountryId = -675, DisplayName = "France", IsoCode3 = "FRA" },
                new(){ CountryId = -676, DisplayName = "French Guiana", IsoCode3 = "GUF" },
                new(){ CountryId = -677, DisplayName = "French Polynesia", IsoCode3 = "PYF" },
                new(){ CountryId = -678, DisplayName = "French Southern Territories (the)", IsoCode3 = "ATF" },
                new(){ CountryId = -679, DisplayName = "Gabon", IsoCode3 = "GAB" },
                new(){ CountryId = -680, DisplayName = "Gambia (the)", IsoCode3 = "GMB" },
                new(){ CountryId = -681, DisplayName = "Georgia", IsoCode3 = "GEO" },
                new(){ CountryId = -682, DisplayName = "Germany", IsoCode3 = "DEU" },
                new(){ CountryId = -683, DisplayName = "Ghana", IsoCode3 = "GHA" },
                new(){ CountryId = -684, DisplayName = "Gibraltar", IsoCode3 = "GIB" },
                new(){ CountryId = -685, DisplayName = "Greece", IsoCode3 = "GRC" },
                new(){ CountryId = -686, DisplayName = "Greenland", IsoCode3 = "GRL" },
                new(){ CountryId = -687, DisplayName = "Grenada", IsoCode3 = "GRD" },
                new(){ CountryId = -688, DisplayName = "Guadeloupe", IsoCode3 = "GLP" },
                new(){ CountryId = -689, DisplayName = "Guam", IsoCode3 = "GUM" },
                new(){ CountryId = -690, DisplayName = "Guatemala", IsoCode3 = "GTM" },
                new(){ CountryId = -691, DisplayName = "Guernsey", IsoCode3 = "GGY" },
                new(){ CountryId = -692, DisplayName = "Guinea", IsoCode3 = "GIN" },
                new(){ CountryId = -693, DisplayName = "Guinea-Bissau", IsoCode3 = "GNB" },
                new(){ CountryId = -694, DisplayName = "Guyana", IsoCode3 = "GUY" },
                new(){ CountryId = -695, DisplayName = "Haiti", IsoCode3 = "HTI" },
                new(){ CountryId = -696, DisplayName = "Heard Island and McDonald Islands", IsoCode3 = "HMD" },
                new(){ CountryId = -697, DisplayName = "Holy See (the)", IsoCode3 = "VAT" },
                new(){ CountryId = -698, DisplayName = "Honduras", IsoCode3 = "HND" },
                new(){ CountryId = -699, DisplayName = "Hong Kong", IsoCode3 = "HKG" },
                new(){ CountryId = -700, DisplayName = "Hungary", IsoCode3 = "HUN" },
                new(){ CountryId = -701, DisplayName = "Iceland", IsoCode3 = "ISL" },
                new(){ CountryId = -702, DisplayName = "India", IsoCode3 = "IND" },
                new(){ CountryId = -703, DisplayName = "Indonesia", IsoCode3 = "IDN" },
                new(){ CountryId = -704, DisplayName = "Iran (Islamic Republic of)", IsoCode3 = "IRN" },
                new(){ CountryId = -705, DisplayName = "Iraq", IsoCode3 = "IRQ" },
                new(){ CountryId = -706, DisplayName = "Ireland", IsoCode3 = "IRL" },
                new(){ CountryId = -707, DisplayName = "Isle of Man", IsoCode3 = "IMN" },
                new(){ CountryId = -708, DisplayName = "Israel", IsoCode3 = "ISR" },
                new(){ CountryId = -709, DisplayName = "Italy", IsoCode3 = "ITA" },
                new(){ CountryId = -710, DisplayName = "Jamaica", IsoCode3 = "JAM" },
                new(){ CountryId = -711, DisplayName = "Japan", IsoCode3 = "JPN" },
                new(){ CountryId = -712, DisplayName = "Jersey", IsoCode3 = "JEY" },
                new(){ CountryId = -713, DisplayName = "Jordan", IsoCode3 = "JOR" },
                new(){ CountryId = -714, DisplayName = "Kazakhstan", IsoCode3 = "KAZ" },
                new(){ CountryId = -715, DisplayName = "Kenya", IsoCode3 = "KEN" },
                new(){ CountryId = -716, DisplayName = "Kiribati", IsoCode3 = "KIR" },
                new(){ CountryId = -717, DisplayName = "Korea (the Democratic People's Republic of)", IsoCode3 = "PRK" },
                new(){ CountryId = -718, DisplayName = "Korea (the Republic of)", IsoCode3 = "KOR" },
                new(){ CountryId = -719, DisplayName = "Kuwait", IsoCode3 = "KWT" },
                new(){ CountryId = -720, DisplayName = "Kyrgyzstan", IsoCode3 = "KGZ" },
                new(){ CountryId = -721, DisplayName = "Lao People's Democratic Republic (the)", IsoCode3 = "LAO" },
                new(){ CountryId = -722, DisplayName = "Latvia", IsoCode3 = "LVA" },
                new(){ CountryId = -723, DisplayName = "Lebanon", IsoCode3 = "LBN" },
                new(){ CountryId = -724, DisplayName = "Lesotho", IsoCode3 = "LSO" },
                new(){ CountryId = -725, DisplayName = "Liberia", IsoCode3 = "LBR" },
                new(){ CountryId = -726, DisplayName = "Libya", IsoCode3 = "LBY" },
                new(){ CountryId = -727, DisplayName = "Liechtenstein", IsoCode3 = "LIE" },
                new(){ CountryId = -728, DisplayName = "Lithuania", IsoCode3 = "LTU" },
                new(){ CountryId = -729, DisplayName = "Luxembourg", IsoCode3 = "LUX" },
                new(){ CountryId = -730, DisplayName = "Macao", IsoCode3 = "MAC" },
                new(){ CountryId = -731, DisplayName = "Macedonia (the former Yugoslav Republic of)", IsoCode3 = "MKD" },
                new(){ CountryId = -732, DisplayName = "Madagascar", IsoCode3 = "MDG" },
                new(){ CountryId = -733, DisplayName = "Malawi", IsoCode3 = "MWI" },
                new(){ CountryId = -734, DisplayName = "Malaysia", IsoCode3 = "MYS" },
                new(){ CountryId = -735, DisplayName = "Maldives", IsoCode3 = "MDV" },
                new(){ CountryId = -736, DisplayName = "Mali", IsoCode3 = "MLI" },
                new(){ CountryId = -737, DisplayName = "Malta", IsoCode3 = "MLT" },
                new(){ CountryId = -738, DisplayName = "Marshall Islands (the)", IsoCode3 = "MHL" },
                new(){ CountryId = -739, DisplayName = "Martinique", IsoCode3 = "MTQ" },
                new(){ CountryId = -740, DisplayName = "Mauritania", IsoCode3 = "MRT" },
                new(){ CountryId = -741, DisplayName = "Mauritius", IsoCode3 = "MUS" },
                new(){ CountryId = -742, DisplayName = "Mayotte", IsoCode3 = "MYT" },
                new(){ CountryId = -743, DisplayName = "Mexico", IsoCode3 = "MEX" },
                new(){ CountryId = -744, DisplayName = "Micronesia (Federated States of)", IsoCode3 = "FSM" },
                new(){ CountryId = -745, DisplayName = "Moldova (the Republic of)", IsoCode3 = "MDA" },
                new(){ CountryId = -746, DisplayName = "Monaco", IsoCode3 = "MCO" },
                new(){ CountryId = -747, DisplayName = "Mongolia", IsoCode3 = "MNG" },
                new(){ CountryId = -748, DisplayName = "Montenegro", IsoCode3 = "MNE" },
                new(){ CountryId = -749, DisplayName = "Montserrat", IsoCode3 = "MSR" },
                new(){ CountryId = -750, DisplayName = "Morocco", IsoCode3 = "MAR" },
                new(){ CountryId = -751, DisplayName = "Mozambique", IsoCode3 = "MOZ" },
                new(){ CountryId = -752, DisplayName = "Myanmar", IsoCode3 = "MMR" },
                new(){ CountryId = -753, DisplayName = "Namibia", IsoCode3 = "NAM" },
                new(){ CountryId = -754, DisplayName = "Nauru", IsoCode3 = "NRU" },
                new(){ CountryId = -755, DisplayName = "Nepal", IsoCode3 = "NPL" },
                new(){ CountryId = -756, DisplayName = "Netherlands (the)", IsoCode3 = "NLD" },
                new(){ CountryId = -757, DisplayName = "New Caledonia", IsoCode3 = "NCL" },
                new(){ CountryId = -758, DisplayName = "New Zealand", IsoCode3 = "NZL" },
                new(){ CountryId = -759, DisplayName = "Nicaragua", IsoCode3 = "NIC" },
                new(){ CountryId = -760, DisplayName = "Niger (the)", IsoCode3 = "NER" },
                new(){ CountryId = -761, DisplayName = "Nigeria", IsoCode3 = "NGA" },
                new(){ CountryId = -762, DisplayName = "Niue", IsoCode3 = "NIU" },
                new(){ CountryId = -763, DisplayName = "Norfolk Island", IsoCode3 = "NFK" },
                new(){ CountryId = -764, DisplayName = "Northern Mariana Islands (the)", IsoCode3 = "MNP" },
                new(){ CountryId = -765, DisplayName = "Norway", IsoCode3 = "NOR" },
                new(){ CountryId = -766, DisplayName = "Oman", IsoCode3 = "OMN" },
                new(){ CountryId = -767, DisplayName = "Pakistan", IsoCode3 = "PAK" },
                new(){ CountryId = -768, DisplayName = "Palau", IsoCode3 = "PLW" },
                new(){ CountryId = -769, DisplayName = "Palestine, State of", IsoCode3 = "PSE" },
                new(){ CountryId = -770, DisplayName = "Panama", IsoCode3 = "PAN" },
                new(){ CountryId = -771, DisplayName = "Papua New Guinea", IsoCode3 = "PNG" },
                new(){ CountryId = -772, DisplayName = "Paraguay", IsoCode3 = "PRY" },
                new(){ CountryId = -773, DisplayName = "Peru", IsoCode3 = "PER" },
                new(){ CountryId = -774, DisplayName = "Philippines (the)", IsoCode3 = "PHL" },
                new(){ CountryId = -775, DisplayName = "Pitcairn", IsoCode3 = "PCN" },
                new(){ CountryId = -776, DisplayName = "Poland", IsoCode3 = "POL" },
                new(){ CountryId = -777, DisplayName = "Portugal", IsoCode3 = "PRT" },
                new(){ CountryId = -778, DisplayName = "Puerto Rico", IsoCode3 = "PRI" },
                new(){ CountryId = -779, DisplayName = "Qatar", IsoCode3 = "QAT" },
                new(){ CountryId = -780, DisplayName = "Romania", IsoCode3 = "ROU" },
                new(){ CountryId = -781, DisplayName = "Russian Federation (the)", IsoCode3 = "RUS" },
                new(){ CountryId = -782, DisplayName = "Rwanda", IsoCode3 = "RWA" },
                new(){ CountryId = -783, DisplayName = "Réunion", IsoCode3 = "REU" },
                new(){ CountryId = -784, DisplayName = "Saint Barthélemy", IsoCode3 = "BLM" },
                new(){ CountryId = -785, DisplayName = "Saint Helena, Ascension and Tristan da Cunha", IsoCode3 = "SHN" },
                new(){ CountryId = -786, DisplayName = "Saint Kitts and Nevis", IsoCode3 = "KNA" },
                new(){ CountryId = -787, DisplayName = "Saint Lucia", IsoCode3 = "LCA" },
                new(){ CountryId = -788, DisplayName = "Saint Martin (French part)", IsoCode3 = "MAF" },
                new(){ CountryId = -789, DisplayName = "Saint Pierre and Miquelon", IsoCode3 = "SPM" },
                new(){ CountryId = -790, DisplayName = "Saint Vincent and the Grenadines", IsoCode3 = "VCT" },
                new(){ CountryId = -791, DisplayName = "Samoa", IsoCode3 = "WSM" },
                new(){ CountryId = -792, DisplayName = "San Marino", IsoCode3 = "SMR" },
                new(){ CountryId = -793, DisplayName = "Sao Tome and Principe", IsoCode3 = "STP" },
                new(){ CountryId = -794, DisplayName = "Saudi Arabia", IsoCode3 = "SAU" },
                new(){ CountryId = -795, DisplayName = "Senegal", IsoCode3 = "SEN" },
                new(){ CountryId = -796, DisplayName = "Serbia", IsoCode3 = "SRB" },
                new(){ CountryId = -797, DisplayName = "Seychelles", IsoCode3 = "SYC" },
                new(){ CountryId = -798, DisplayName = "Sierra Leone", IsoCode3 = "SLE" },
                new(){ CountryId = -799, DisplayName = "Singapore", IsoCode3 = "SGP" },
                new(){ CountryId = -800, DisplayName = "Sint Maarten (Dutch part)", IsoCode3 = "SXM" },
                new(){ CountryId = -801, DisplayName = "Slovakia", IsoCode3 = "SVK" },
                new(){ CountryId = -802, DisplayName = "Slovenia", IsoCode3 = "SVN" },
                new(){ CountryId = -803, DisplayName = "Solomon Islands", IsoCode3 = "SLB" },
                new(){ CountryId = -804, DisplayName = "Somalia", IsoCode3 = "SOM" },
                new(){ CountryId = -805, DisplayName = "South Africa", IsoCode3 = "ZAF" },
                new(){ CountryId = -806, DisplayName = "South Georgia and the South Sandwich Islands", IsoCode3 = "SGS" },
                new(){ CountryId = -807, DisplayName = "South Sudan", IsoCode3 = "SSD" },
                new(){ CountryId = -808, DisplayName = "Spain", IsoCode3 = "ESP" },
                new(){ CountryId = -809, DisplayName = "Sri Lanka", IsoCode3 = "LKA" },
                new(){ CountryId = -810, DisplayName = "Sudan (the)", IsoCode3 = "SDN" },
                new(){ CountryId = -811, DisplayName = "Suriname", IsoCode3 = "SUR" },
                new(){ CountryId = -812, DisplayName = "Svalbard and Jan Mayen", IsoCode3 = "SJM" },
                new(){ CountryId = -813, DisplayName = "Sweden", IsoCode3 = "SWE" },
                new(){ CountryId = -814, DisplayName = "Switzerland", IsoCode3 = "CHE" },
                new(){ CountryId = -815, DisplayName = "Syrian Arab Republic", IsoCode3 = "SYR" },
                new(){ CountryId = -816, DisplayName = "Taiwan", IsoCode3 = "TWN" },
                new(){ CountryId = -817, DisplayName = "Tajikistan", IsoCode3 = "TJK" },
                new(){ CountryId = -818, DisplayName = "Tanzania, United Republic of", IsoCode3 = "TZA" },
                new(){ CountryId = -819, DisplayName = "Thailand", IsoCode3 = "THA" },
                new(){ CountryId = -820, DisplayName = "Timor-Leste", IsoCode3 = "TLS" },
                new(){ CountryId = -821, DisplayName = "Togo", IsoCode3 = "TGO" },
                new(){ CountryId = -822, DisplayName = "Tokelau", IsoCode3 = "TKL" },
                new(){ CountryId = -823, DisplayName = "Tonga", IsoCode3 = "TON" },
                new(){ CountryId = -824, DisplayName = "Trinidad and Tobago", IsoCode3 = "TTO" },
                new(){ CountryId = -825, DisplayName = "Tunisia", IsoCode3 = "TUN" },
                new(){ CountryId = -826, DisplayName = "Turkey", IsoCode3 = "TUR" },
                new(){ CountryId = -827, DisplayName = "Turkmenistan", IsoCode3 = "TKM" },
                new(){ CountryId = -828, DisplayName = "Turks and Caicos Islands (the)", IsoCode3 = "TCA" },
                new(){ CountryId = -829, DisplayName = "Tuvalu", IsoCode3 = "TUV" },
                new(){ CountryId = -830, DisplayName = "Uganda", IsoCode3 = "UGA" },
                new(){ CountryId = -831, DisplayName = "Ukraine", IsoCode3 = "UKR" },
                new(){ CountryId = -832, DisplayName = "United Arab Emirates (the)", IsoCode3 = "ARE" },
                new(){ CountryId = -833, DisplayName = "United Kingdom of Great Britain and Northern Ireland (the)", IsoCode3 = "GBR" },
                new(){ CountryId = -834, DisplayName = "United States Minor Outlying Islands (the)", IsoCode3 = "UMI" },
                new(){ CountryId = -835, DisplayName = "United States of America (the)", IsoCode3 = "USA" },
                new(){ CountryId = -836, DisplayName = "Uruguay", IsoCode3 = "URY" },
                new(){ CountryId = -837, DisplayName = "Uzbekistan", IsoCode3 = "UZB" },
                new(){ CountryId = -838, DisplayName = "Vanuatu", IsoCode3 = "VUT" },
                new(){ CountryId = -839, DisplayName = "Venezuela (Bolivarian Republic of)", IsoCode3 = "VEN" },
                new(){ CountryId = -840, DisplayName = "Viet Nam", IsoCode3 = "VNM" },
                new(){ CountryId = -841, DisplayName = "Virgin Islands (British)", IsoCode3 = "VGB" },
                new(){ CountryId = -842, DisplayName = "Virgin Islands (U.S.)", IsoCode3 = "VIR" },
                new(){ CountryId = -843, DisplayName = "Wallis and Futuna", IsoCode3 = "WLF" },
                new(){ CountryId = -844, DisplayName = "Western Sahara", IsoCode3 = "ESH" },
                new(){ CountryId = -845, DisplayName = "Yemen", IsoCode3 = "YEM" },
                new(){ CountryId = -846, DisplayName = "Zambia", IsoCode3 = "ZMB" },
                new(){ CountryId = -847, DisplayName = "Zimbabwe", IsoCode3 = "ZWE" },
                new(){ CountryId = -848, DisplayName = "Åland Islands", IsoCode3 = "ALA" }
            };

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<Country>(
                    sourceGuid: guid,
                    Countries
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<MarketHoliday>(
                    sourceGuid: guid,
                    new MarketHoliday[]
                    {
                        new (){ MarketHolidayId = -10, MarketHolidayName = "Christmas Day" },
                        new (){ MarketHolidayId = -11, MarketHolidayName = "Good Friday" },
                        new() { MarketHolidayId = -12, MarketHolidayName = "Independence Day" },
                        new() { MarketHolidayId = -13, MarketHolidayName = "Labor Day" },
                        new() { MarketHolidayId = -14, MarketHolidayName = "Martin Luther King, Jr. Day" },
                        new() { MarketHolidayId = -15, MarketHolidayName = "Memorial Day" },
                        new() { MarketHolidayId = -16, MarketHolidayName = "New Years Day" },
                        new() { MarketHolidayId = -17, MarketHolidayName = "President's Day" },
                        new() { MarketHolidayId = -18, MarketHolidayName = "Thanksgiving Day" }
                    }
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<MarketHolidayObservance>(
                    sourceGuid: guid,
                    new MarketHolidayObservance[]
                    {
                        new(){ MarketHolidayId = -10, ObservanceDate = new(2022, 12, 16) },
                        new(){ MarketHolidayId = -11, ObservanceDate = new(2022, 4, 15) },
                        new(){ MarketHolidayId = -12, ObservanceDate = new(2022, 7, 4) },
                        new(){ MarketHolidayId = -13, ObservanceDate = new(2022, 9, 5) },
                        new(){ MarketHolidayId = -14, ObservanceDate = new(2022, 1, 17) },
                        new(){ MarketHolidayId = -15, ObservanceDate = new(2022, 5, 30) },
                        new(){ MarketHolidayId = -16, ObservanceDate = new(2022, 1, 1) },
                        new(){ MarketHolidayId = -17, ObservanceDate = new(2022, 2, 21) },
                        new(){ MarketHolidayId = -18, ObservanceDate = new(2022, 11, 24) }
                    }
                ));

            // NOTE: Define ModelAttribute before ModelAttributeScope. ModelAttributeScope has a 
            //       1-or-n:1 relationship with ModelAttribute.
            var ModelAttributes = new ModelAttribute[]
            {
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.AssetClass,
                    DisplayName = Strings.ModelAttribute_AssetClass
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.SecurityTypeGroup,
                    DisplayName = Strings.ModelAttribute_SecurityTypeGroup
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.SecurityType,
                    DisplayName = Strings.ModelAttribute_SecurityType
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BrokerTransactionCategory,
                    DisplayName = Strings.ModelAttribute_BrokerTransactionCategory
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.BrokerTransactionClass,
                    DisplayName = Strings.ModelAttribute_BrokerTransactionClass
                },
                new()
                {
                    AttributeId = (int)ModelAttributeEnum.CountryExposure,
                    DisplayName = Strings.ModelAttribute_CountryExposure
                }
            };

            // NOTE: Define SecurityTypes, SecurityTypeGroups before ModelAttributeMember.
            //       ModelAttributeMember initial records have a 1:0-1 relationship with both 
            //       SecurityType and SecurityTypeGroup.
            var SecurityTypeGroups = new SecurityTypeGroup[]
            {
                new (){ SecurityTypeGroupId = -200, SecurityTypeGroupName = "Individual Stocks" },
                new (){ SecurityTypeGroupId = -201, SecurityTypeGroupName = "Equity Funds & ETFs" },
                new() { SecurityTypeGroupId = -202, SecurityTypeGroupName = "Individual Bonds & CDs" },
                new() { SecurityTypeGroupId = -203, SecurityTypeGroupName = "Fixed Income Funds & ETFs" },
                new() { SecurityTypeGroupId = -204, SecurityTypeGroupName = "Option Contracts" },
                new() { SecurityTypeGroupId = -205, SecurityTypeGroupName = "Digital Assets" },
                new() { SecurityTypeGroupId = -206, SecurityTypeGroupName = "Other Funds & ETPs" },
                new() { SecurityTypeGroupId = -207, SecurityTypeGroupName = "Short-Term Debt" },
                new() { SecurityTypeGroupId = -208, SecurityTypeGroupName = "Long-Term Debt" },
                new() { SecurityTypeGroupId = -209, SecurityTypeGroupName = "Cash Funds & Currency" },
                new() { SecurityTypeGroupId = -210, SecurityTypeGroupName = "Cash Deposit", DepositSource = true },
                new() { SecurityTypeGroupId = -211, SecurityTypeGroupName = "Expense" },
                new() { SecurityTypeGroupId = -212, SecurityTypeGroupName = "None/External", DepositSource = true, Transactable = false }
            };

            var SecurityTypes = new SecurityType[]
            {
                new()
                {
                    SecurityTypeId = -300,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "Common Stock",
                    ValuationFactor = 1M,
                    CanHaveDerivative = true,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -301,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "American Depository Receipt",
                    ValuationFactor = 1M,
                    CanHaveDerivative = true,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -302,
                    SecurityTypeGroupId = -201,
                    SecurityTypeName = "Equity ETF",
                    ValuationFactor = 1M,
                    CanHaveDerivative = true,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -303,
                    SecurityTypeGroupId = -201,
                    SecurityTypeName = "Equity Mutual Fund",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -304,
                    SecurityTypeGroupId = -202,
                    SecurityTypeName = "Corporate Bond",
                    ValuationFactor = 0.01M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -305,
                    SecurityTypeGroupId = -202,
                    SecurityTypeName = "Municipal Bond",
                    ValuationFactor = 0.01M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -306,
                    SecurityTypeGroupId = -202,
                    SecurityTypeName = "U.S. Government Bond/Bill",
                    ValuationFactor = 0.01M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -307,
                    SecurityTypeGroupId = -202,
                    SecurityTypeName = "Certificate of Deposit",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -308,
                    SecurityTypeGroupId = -203,
                    SecurityTypeName = "Bond ETF",
                    ValuationFactor = 1M,
                    CanHaveDerivative = true,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -309,
                    SecurityTypeGroupId = -203,
                    SecurityTypeName = "Bond Mutual Fund",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -310,
                    SecurityTypeGroupId = -204,
                    SecurityTypeName = "Call Option",
                    ValuationFactor = 100M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -311,
                    SecurityTypeGroupId = -204,
                    SecurityTypeName = "Put Option",
                    ValuationFactor = 100M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -312,
                    SecurityTypeGroupId = -205,
                    SecurityTypeName = "Cryptocurrency",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true,
                    HeldInWallet = true
                },
                new()
                {
                    SecurityTypeId = -313,
                    SecurityTypeGroupId = -206,
                    SecurityTypeName = "Exchange-Traded Note",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -314,
                    SecurityTypeGroupId = -206,
                    SecurityTypeName = "Retirement Plan",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -315,
                    SecurityTypeGroupId = -207,
                    SecurityTypeName = "Revolving Debt",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -316,
                    SecurityTypeGroupId = -208,
                    SecurityTypeName = "Student Debt",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -317,
                    SecurityTypeGroupId = -209,
                    SecurityTypeName = "Money-Market Fund",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -318,
                    SecurityTypeGroupId = -209,
                    SecurityTypeName = "Fiat Currency",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -319,
                    SecurityTypeGroupId = -210,
                    SecurityTypeName = "Cash",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = true
                },
                new()
                {
                    SecurityTypeId = -320,
                    SecurityTypeGroupId = -211,
                    SecurityTypeName = "Expense",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition = false
                },
                new()
                {
                    SecurityTypeId = -321,
                    SecurityTypeGroupId = -212,
                    SecurityTypeName = "None/External",
                    ValuationFactor = 1M,
                    CanHaveDerivative = false,
                    CanHavePosition  = false
                }
            };

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<SecurityTypeGroup>(
                    sourceGuid: guid,
                    SecurityTypeGroups
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<SecurityType>(
                    sourceGuid: guid,
                    SecurityTypes
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<SecuritySymbolType>(
                    sourceGuid: guid,
                    new SecuritySymbolType[]
                    {
                        new () { SymbolTypeId = -10, SymbolTypeName = "CUSIP" },
                        new () { SymbolTypeId = -20, SymbolTypeName = "Custom Identifier" },
                        new() { SymbolTypeId = -30, SymbolTypeName = "Option Ticker" },
                        new() { SymbolTypeId = -40, SymbolTypeName = "Ticker" }
                    }
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<Security>(
                    sourceGuid: guid,
                    new Security[]
                    {
                        new()
                        {
                            SecurityId = -100,
                            SecurityTypeId = -321,
                            SecurityDescription = "None",
                            HasPerpetualMarket = false,
                            HasPerpetualPrice = false,
                        },
                        new()
                        {
                            SecurityId = -101,
                            SecurityDescription = "Broker cash",
                            HasPerpetualMarket = false,
                            HasPerpetualPrice = true,
                            SecurityTypeId = -319
                        },
                        new()
                        {
                            SecurityId = -102,
                            SecurityDescription = "Foreign tax withholding",
                            HasPerpetualMarket = false,
                            HasPerpetualPrice = false,
                            SecurityTypeId = -320
                        }
                    }
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<ModelAttribute>(
                    sourceGuid: guid,
                    ModelAttributes
                ));

            var countryAttributeId = (int)ModelAttributeEnum.CountryExposure;
            var countryExposuresScopes = new ModelAttributeScope[]
            {
                new ModelAttributeScope()
                    {
                        AttributeId = countryAttributeId,
                        ScopeCode = ModelAttributeScopeCode.Custodian.ConvertToStringCode()
                    },
                new ModelAttributeScope()
                    {
                        AttributeId = countryAttributeId,
                        ScopeCode = ModelAttributeScopeCode.Exchange.ConvertToStringCode()
                    },
                new ModelAttributeScope()
                    {
                        AttributeId = countryAttributeId,
                        ScopeCode = ModelAttributeScopeCode.Security.ConvertToStringCode()
                    }
            };

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<ModelAttributeScope>(
                    sourceGuid: guid,
                    ModelAttributes
                        .Where(a =>
                            a.AttributeId is <= (int)ModelAttributeEnum.AssetClass and
                            >= (int)ModelAttributeEnum.SecurityType)
                        .Select(a => new ModelAttributeScope()
                        {
                            AttributeId = a.AttributeId,
                            ScopeCode = ModelAttributeScopeCode.Security.ConvertToStringCode()
                        })
                        .Concat(ModelAttributes
                            .Where(a =>
                                a.AttributeId is <= (int)ModelAttributeEnum.BrokerTransactionCategory and
                                >= (int)ModelAttributeEnum.BrokerTransactionClass)
                            .Select(a => new ModelAttributeScope()
                            {
                                AttributeId = a.AttributeId,
                                ScopeCode = ModelAttributeScopeCode.BrokerTransactionCode.ConvertToStringCode()
                            }))
                        .Concat(countryExposuresScopes)
                        .ToArray()
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<ModelAttributeMember>(
                    sourceGuid: guid,
                    new ModelAttributeMember[]
                    {
                        // ASSET CLASS
                        new() { AttributeMemberId = -100, AttributeId = -10, DisplayName = "Equities", DisplayOrder = 0 },
                        new() { AttributeMemberId = -101, AttributeId = -10, DisplayName = "Fixed Income", DisplayOrder = 1 },
                        new() { AttributeMemberId = -102, AttributeId = -10, DisplayName = "Derivatives", DisplayOrder = 2 },
                        new() { AttributeMemberId = -103, AttributeId = -10, DisplayName = "Other", DisplayOrder = 3 },
                        new() { AttributeMemberId = -104, AttributeId = -10, DisplayName = "Cash & Equivalents", DisplayOrder = 4 },
                        new() { AttributeMemberId = -105, AttributeId = -10, DisplayName = "Blended Funds & Products", DisplayOrder = 5 },
                        new() { AttributeMemberId = -106, AttributeId = -10, DisplayName = "Debt & Liability", DisplayOrder = 6 },
                        new() { AttributeMemberId = -107, AttributeId = -10, DisplayName = "Not Classified", DisplayOrder = 7 },

                        // BROKER TRANSACTION - CATEGORY
                        new() { AttributeMemberId = -401, AttributeId = -40, DisplayName = "Interest Charge", DisplayOrder = 0 },
                        new() { AttributeMemberId = -402, AttributeId = -40, DisplayName = "Purchases", DisplayOrder = 0 },
                        new() { AttributeMemberId = -403, AttributeId = -40, DisplayName = "Margin Purchases", DisplayOrder = 1 },
                        new() { AttributeMemberId = -404, AttributeId = -40, DisplayName = "Gain/Loss", DisplayOrder = 2 },
                        new() { AttributeMemberId = -405, AttributeId = -40, DisplayName = "Starting Balance", DisplayOrder = 0 },
                        new() { AttributeMemberId = -406, AttributeId = -40, DisplayName = "Contributions", DisplayOrder = 0 },
                        new() { AttributeMemberId = -407, AttributeId = -40, DisplayName = "Withdrawals", DisplayOrder = 1 },
                        new() { AttributeMemberId = -408, AttributeId = -40, DisplayName = "Dividends", DisplayOrder = 0 },
                        new() { AttributeMemberId = -409, AttributeId = -40, DisplayName = "Expenses", DisplayOrder = 2 },
                        new() { AttributeMemberId = -410, AttributeId = -40, DisplayName = "Writeoffs", DisplayOrder = 0 },
                        new() { AttributeMemberId = -411, AttributeId = -40, DisplayName = "Interest", DisplayOrder = 1 },
                        new() { AttributeMemberId = -412, AttributeId = -40, DisplayName = "Principal Pay-Down", DisplayOrder = 1 },
                        new() { AttributeMemberId = -413, AttributeId = -40, DisplayName = "Sales", DisplayOrder = 3 },
                        new() { AttributeMemberId = -414, AttributeId = -40, DisplayName = "Margin Sales", DisplayOrder = 2 },

                        // BROKER TRANSACTION - CLASS
                        new() { AttributeMemberId = -501, AttributeId = -50, DisplayName = "Expense", DisplayOrder = 4 },
                        new() { AttributeMemberId = -502, AttributeId = -50, DisplayName = "Trade", DisplayOrder = 1 },
                        new() { AttributeMemberId = -503, AttributeId = -50, DisplayName = "Income", DisplayOrder = 2 },
                        new() { AttributeMemberId = -504, AttributeId = -50, DisplayName = "Balance", DisplayOrder = 0 },
                        new() { AttributeMemberId = -505, AttributeId = -50, DisplayName = "Transfer", DisplayOrder = 3 },
                        new() { AttributeMemberId = -506, AttributeId = -50, DisplayName = "Writeoff", DisplayOrder = 5 },
                    }
                    // COUNTRIES
                    .Concat(Countries.Select(c => new ModelAttributeMember()
                    {
                        AttributeId = -60,
                        AttributeMemberId = c.CountryId,
                        DisplayName = c.IsoCode3,
                        DisplayOrder = (short)Array.IndexOf(Countries, c)
                    }))

                    // SECURITY TYPE GROUPS
                    .Concat(SecurityTypeGroups.Select(x => new ModelAttributeMember()
                    {
                        AttributeId = -20,
                        AttributeMemberId = x.SecurityTypeGroupId,
                        DisplayName = x.SecurityTypeGroupName,
                        DisplayOrder = (short)Array.IndexOf(SecurityTypeGroups, x)
                    }))

                    // SECURITY TYPES
                    .Concat(SecurityTypes.Select(s => new ModelAttributeMember()
                    {
                        AttributeId = -30,
                        AttributeMemberId = s.SecurityTypeId,
                        DisplayName = s.SecurityTypeName,
                        DisplayOrder = (short)Array.IndexOf(SecurityTypes, s)
                    }))
                    .ToArray()
                ));

            _configurationCollection.AddConfiguration(
                new EntityConfiguration<SecurityExchange>(
                    sourceGuid: guid,
                    new SecurityExchange[]
                    {
                        new () { ExchangeId = -1, ExchangeCode = "TSX", ExchangeDescription = "TSX" },
                        new () { ExchangeId = -2, ExchangeCode = "NYSE", ExchangeDescription = "NYSE" },
                        new () { ExchangeId = -3, ExchangeCode = "OTCQX", ExchangeDescription = "OTCQX" },
                        new () { ExchangeId = -4, ExchangeCode = "NYSE American", ExchangeDescription = "NYSE American" },
                        new () { ExchangeId = -5, ExchangeCode = "NASDAQ", ExchangeDescription = "NASDAQ" },
                        new () { ExchangeId = -6, ExchangeCode = "OTCQB", ExchangeDescription = "OTCQB" },
                        new () { ExchangeId = -7, ExchangeCode = "OTC Pink", ExchangeDescription = "OTC Pink" },
                        new () { ExchangeId = -8, ExchangeCode = "NYSE Arca", ExchangeDescription = "NYSE Arca" },
                        new () { ExchangeId = -9, ExchangeCode = "CBOE", ExchangeDescription = "CBOE Consolidated Listings" }
                    }
                ));

            return _configurationCollection;
        }
    }

    /// <summary>
    ///  Extension method container for the <see cref="IConfigurationCollection"/> interface.
    /// </summary>
    public static class IConfigurationCollectionFluentExtension
    {
        /// <summary>
        /// Adds a new <see cref="Action"/> accepting <see cref="ModelBuilder"/> input that applies 
        /// the given <see cref="IEntityConfiguration{TEntity}"/>. The action is invoked by the caller, 
        /// typically be iterating over the <see cref="IConfigurationCollection"/> instance.
        /// </summary>
        /// <<returns>The <see cref="IConfigurationCollection"/> instance for chaining method calls.</returns>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"><paramref name="configuration"/> was null.</exception>
        public static IConfigurationCollection WithConfiguration<T>(
            this IConfigurationCollection collection,
            IEntityConfiguration<T> configuration)
            where T : class
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            collection.AddConfiguration(configuration);

            return collection;
        }
    }
}