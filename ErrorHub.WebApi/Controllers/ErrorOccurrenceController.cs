using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;


namespace ErrosHub.WebApi.Controllers
{
    [Route("api/error")]
    [ApiController]
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
            var errorsList = _errorOccurrenceService.GetAll();
            return Ok(errorsList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ErrorOccurrence errorOcurrence;
            try
            {
                errorOcurrence = _errorOccurrenceService.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (errorOcurrence != null)
                return Ok(errorOcurrence);
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult Save(ErrorOccurrenceVM errorOccurrence)
        {
            try
            {
                _errorOccurrenceService.Save(new ErrorOccurrence
                {
                    Title = errorOccurrence.Title,
                    Level = errorOccurrence.Level,
                    Environment = errorOccurrence.Environment,
                    Description = errorOccurrence.Description,
                    Origin = errorOccurrence.Origin,
                    ArchiviedRecord = errorOccurrence.ArchiviedRecord,
                    CreatedAt = errorOccurrence.CreatedAt
                });
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult Update(ErrorOccurrenceVM errorOccurrence)
        {
            try
            {
                _errorOccurrenceService.Update(new ErrorOccurrence
                {
                    Title = errorOccurrence.Title,
                    Level = errorOccurrence.Level,
                    Environment = errorOccurrence.Environment,
                    Description = errorOccurrence.Description,
                    Origin = errorOccurrence.Origin,
                    ArchiviedRecord = errorOccurrence.ArchiviedRecord,
                    CreatedAt = errorOccurrence.CreatedAt
                });
            }
            catch (Exception e)
            {
                throw e;
            }

            return StatusCode(204);
        }

        [HttpPatch("{id}")]
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
