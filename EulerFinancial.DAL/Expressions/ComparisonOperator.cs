using System.Runtime.Serialization;

namespace EulerFinancial.Expressions
{
    public enum ComparisonOperator
    {
        [EnumMember(Value = "=")]
        EqualTo,

        [EnumMember(Value = "<>")]
        NotEqualTo,

        [EnumMember(Value = ">")]
        GreaterThan,

        [EnumMember(Value = ">=")]
        GreaterThanOrEqualTo,

        [EnumMember(Value = "<")]
        LessThan,

        [EnumMember(Value = "<=")]
        LessThanOrEqualTo,

        [EnumMember(Value = "LIKE %{0}%")]
        Contains
    }
}
