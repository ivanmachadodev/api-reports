// Asegúrate de agregar los using necesarios
using Moq;
using API.Application.Commands.AreaCommands;
using API.Application.DTOs;
using API.Application.Handlers.AreaHandlers;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CreateAreaHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_ReturnsAreaDTO()
    {
        // Arrange
        var mockRepository = new Mock<IAreaRepository>();
        var handler = new CreateAreaHandler(mockRepository.Object);
        var cancellationToken = new CancellationToken();
        var createAreaCommand = new CreateAreaCommand("TestArea")
        {
            name = "TestArea"
        };

        // Act
        var result = await handler.Handle(createAreaCommand, cancellationToken);

        // Assert
        AssertResult(result, createAreaCommand);
        VerifyRepositorySave(mockRepository, cancellationToken);
    }

    [Fact]
    public async Task Handle_FailureInRepository_SaveAreaAsyncThrowsException()
    {
        // Arrange
        var mockRepository = new Mock<IAreaRepository>();
        var handler = new CreateAreaHandler(mockRepository.Object);
        var cancellationToken = new CancellationToken();
        var createAreaCommand = new CreateAreaCommand("TestArea")
        {
            name = "TestArea"
        };

        // Configuramos el mock para que lance una excepción al intentar guardar el área.
        mockRepository.Setup(repo => repo.SaveAreaAsync(It.IsAny<Area>(), cancellationToken))
            .ThrowsAsync(new Exception("Simulated exception during area save."));

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(createAreaCommand, cancellationToken));
    }

    private void AssertResult(object result, CreateAreaCommand createAreaCommand)
    {
        Assert.NotNull(result);
        Assert.IsType<AreaDTO>(result);
        Assert.Equal(createAreaCommand.name, (result as AreaDTO).Name);
    }

    private void VerifyRepositorySave(Mock<IAreaRepository> mockRepository, CancellationToken cancellationToken)
    {
        // Verifica que el método SaveAreaAsync del repositorio simulado fue llamado exactamente una vez
        // con cualquier instancia de la clase Area y el token de cancelación proporcionado.
        mockRepository.Verify(
            repo => repo.SaveAreaAsync(It.IsAny<Area>(), cancellationToken),
            Times.Once
        );
    }

    #endregion



}
