// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace WorkloadsDb.Model
{
    public partial class Workload
    {
        public int WorkloadId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset? Stop { get; set; }
        public string Comment { get; set; }
        public int PersonId { get; set; }
        public int AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Person Person { get; set; }
    }
}