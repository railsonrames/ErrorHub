using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Repositories.Interfaces;
using ErrorHub.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ErrorHub.Domain.Services
{
    public class ErrorOccurrenceService : IErrorOccurrenceService
    {
        private readonly IErrorOccurrenceRepository _repository;

        public ErrorOccurrenceService(IErrorOccurrenceRepository repository)
        {
            _repository = repository;
        }

        public IList<ErrorOccurrence> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ErrorOccurrence GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(ErrorOccurrence errorOccurrence)
        {
            try
            {
                if(errorOccurrence.CreatedAt == DateTime.MinValue || errorOccurrence.CreatedAt == null)
                {
                    errorOccurrence.CreatedAt = DateTime.Now;
                }
                _repository.Save(errorOccurrence);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(ErrorOccurrence errorOccurrence)
        {
            try
            {
                _repository.Update(errorOccurrence);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ArchiveRecord(int id)
        {
            try
            {
                _repository.ArchiveRecord(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
