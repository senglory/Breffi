using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;



namespace WebApiTest.Interfaces
{
    public class Tool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual System.Guid ID { get; set; }

        [Required]
        public virtual string Descr { get; set; }

        [Required]
        public virtual double Price { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public Guid BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        [ForeignKey("ToolType")]
        public virtual Guid ToolTypeID { get; set; }
        public virtual ToolType ToolType { get; set; }
    }
}
