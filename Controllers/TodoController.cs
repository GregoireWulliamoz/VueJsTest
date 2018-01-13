//  =============================================================================
//  <copyright file="TodoController.cs" company="Help Us!">
//      Copyright (c) Help Us! Chavornay SWITZERLAND.
//  </copyright>
//  ============================================================================
//  
//  Workfile: TodoController.cs
//  
//  PROJECT  : VueJsTest
//  CREATION : 13.01.2018
//  AUTHOR   : Grégoire Wulliamoz - grego
// 
//  ----------------------------------------------------------------------------

namespace VueJsTest.Controllers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static readonly ConcurrentBag<Todo> Todos = new ConcurrentBag<Todo>
        {
            new Todo {Id = Guid.NewGuid(), Description = "Learn Vue"}
        };

        [HttpGet]
        public IEnumerable<Todo> GetTodos()
        {
            return Todos.Where(t => !t.Done);
        }

        [HttpPost]
        public Todo AddTodo([FromBody] Todo todo)
        {
            todo.Id = Guid.NewGuid();
            todo.Done = false;
            Todos.Add(todo);
            return todo;
        }

        [HttpDelete("{id}")]
        public ActionResult CompleteTodo(Guid id)
        {
            var todo = Todos.SingleOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Done = true;
            return StatusCode(204);
        }
    }

    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}