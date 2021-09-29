// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkloadsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IWorkloadsService service;

        public AssignmentsController(IWorkloadsService service)
        {
            this.service = service;
        }

        // GET: api/<AssignmentsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAllAssignments());
        }

        // GET api/<AssignmentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Assignment result = service.GetAssignment(id).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<AssignmentsController>
        //[HttpPost]
        //public IActionResult Post([FromBody] Assignment value)
        //{
        //    if (context.Assignments.Contains(value))
        //    {
        //        return BadRequest();
        //    }

        //    context.Assignments.Add(value);
        //    context.SaveChanges();

        //    return Ok(value);
        //}

        // PUT api/<AssignmentsController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Assignment value)
        //{
        //    Assignment result = context.Assignments.Find(id);
        //    if (result != null)
        //    {
        //        context.Entry(result).State = EntityState.Detached;
        //        context.Assignments.Attach(value);
        //        context.Entry(value).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return Ok(value);
        //    }
        //    //If upsert:
        //    context.Assignments.Add(value);
        //    context.SaveChanges();
        //    return Accepted(value);
        //    //If fail:
        //    //return BadRequest();
        //}

        // DELETE api/<AssignmentsController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    Assignment result = context.Assignments.Find(id);
        //    if (result != null)
        //    {
        //        context.Assignments.Remove(result);
        //        context.SaveChanges();
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
    }
}
