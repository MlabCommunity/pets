﻿using Lapka.Pet.Core.DomainThings;

namespace Confab.Shared.Abstractions.Kernel
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(params IDomainEvent[] events);
    }
}