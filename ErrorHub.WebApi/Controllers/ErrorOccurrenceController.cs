using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Enuns;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace ErrosHub.WebApi.Controllers
{
    [Route("api/error")]
    [ApiController]
    [Authorize]
    public class ErrorOccurrenceController : ControllerBase
    {
        private readonly IErrorOccurrenceService _errorOccurrenceService;

        public ErrorOccurrenceController(IErrorOccurrenceService errorOccurrenceService)
        {
            _errorOccurrenceService = errorOccurrenceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recoveredList = _errorOccurrenceService.GetAll();
            var errorsList = recoveredList.Select(x => new ErrorOccurrenceVM
            {
                Id = x.Id,
                Level = x.Level.ToString(),
                Environment = x.Environment.ToString(),
                Title = x.Title,
                Description = x.Description,
                ArchiviedRecord = x.ArchiviedRecord,
                Origin = x.Origin,
                CreatedAt = x.CreatedAt
            });
            return Ok(errorsList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ErrorOccurrence errorRecovered;
            try
            {
                errorRecovered = _errorOccurrenceService.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (errorRecovered != null)
            {
                var errorOcurrence = new ErrorOccurrenceVM
                {
                    Id = errorRecovered.Id,
                    Level = errorRecovered.Level.ToString(),
                    Environment = errorRecovered.Environment.ToString(),
                    Title = errorRecovered.Title,
                    Description = errorRecovered.Description,
                    ArchiviedRecord = errorRecovered.ArchiviedRecord,
                    Origin = errorRecovered.Origin,
                    CreatedAt = errorRecovered.CreatedAt
                };
                return Ok(errorOcurrence);
            }
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult Save(ErrorOccurrenceVM errorOccurrence)
        {
            try
            {
                var environment = Enum.Parse(typeof(EnvironmentOccurrence), errorOccurrence.Environment, true);
                var level = Enum.Parse(typeof(LevelOccurrence), errorOccurrence.Level, true);
                _errorOccurrenceService.Save(new ErrorOccurrence
                {
                    Title = errorOccurrence.Title,
                    Level = (LevelOccurrence)level,
                    Environment = (EnvironmentOccurrence)environment,
                    Description = errorOccurrence.Description,
                    Origin = errorOccurrence.Origin,
                    ArchiviedRecord = errorOccurrence.ArchiviedRecord,
                    CreatedAt = errorOccurrence.CreatedAt
                });
                // return StatusCode(201);
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update(int id, ErrorOccurrenceVM errorOccurrence)
        {
            try
            {
                var environment = Enum.Parse(typeof(EnvironmentOccurrence), errorOccurrence.Environment, true);
                var level = Enum.Parse(typeof(LevelOccurrence), errorOccurrence.Level, true);
                _errorOccurrenceService.Update(new ErrorOccurrence
                {
                    Id = id,
                    Title = errorOccurrence.Title,
                    Level = (LevelOccurrence)level,
                    Environment = (EnvironmentOccurrence)environment,
                    Description = errorOccurrence.Description,
                    Origin = errorOccurrence.Origin,
                    ArchiviedRecord = errorOccurrence.ArchiviedRecord,
                    CreatedAt = errorOccurrence.CreatedAt
                });
                // return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(204);
        }

        [HttpPatch("archive/{id}")]
        public IActionResult ArchiveRecord(int id)
        {
            try
            {
                _errorOccurrenceService.ArchiveRecord(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _errorOccurrenceService.Delete(id);
            }
            catch (Exception e)
            {
                throw;
            }

            return Ok("Deleted.");
        }

    }
}
