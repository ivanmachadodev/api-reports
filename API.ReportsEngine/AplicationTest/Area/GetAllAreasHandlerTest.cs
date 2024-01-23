using API.Application.DTOs;
using API.Application.Handlers.AreaHandlers;
using API.Application.Queries.AreaQueries;
using API.Infrastructure.Contracts;
using Moq;
using API.Domain.Entities;
    public class GetAllAreasHandlerTest
    {
        [Fact]
        public async Task Handle_SuccessfulGetAll_ReturnsAreaDTOs()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new GetAllAreasHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();

            // Configuramos el repositorio simulado para devolver algunas áreas ficticias.
            var mockAreas = new List<Area>
        {
            new Area { AreaId = 1, Name = "Area 1" },
            new Area { AreaId = 2, Name = "Area 2" }
        };
            mockRepository.Setup(repo => repo.GetAllAreasAsync()).ReturnsAsync(mockAreas);

            // Act
            var result = await handler.Handle(new GetAllAreasQuery(), cancellationToken);

            // Assert
            VerifyRepositoryGetAll(mockRepository, cancellationToken);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<AreaDTO>>(result);
            Assert.Equal(mockAreas.Count, result.Count());
        }

        [Fact]
        public async Task Handle_FailureInRepository_GetAllAreasAsyncThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new GetAllAreasHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();

            // Configuramos el repositorio simulado para lanzar una excepción al intentar obtener todas las áreas.
            mockRepository.Setup(repo => repo.GetAllAreasAsync())
                .ThrowsAsync(new Exception("Simulated exception during areas retrieval."));

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAllAreasQuery(), cancellationToken));
        }

        private void VerifyRepositoryGetAll(Mock<IAreaRepository> mockRepository, CancellationToken cancellationToken)
        {
            mockRepository.Verify(repo => repo.GetAllAreasAsync(), Times.Once);
        }
    }

