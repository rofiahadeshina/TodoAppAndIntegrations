using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinlistApiWrapper.data;
using BinlistApiWrapper.data.entities;
using BinlistApiWrapper.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BinlistApiWrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private AppDbContext _context {get;}
        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("createTask")]
        public IActionResult CreateTask(CreateTaskDTO createTaskDTO)
        {
            try
            {
                var userTask = new UserTask {
                    Description = createTaskDTO.Description,
                    CreatedAt = DateTime.UtcNow
                };
                _context.UserTasks.Add(userTask);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok();
        }

        [HttpGet("getTasks")]
        public IActionResult GetTasks()
        {
                var userTasks = _context.UserTasks.ToList();
                return Ok(userTasks);
            // UserTask userTasks = new List<UserTask>();
            // try
            // {
            // }
            // catch (System.Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
        }

        [HttpGet("getTask/{id}")]
        public IActionResult GetTask(int id)
        {
            var userTask = _context.UserTasks.First(u => u.Id == id);
            return Ok(userTask);
        }

        [HttpPatch("updateTask")]
        public IActionResult UpdateTask(UpdateTaskDTO updateTaskDTO)
        {
            var userTask = _context.UserTasks.First(u => u.Id == updateTaskDTO.Id);

            // Update properties
            userTask.Description = updateTaskDTO.Description;

            _context.UserTasks.Update(userTask);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            var userTask = _context.UserTasks.First(u => u.Id == id);
            _context.UserTasks.Remove(userTask);
            _context.SaveChanges();
            return Ok();
        }


    }
}
