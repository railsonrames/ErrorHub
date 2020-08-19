using ErrorHub.Domain.Enuns;
using System;

namespace ErrosHub.WebApi.ViewModels
{
    public class ErrorOccurrenceVM
    {
        public LevelOccurrence Level { get; set; }
        public EnvironmentOccurrence Environment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ArchiviedRecord { get; set; }
        public string Origin { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
