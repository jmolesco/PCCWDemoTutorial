﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BaseEntity
    {
        public bool status { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
