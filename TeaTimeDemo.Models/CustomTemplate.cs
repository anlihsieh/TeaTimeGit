using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Models
{
    public class CustomTemplate
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入範本名稱")]
        [MaxLength(30)]
        [DisplayName("範本名稱")]
        public string Name { get; set; } //範本名稱

        public string? Description { get; set; } //備註
    }
}
