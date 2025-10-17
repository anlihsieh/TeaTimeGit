using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Models
{
    public class CustomTemplateGroup 
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomTemplateId")]
        [ValidateNever]
        public int CustomTemplateId { get; set; } //客製化範本Id
        [ValidateNever]
        public CustomTemplate CustomTemplate { get; set; }

        [ForeignKey("CustomGroupId")]
        [ValidateNever]
        public int CustomGroupId { get; set; } //客製化類別Id
        [ValidateNever]
        public CustomGroup CustomGroup { get; set; }

        public int DisplayOrder { get; set; }
    }

}
