using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;



namespace WebApiTest.Interfaces
{
    [Table("Tool")]
    public class Tool : BaseEntity
    {
        [Required]
        public string Descr { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public Guid BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        [ForeignKey("ToolType")]
        public Guid ToolTypeID { get; set; }
        public virtual ToolType ToolType { get; set; }

        public static Tool FromCSV(string s)
        {
            var arrs = s.Split(new char[] { ',' }, StringSplitOptions.None);
            var res = new Tool
            {
                ID = Guid.Parse(arrs[0]),
                BrandID = Guid.Parse(arrs[1]),
                ToolTypeID = Guid.Parse(arrs[2]),
                Descr = arrs[3],
                Price = double.Parse(arrs[4])
            };

            return res;
        }
    }
}
