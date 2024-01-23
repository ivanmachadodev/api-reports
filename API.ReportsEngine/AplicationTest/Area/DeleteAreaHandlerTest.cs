using API.Application.Commands.AreaCommands;
using API.Application.Handlers.AreaHandlers;
using API.Infrastructure.Contracts;
using MediatR;
using Moq;

    public class DeleteAreaHandlerTest
    {
        [Fact]
        public async Task Handle_SuccessfulDelete_ReturnsUnit()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new DeleteAreaHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();
            var deleteAreaCommand = new DeleteAreaCommand(1);

            // Act
            var result = await handler.Handle(deleteAreaCommand, cancellationToken);

            // Assert
            VerifyRepositoryDelete(mockRepository, deleteAreaCommand, cancellationToken);
            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_FailureInRepository_DeleteAreaAsyncThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new DeleteAreaHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();
            var deleteAreaCommand = new DeleteAreaCommand(1);

            // Configuramos el mock para que lance una excepción al intentar eliminar el área.
            mockRepository.Setup(repo => repo.DeleteAreaAsync(deleteAreaCommand.Id, cancellationToken))
                .ThrowsAsync(new Exception("Simulated exception during area deletion."));

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(deleteAreaCommand, cancellationToken));
        }

        private void VerifyRepositoryDelete(Mock<IAreaRepository> mockRepository, DeleteAreaCommand deleteAreaCommand, CancellationToken cancellationToken)
        {
            mockRepository.Verify(repo => repo.DeleteAreaAsync(deleteAreaCommand.Id, cancellationToken), Times.Once);
        }
    }

