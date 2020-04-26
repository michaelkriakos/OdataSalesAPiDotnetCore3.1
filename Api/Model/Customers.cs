﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Sales = new HashSet<Sales>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
