using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Students : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int StudentId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
    }
}
