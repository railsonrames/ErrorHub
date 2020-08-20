using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Enuns;
using System.Collections.Generic;

namespace ErrorHub.Domain.Services.Interfaces
{
    public interface IErrorOccurrenceService
    {
        IList<ErrorOccurrence> GetAll();
        ErrorOccurrence GetById(int id);
        IList<ErrorOccurrence> GetByEnvironment(EnvironmentOccurrence environment);
        void Save(ErrorOccurrence errorOccurrence);
        void Update(ErrorOccurrence errorOccurrence);
        void ArchiveRecord(int id);
        void Delete(int id);
    }
}
