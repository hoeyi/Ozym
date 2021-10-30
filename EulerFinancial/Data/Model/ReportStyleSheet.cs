using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ReportStyleSheet
    {
        public int StyleSheetId { get; set; }
        public string StyleSheetCode { get; set; }
        public string StyleSheetDescription { get; set; }
        public string XmlDefinition { get; set; }
    }
}
