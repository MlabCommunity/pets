using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Core.Events;

public record DeletedFileEvent(string FileUrl) : IDomainEvent;
