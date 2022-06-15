using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var todos = await context
                .Todos
                .AsNoTracking()
                .ToListAsync(); 
            return Ok(todos);
        }
        
        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, int id)
        {
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == id);
              
            return todo == null ? NotFound() : Ok(todo);
        }
    }
}