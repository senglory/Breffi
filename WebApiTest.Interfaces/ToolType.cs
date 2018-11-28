using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApiTest.Interfaces
{
    public class ToolType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual System.Guid ID { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string DescrAppl { get; set; }
    }
}
