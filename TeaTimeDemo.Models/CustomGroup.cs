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
    public class CustomGroup
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入客製化類別名稱")]
        [MaxLength(30)]
        [DisplayName("類別名稱")]
        public string Name { get; set; } //名稱

        [Required(ErrorMessage = "請選擇客製化模式")]
        [Range(1, 2, ErrorMessage = "選擇模式必須是 1: 單選 或 2: 多選")]
        [DisplayName("選擇模式")]
        public int SelectionMode { get; set; } //選擇模式 1: Single, 2: Multiple

        [Required(ErrorMessage = "請選擇是否為必選")]
        [DisplayName("必選")]
        public bool IsRequired { get; set; } //必選
        
        [Range(0, 100, ErrorMessage = "請輸入0-100的數字")]
        [DisplayName("最小選擇數量")]
        public int MinSelection { get; set; } //最小選擇數量

        [Range(0, 100, ErrorMessage = "請輸入0-100的數字")]
        [DisplayName("最大選擇數量")]
        public int MaxSelection { get; set; } //最大選擇數量
     
    }
}
