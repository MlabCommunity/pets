using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class WorkerMapper
{
    
    public static WorkerDto AsDto(this Worker worker)
        => new()
        {
            Email = worker.Email,
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            WorkerId = worker.WorkerId,
            Stauts = worker.Status,
            CratedAt = worker.CreatedAt
        };
}