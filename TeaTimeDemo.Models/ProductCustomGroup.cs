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
    public class ProductCustomGroup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomGroupId")]
        [ValidateNever]
        public int CustomGroupId { get; set; } //客製化類別Id

        [ValidateNever]
        public CustomGroup CustomGroup { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public int ProductId { get; set; } //商品Id

        [ValidateNever]
        public Product Product { get; set; }

        public int DisplayOrder { get; set; }
    }
}
