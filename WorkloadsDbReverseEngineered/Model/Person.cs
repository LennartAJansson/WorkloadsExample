﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace WorkloadsDb.Model
{
    public partial class Person
    {
        public Person()
        {
            Workloads = new HashSet<Workload>();
        }

        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Workload> Workloads { get; set; }
    }
}