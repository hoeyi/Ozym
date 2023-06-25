using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvestmentModelProfileTest : ProfileBaseTest
    {
        public InvestmentModelProfileTest() 
            : base(configuration: new(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<InvestmentModelProfile>();
            }))
        {
        }

        [TestMethod]
        public void Configuration_WithProfile_IsValid()
        {
            // Assert
            Configuration.AssertConfigurationIsValid();
        }
    }
}
