using System.Collections.ObjectModel;
using Convey.CQRS.Commands;
using Lapka.Pet.Application.Commands;
using Lapka.Pet.Application.Commands.Handlers;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Repositories;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Lapka.Pet.UnitTests.Application;

public class CreateDogCommandHandlerTest
{
    Task Act(CreateDogCommand command)
        => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_On_Success()
    {
        //ARRANGE
        var command = new CreateDogCommand(Guid.NewGuid(), "name", Gender.Male, DateTime.Now.AddYears(-1), true, 2,
            DogColor.DOG_BLACK, DogBreed.DOG_HUSKY, new Collection<Guid>());
        
        //ACT
        var exception = await Record.ExceptionAsync(() => Act(command));

        //ASSERT
        exception.ShouldBeNull();
        await _repository.Received(1).AddPetAsync(Arg.Any<Core.Entities.Pet>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreateDogCommand> _commandHandler;
    private readonly IPetRepository _repository;

    public CreateDogCommandHandlerTest()
    {
        _repository = Substitute.For<IPetRepository>();

        _commandHandler = new CreateDogCommandHandler(_repository);
    }

    #endregion
}