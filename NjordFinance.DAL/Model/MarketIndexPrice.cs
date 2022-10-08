﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model.Metadata;

namespace NjordFinance.Model
{
    [Table("MarketIndexPrice", Schema = "FinanceApp")]
    [Index(nameof(MarketIndexId), Name = "IX_MarketIndexPrice_MarketIndexID")]
    public partial class MarketIndexPrice
    {
        [Key]
        [Column("IndexPriceID")]
        public int IndexPriceId { get; set; }
        [Column("MarketIndexID")]
        public int MarketIndexId { get; set; }
        [Column(TypeName = "date")]
        public DateTime PriceDate { get; set; }
        [StringLength(1,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string PriceCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(MarketIndexId))]
        [InverseProperty("MarketIndexPrices")]
        public virtual MarketIndex MarketIndex { get; set; }
    }
}
