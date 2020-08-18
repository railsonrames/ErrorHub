using ErrorHub.Domain.Entities;
using System.Collections.Generic;

namespace ErrorHub.Domain.Repositories.Interfaces
{
    public interface IErrorOccurrenceRepository
    {
        List<ErrorOccurrence> GetAll();
        ErrorOccurrence GetById(int id);
        void Save(ErrorOccurrence errorOccurrence);
        void Update(ErrorOccurrence errorOccurrence);
        void ArchiveRecord(int id);
        void Delete(int id);
    }
}
