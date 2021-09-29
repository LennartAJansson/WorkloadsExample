namespace WorkloadsDb.Abstract
{
    using System.Collections.Generic;

    using WorkloadsDb.Model;

    public interface IWorkloadsService
    {
        IEnumerable<Assignment> GetAllAssignments();
        IEnumerable<Assignment> GetAssignment(int id);
    }

}
