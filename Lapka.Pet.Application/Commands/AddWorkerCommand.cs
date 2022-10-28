using Convey.CQRS.Commands;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands;

public record AddWorkerCommand(Guid ShelterId, string Email) : ICommand;