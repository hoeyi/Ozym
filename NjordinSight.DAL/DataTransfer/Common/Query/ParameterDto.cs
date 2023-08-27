using Ichosys.DataModel.Expressions;
using System;
using System.Text.Json.Serialization;

namespace NjordinSight.DataTransfer.Common.Query
{
    public record ParameterDto<T> : IQueryParameter<T>
    {
        /// <inheritdoc/>
        public string MemberName { get; set; }

        /// <inheritdoc/>
        public ComparisonOperator Operator { get; set; }

        /// <inheritdoc/>
        public string Value { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public Type SearchObjectType { get; } = typeof(T);

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(MemberName);
    }
}
