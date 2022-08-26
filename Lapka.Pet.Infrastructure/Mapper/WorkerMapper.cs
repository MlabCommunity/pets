using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class WorkerMapper
{
    public static List<WorkerDto> AsWorkerDtos(this Shelter shelter)
        => new List<WorkerDto>(shelter.Workers.Select(x => x.AsDto()));

    public static WorkerDto AsDto(this Worker worker)
        => new()
        {
            WorkerId = worker.WorkerId
        };
}