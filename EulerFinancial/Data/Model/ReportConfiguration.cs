using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ReportConfiguration
    {
        public int ConfigurationId { get; set; }
        public string ConfigurationCode { get; set; }
        public string ConfigurationDescription { get; set; }
        public string XmlDefinition { get; set; }
    }
}
