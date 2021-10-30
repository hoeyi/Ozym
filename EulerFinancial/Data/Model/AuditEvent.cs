using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AuditEvent
    {
        public int EventId { get; set; }
        public DateTime EventTimeUtc { get; set; }
        public int AuditUserId { get; set; }
    }
}
