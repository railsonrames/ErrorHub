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
    [Authorize("Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usersList = _userService.GetAll();
            return Ok(usersList);
        }

        [HttpPost]
        public IActionResult Save(UserVM user)
        {
            try
            {
                _userService.Save(new User
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
                _userService.Update(new LoginDomain
                {
                    email = userData.Email,
                    password = userData.Password
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
