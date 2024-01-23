using API.Application.DTOs;
using API.Application.Handlers.AreaHandlers;
using API.Application.Queries.AreaQueries;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public  class GetAreasIdByIdHandlerTest
    {
        [Fact]
        public async Task Handle_SuccessfulGetById_ReturnsAreaDTO()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new GetAreaByIdHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();
            var areaId = 1;

            // Configuramos el repositorio simulado para devolver un área ficticia.
            var mockArea = new Area { AreaId = areaId, Name = "Test Area" };
            mockRepository.Setup(repo => repo.GetAreaByIdAsync(areaId)).ReturnsAsync(mockArea);

            // Act
            var result = await handler.Handle(new GetAreaByIdQuery(areaId), cancellationToken);

            // Assert
            VerifyRepositoryGetById(mockRepository, areaId, cancellationToken);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<AreaDTO>>(result);
            Assert.Equal(1, result.Count());
            Assert.Equal(mockArea.AreaId, result.First().AreaId);
            Assert.Equal(mockArea.Name, result.First().Name);
        }

        [Fact]
        public async Task Handle_FailureInRepository_GetAreaByIdAsyncThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IAreaRepository>();
            var handler = new GetAreaByIdHandler(mockRepository.Object);
            var cancellationToken = new CancellationToken();
            var areaId = 1;

            // Configuramos el repositorio simulado para lanzar una excepción al intentar obtener un área por su ID.
            mockRepository.Setup(repo => repo.GetAreaByIdAsync(areaId))
                .ThrowsAsync(new Exception("Simulated exception during area retrieval by ID."));

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAreaByIdQuery(areaId), cancellationToken));
        }

        private void VerifyRepositoryGetById(Mock<IAreaRepository> mockRepository, int areaId, CancellationToken cancellationToken)
        {
            mockRepository.Verify(repo => repo.GetAreaByIdAsync(areaId), Times.Once);
        }

}
