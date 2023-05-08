using System;

namespace NjordinSight.Messaging
{
    /// <summary>
    /// Represents a text message that has a header and body content.
    /// </summary>
    public record Message
    {
        /// <summary>
        /// Gets the unique identifier for this record.
        /// </summary>
        public Guid MessageGuid { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets the UTC date/time the message was created.
        /// </summary>
        public DateTime CreatedUtcTime { get; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the local date/time the message was created.
        /// </summary>
        public DateTime CreatedLocalTime => CreatedUtcTime.ToLocalTime();

        /// <summary>
        /// Gets the header of the message.
        /// </summary>
        public string Header { get; init; }

        /// <summary>
        /// Gets the body content of the message.
        /// </summary>
        public string Body { get; init; }
    }
}
