using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApiTest.Interfaces
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual System.Guid ID { get; set; }

        public virtual string Descr { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}
