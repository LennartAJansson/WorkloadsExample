namespace WorkloadsDb.Model
{
    using System.Collections.Generic;

    public class Person
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
    }
}
