namespace WorkloadsDb.Model
{
    using System;

    public class Workload
    {
        public int WorkloadId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset? Stop { get; set; }
        public string Comment { get; set; }
        public int PersonId { get; set; } //Not needed
        public int AssignmentId { get; set; } //Not needed

        //Browsing properties:
        public Person Person { get; set; }
        public Assignment Assignment { get; set; }
    }
}
