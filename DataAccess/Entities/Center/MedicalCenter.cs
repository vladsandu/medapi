﻿using DataAccess.Entities.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Center
{
    [Table("MedicalCenter", Schema = "Center")]
    public class MedicalCenter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual CenterType CenterType { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
    }
}
