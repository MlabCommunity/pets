using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record UpdateVisitRequest(bool HasTookPlace,DateTime DateOfVisit,string Description,HashSet<CareType> VisitTypes,double WeightOnVisit);

