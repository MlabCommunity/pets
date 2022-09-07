using System.Collections.ObjectModel;
using Convey.CQRS.Commands;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Commands.Handlers;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Repositories;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Lapka.Pet.UnitTests.Application;

public class CreateLostOtherPetCommandHandlerTest
{
    Task Act(CreateLostOtherPetCommand command)
        => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_On_Success()
    {
        //ARRANGE
        var command = new CreateLostOtherPetCommand(Guid.NewGuid(), "name", Gender.Male, DateTime.Now.AddYears(-1), true, 2,
           new Collection<Guid>());
        
        //ACT
        var exception = await Record.ExceptionAsync(() => Act(command));

        //ASSERT
        exception.ShouldBeNull();
        await _repository.Received(1).AddPetAsync(Arg.Any<Core.Entities.Pet>());
        _cacheStorage.Received(1).SetPetId(Arg.Any<Guid>(), Arg.Any<Guid>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreateLostOtherPetCommand> _commandHandler;
    private readonly IPetRepository _repository;
    private readonly IUserCacheStorage _cacheStorage;

    public CreateLostOtherPetCommandHandlerTest()
    {
        _repository = Substitute.For<IPetRepository>();
        _cacheStorage = Substitute.For<IUserCacheStorage>();
        _commandHandler = new CreateLostOtherPetCommandHandler(_repository,_cacheStorage);
    }

    #endregion
}