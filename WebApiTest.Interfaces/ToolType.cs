using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApiTest.Interfaces
{
    [Table("ToolType")]
    public class ToolType: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string DescrAppl { get; set; }
    }
}
