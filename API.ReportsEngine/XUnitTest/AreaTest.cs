//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using API.Application.Commands.AreaCommands;
//using API.Application.DTOs;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using API.ReportsEngine.Controllers;

//namespace XUnitTest
//{
//    public class AreaTest
//    {


//        //Varios casos para un mismo endpoint ? 

//        [Fact]
//        public async Task CreateArea_ReturnsOkResult()
//        {
//            // Arrange
//            var mockMediator = new Mock<IMediator>();
//            var areaDto = new AreaDTO { 
//            };


//            mockMediator.Setup(mediator => mediator.Send(It.IsAny<CreateAreaCommand>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(areaDto);

//            var controller = new AreaController(mockMediator.Object);

//            // Act
//            //var command = new CreateAreaCommand { /* Proporciona datos de ejemplo para el comando */ };
//            var result = await controller.CreateArea(command);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var model = Assert.IsType<AreaDTO>(okResult.Value);

//            // Agrega más aserciones según tu lógica de negocio y requisitos
//            Assert.NotNull(model);
//            Assert.Equal(areaDto, model); // Ajusta según tu lógica
//        }


//        [Fact]
//        public async Task UpdateArea_WithValidData_ReturnsOkResult()
//        {
//            // Arrange
//            var mockMediator = new Mock<IMediator>();
//            var updatedAreaDto = new AreaDTO { /* Proporciona datos de ejemplo para el área DTO actualizado */ };

//            // Configura el mock para devolver el área DTO actualizado cuando se envía el comando
//            mockMediator.Setup(mediator => mediator.Send(It.IsAny<UpdateAreaCommand>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(updatedAreaDto);

//            var controller = new AreaController(mockMediator.Object);

//            // Act
//            var command = new UpdateAreaCommand { Id = 1, /* Proporciona otros datos de ejemplo para el comando */ };
//            var result = await controller.UpdateArea(1, command);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var model = Assert.IsType<AreaDTO>(okResult.Value);

//            // Agrega más aserciones según tu lógica de negocio y requisitos
//            Assert.NotNull(model);
//            Assert.Equal(updatedAreaDto, model); // Ajusta según tu lógica
//        }


//    }
//}
