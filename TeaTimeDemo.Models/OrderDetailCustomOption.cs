using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Models
{
    public class OrderDetailCustomOption
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderDetailId")]
        [ValidateNever]
        public int OrderDetailId { get; set; } //訂單明細Id

        [ValidateNever]
        public OrderDetail OrderDetail { get; set; }

        [ForeignKey("CustomOptionId")]
        [ValidateNever]
        public int CustomOptionId { get; set; } //客製化選項Id

        [ValidateNever]
        public CustomOption CustomOption { get; set; }

        public int Qty { get; set; } //數量

        public decimal Price { get; set; } //加購價格

    }
}
