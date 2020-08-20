using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Enuns;
using System.Collections.Generic;

namespace ErrorHub.Domain.Repositories.Interfaces
{
    public interface IErrorOccurrenceRepository
    {
        List<ErrorOccurrence> GetAll();
        ErrorOccurrence GetById(int id);
        List<ErrorOccurrence> GetByEnvironment(EnvironmentOccurrence environment);
        void Save(ErrorOccurrence errorOccurrence);
        void Update(ErrorOccurrence errorOccurrence);
        void ArchiveRecord(int id);
        void Delete(int id);
    }
}
