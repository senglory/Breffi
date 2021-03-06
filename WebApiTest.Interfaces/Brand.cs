﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApiTest.Interfaces
{
    [Table("Brand")]
    public class Brand : BaseEntity
    {
        public string Descr { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
