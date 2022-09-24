using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NjordFinance.Test.ViewModel
{
    [TestClass]
    public class InvestmentModelViewModelTest
    {
        [TestMethod]
        public void ViewModel_WithRelatedData_ReturnsGroupsForEachAttribute()
        {
            // Arrange
            var effDate1 = DateTime.Now.AddDays(-5).Date;
            var effDate2 = DateTime.Now.AddDays(-15).Date;

            var attribute1 = new ModelAttribute()
            {
                AttributeId = 1,
                DisplayName = "Attr 1"
            };

            var attribute2 = new ModelAttribute()
            {
                AttributeId = 2,
                DisplayName = "Attr 2"
            };


            InvestmentStrategy model = new()
            {
                InvestmentStrategyId = 1,
                DisplayName = "Test strategy",
                InvestmentStrategyTargets = new List<InvestmentStrategyTarget>
                {
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate1,
                        Weight = 0.75M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = attribute1.AttributeId,
                            Attribute = attribute1,
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 2,
                        EffectiveDate = effDate1,
                        Weight = 0.25M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = attribute1.AttributeId,
                            Attribute = attribute1,
                            DisplayName = $"Entry 1-2"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate2,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = attribute1.AttributeId,
                            Attribute = attribute1,
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 3,
                        EffectiveDate = effDate1,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 3,
                            AttributeId = attribute2.AttributeId,
                            Attribute = attribute2,
                            DisplayName = $"Entry 2-3"
                        },
                    }
                }
            };

            // Act
            InvestmentModel viewModel = new(model);

            // Assert
            var obsGroupCount = viewModel.EntryCollectionGroups.Count();
            Assert.AreEqual(2, obsGroupCount);

            var firstGroup = viewModel.EntryCollectionGroups.First();
            var secondGroup = viewModel.EntryCollectionGroups.Skip(1).First();

            Assert.AreEqual(2, firstGroup.Count());
            Assert.AreEqual(1, secondGroup.Count());
        }

        [TestMethod]
        public void ViewModel_WithRelatedData_ToEntity_YieldsValidEntity()
        {
            // Arrange
            var effDate1 = DateTime.Now.AddDays(-5).Date;
            var effDate2 = DateTime.Now.AddDays(-15).Date;

            InvestmentStrategy model = new()
            {
                InvestmentStrategyId = 1,
                DisplayName = "Test strategy",
                InvestmentStrategyTargets = new List<InvestmentStrategyTarget>
                {
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate1,
                        Weight = 0.75M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 2,
                        EffectiveDate = effDate1,
                        Weight = 0.25M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-2"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate2,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 3,
                        EffectiveDate = effDate1,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 3,
                            AttributeId = 2,
                            Attribute = new(){ AttributeId = 2, DisplayName = "Group 2" },
                            DisplayName = $"Entry 2-3"
                        },
                    }
                }
            };

            InvestmentModel viewModel = new(model);

            // Act
            InvestmentStrategy convertedEntity = viewModel.ToEntity();

            // Assert
            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(model, convertedEntity));

            var targetComparisons = model.InvestmentStrategyTargets.Select(entry =>
            {
                var comparedEntry = convertedEntity.InvestmentStrategyTargets
                    .First(e =>
                        e.InvestmentStrategyId == entry.InvestmentStrategyId &&
                        e.AttributeMemberId == entry.AttributeMemberId &&
                        e.EffectiveDate == entry.EffectiveDate);

                return TestUtility.SimplePropertiesAreEqual(entry, comparedEntry);
            });

            Assert.IsTrue(model.InvestmentStrategyTargets
                .All(entry =>
                    {
                        var comparedEntry = convertedEntity.InvestmentStrategyTargets
                            .First(e =>
                                e.InvestmentStrategyId == entry.InvestmentStrategyId &&
                                e.AttributeMemberId == entry.AttributeMemberId &&
                                e.EffectiveDate == entry.EffectiveDate);

                        return TestUtility.SimplePropertiesAreEqual(entry, comparedEntry);
                    }));
        }

        [TestMethod]
        public void ViewModel_ValidDefinition_YieldsValidState()
        {
            // Arrange
            var effDate1 = DateTime.Now.AddDays(-5).Date;
            var effDate2 = DateTime.Now.AddDays(-15).Date;

            InvestmentStrategy model = new()
            {
                InvestmentStrategyId = 1,
                DisplayName = "Test strategy",
                InvestmentStrategyTargets = new List<InvestmentStrategyTarget>
                {
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate1,
                        Weight = 0.75M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 2,
                        EffectiveDate = effDate1,
                        Weight = 0.25M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-2"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate2,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 3,
                        EffectiveDate = effDate1,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 3,
                            AttributeId = 2,
                            Attribute = new(){ AttributeId = 2, DisplayName = "Group 2" },
                            DisplayName = $"Entry 2-3"
                        },
                    }
                }
            };

            InvestmentModel viewModel = new(model);

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }

        [TestMethod]
        public void ViewModel_InvalidDefinition_YieldsInvalidState()
        {
            // Arrange
            var effDate1 = DateTime.Now.AddDays(-5).Date;
            var effDate2 = DateTime.Now.AddDays(-15).Date;

            InvestmentStrategy model = new()
            {
                InvestmentStrategyId = 1,
                InvestmentStrategyTargets = new List<InvestmentStrategyTarget>
                {
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate1,
                        Weight = 0.75M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 2,
                        EffectiveDate = effDate1,
                        Weight = 0.25M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-2"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 1,
                        EffectiveDate = effDate2,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 1,
                            AttributeId = 1,
                            Attribute = new(){ AttributeId = 1, DisplayName = "Group 1" },
                            DisplayName = $"Entry 1-1"
                        },
                    },
                    new()
                    {
                        InvestmentStrategyId = 1,
                        AttributeMemberId = 3,
                        EffectiveDate = effDate1,
                        Weight = 1M,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 3,
                            AttributeId = 2,
                            Attribute = new(){ AttributeId = 2, DisplayName = "Group 2" },
                            DisplayName = $"Entry 2-3"
                        },
                    }
                }
            };

            InvestmentModel viewModel = new(model);

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }
    }
}
