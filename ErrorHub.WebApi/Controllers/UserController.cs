using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ErrorHub.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            var usersList = _service.GetAll();
            return Ok(usersList);
        }

        [HttpPost]
        public IActionResult Save(UserVM user)
        {
            try
            {
                _service.Save(new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                });
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult UpdatePassword([FromBody] LoginVM userData)
        {
            try
            {
                _service.Update(new LoginDomain
                {
                    email = userData.email,
                    password = userData.password
                });
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(userData);
        }
    }
}
