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
    public class CustomOption 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入選項名稱")]
        [MaxLength(30)]
        [DisplayName("選項名稱")]
        public string Name { get; set; } //選項名稱

        [DisplayName("加購價格")]
        public decimal Price { get; set; } //加購價格

        [Range(0, 100, ErrorMessage = "請輸入0-100的數字")]
        [DisplayName("最小加購數量")]
        public int MinQty { get; set; } //最小加購數量

        [Range(0, 100, ErrorMessage = "請輸入0-100的數字")]
        [DisplayName("最大加購數量")]
        public int MaxQty { get; set; } //最大加購數量

        [ForeignKey("CustomGroupId")]
        [ValidateNever] 
        public int CustomGroupId { get; set; } //客製化類別Id

        [ValidateNever] 
        public CustomGroup CustomGroup { get; set; }
    }
}
