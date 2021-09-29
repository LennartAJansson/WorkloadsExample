namespace WorkloadsDb.Model
{
    using System.Collections.Generic;

    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Customername { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
    }
}
