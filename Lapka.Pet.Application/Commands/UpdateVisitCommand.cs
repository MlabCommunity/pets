using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record UpdateVisitCommand(Guid PetId,Guid VisitId,Guid PrincipalId,bool HasTookPlace,DateTime DateOfVisit,string Description,HashSet<CareType> VisitTypes,double WeightOnVisit):ICommand;

