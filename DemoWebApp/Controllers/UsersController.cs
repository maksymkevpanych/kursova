using DemoWebApp.Models;
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
        public IActionResult Read(
            [FromQuery] string name,
            [FromQuery] string email,
            [FromQuery] string orderBy = "Id",
            [FromQuery] string order = "asc",
            [FromQuery] int page = 1,
            [FromQuery] int perPage = 25)
        {
            var filterBy = new User()
            {
                Name = name,
                Email = email
            };

            return Ok(new Response()
            {
                Status = 200,
                Data = new
                {
                    count = service.Count(filterBy),
                    items = service.Read(filterBy, orderBy, order, page, perPage)
                }
            });
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(int id)
        {
            return Ok(new Response()
            {
                Status = 200,
                Data = service.Read(id)
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            return Created(nameof(User), new Response()
            {
                Status = 201,
                Data = service.Create(user)
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok(new Response()
            {
                Status = 200
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            user.Id = id;
            service.Update(user);
            return Ok(new Response()
            {
                Status = 200
            });
        }
    }
}
