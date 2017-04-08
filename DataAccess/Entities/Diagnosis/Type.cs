﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Diagnosis
{
    [Table("Type", Schema = "Diagnosis")]
    public class DiagnosisType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
