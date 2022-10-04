using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateVisitCommand(Guid PetId, Guid PrincipalId, bool? HasTookPlace, DateTime DateOfVisit,
    string Description, HashSet<CareType> CareTypes, double? WeightOnVisit) : ICommand;