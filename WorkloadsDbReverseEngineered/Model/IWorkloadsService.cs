namespace WorkloadsDb.Model
{

    using System.Collections.Generic;

    public interface IWorkloadsService
    {
        IEnumerable<Assignment> GetAllAssignments();
        IEnumerable<Assignment> GetAssignment(int id);
    }
}
