using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class School : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int SchoolId { get; set; }
        public String SchoolName { get; set; }
        public String Address { get; set; }
    }
}
