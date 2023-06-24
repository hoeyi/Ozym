using Ichosys.DataModel.Expressions;
using System;
using System.Text.Json.Serialization;

namespace NjordinSight.DataTransfer.Common.Query
{
    public record ParameterDto<T> : IQueryParameter<T>
    {
        /// <inheritdoc/>
        public string MemberName { get; init; }

        /// <inheritdoc/>
        public ComparisonOperator Operator { get; init; }

        /// <inheritdoc/>
        public string Value { get; init; }

        /// <inheritdoc/>
        [JsonIgnore]
        public Type SearchObjectType { get; } = typeof(T);

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(MemberName);
    }
}
