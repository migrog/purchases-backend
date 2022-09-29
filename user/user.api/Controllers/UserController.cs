using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using user.api.Models;
using user.domain.core;
using user.domain.core.validators;
using user.domain.entities;
using user.domain.entities.interfaces.services;

namespace user.api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceBase<User> _serviceUser = new ServiceBase<User>();

        [HttpPost("users")]
        public IActionResult Post([FromBody] object req)
        {
            try
            {
                UserPostRequest body = JsonConvert.DeserializeObject<UserPostRequest>(req.ToString());

                var user = new User();
                user.Name = body.Name;
                user.Email = body.Email;

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(body.Password);
                user.Password = passwordHash;

                _serviceUser.Post<UserValidator>(user);

                return Ok("Se registró con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("users/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var user = _serviceUser.Get().Where(x => x.Id == id).FirstOrDefault();

                if (user == null)
                    return NotFound("Recurso no encontrado");

                var result = new UserGetResponse() { Id = user.Id, Name = user.Name, Email = user.Email};

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("users")]
        public IActionResult Put([FromBody] object req)
        {
            try
            {
                UserPutRequest body = JsonConvert.DeserializeObject<UserPutRequest>(req.ToString());

                var user = _serviceUser.Get().Where(x => x.Id == body.Id).FirstOrDefault();
                user.Name = body.Name;
                user.Email = body.Email;

                _serviceUser.Put<UserValidator>(user);

                return Ok("Se actualizó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("users/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var user = _serviceUser.Get().Where(x => x.Id == id).FirstOrDefault();
                if (user == null)
                    return NotFound("Recurso no encontrado");

                _serviceUser.Delete(id);

                return Ok("Se eliminó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}
