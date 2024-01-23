// Asegúrate de agregar los using necesarios
using Xunit;
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
        // Creamos un mock del repositorio de áreas para simular su comportamiento.
        var mockRepository = new Mock<IAreaRepository>();

        // Instanciamos el manejador CreateAreaHandler, proporcionándole el mock del repositorio.
        var handler = new CreateAreaHandler(mockRepository.Object);

        // Creamos un token de cancelación (puede ser necesario para algunos métodos asíncronos).
        var cancellationToken = new CancellationToken();

        // Creamos un objeto de comando CreateAreaCommand con datos de prueba.
        var createAreaCommand = new CreateAreaCommand("TestArea")
        {
            name = "TestArea"
        };

        // Act

        // Llamamos al método Handle del manejador con el comando y el token de cancelación.
        var result = await handler.Handle(createAreaCommand, cancellationToken);

        // Assert
        // Verificamos que el resultado no sea nulo.
        Assert.NotNull(result);

        // Verificamos que el resultado sea de tipo AreaDTO.
        Assert.IsType<AreaDTO>(result);

        // Verificamos que el nombre en el resultado coincida con el nombre del comando.
        Assert.Equal(createAreaCommand.name, result.Name);

        // Verificamos que el método SaveAreaAsync del repositorio simulado fue llamado una vez
        // con cualquier instancia de la clase Area y el token de cancelación.
        mockRepository.Verify(repo => repo.SaveAreaAsync(It.IsAny<Area>(), cancellationToken), Times.Once);
    }
}
