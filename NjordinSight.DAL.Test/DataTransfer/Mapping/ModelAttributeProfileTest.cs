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
    public class ModelAttributeProfileTest : ProfileBaseTest
    {
        public ModelAttributeProfileTest()
            : base(configuration:
                new(x =>
                {
                    x.AddProfile<ModelAttributeProfile>();
                }))
        {
        }

        [TestMethod]
        public void Configuration_WithProfile_IsValid()
        {
            // Fact: Configuration is valid.
            Configuration.AssertConfigurationIsValid();
        }
    }
}
