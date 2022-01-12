using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerFinancial.Model;

namespace EulerFinancial.ModelMetadata
{
    // Add class as an exmaple of using metadata class to add 
    // custom attributes to EF-generated classes.
    public class AccountMetadata
    {
        public string AccountNumber { get; set; }
    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
