﻿using DemoWebApp.Models;
using DemoWebApp.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> service;

        public UsersController(IRepository<User> service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(service.Read());
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            return Ok(service.Read(id));
        }

        [HttpPost] 
        public IActionResult Create([FromBody] User user)
        {
            return Ok(service.Create(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            user.Id = id;
            service.Update(user);
            return Ok();
        }
    }
}
