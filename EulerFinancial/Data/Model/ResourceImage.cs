using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ResourceImage
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageBinary { get; set; }
        public string FileExtension { get; set; }
    }
}
