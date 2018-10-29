using System.Collections.Generic;
using System.Linq;
using DemoWebDotNet.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWebDotNet.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class ApiStudentController : Controller
    {
        private readonly ContextDatabase _context;

        public ApiStudentController(ContextDatabase context)
        {
            _context = context;

            if (_context != null && !_context.Students.Any())
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Students.Add(new StudentViewModel() { Name = "Student 1", Address = "Address 1", Email = "Email 1"});
                _context.SaveChanges();
            }
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAll()
        {
            return _context.Students.ToList();
        }


        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<StudentViewModel> GetById(long id)
        {
            var item = _context.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = student.Id }, student);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, StudentViewModel item)
        {
            var todo = _context.Students.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Name = item.Name;
            todo.Address = item.Address;
            todo.Email = item.Email;

            _context.Students.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Students.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Students.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
