using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Models
{
    public class ShoppingCartCustomOption
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ShoppingCartId")]
        [ValidateNever]
        public int ShoppingCartId { get; set; } //購物車Id

        [ValidateNever]
        public ShoppingCart ShoppingCart { get; set; }

        [ForeignKey("CustomOptionId")]
        [ValidateNever]
        public int CustomOptionId { get; set; } //客製化選項Id

        [ValidateNever]
        public CustomOption CustomOption { get; set; }

        public int Qty { get; set; } //數量

        public decimal Price { get; set; } //加購價格
    }
}
