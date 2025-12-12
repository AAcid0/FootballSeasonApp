using Moq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Entities;

namespace WebAPI.Tests
{
    public class PlayersControllerTests
    {
        private readonly Mock<IRepository<Player>> _mockService;
        private readonly PlayersController _controller;

        public PlayersControllerTests()
        {
            // ARRANGE (Preparación)
            // Creamos el simulacro del servicio
            _mockService = new Mock<IRepository<Player>>();

            // Inyectamos el servicio falso en el controlador real
            _controller = new PlayersController(_mockService.Object);
        }

        [Fact]
        public async Task GetPlayers_ShouldReturnOk_WhenPlayersExist()
        {
            // ARRANGE (Preparación de datos falsos)
            var fakePlayers = new List<Player>
        {
            new Player { Id = 1, Name = "Jugador A", Position = 1 },
            new Player { Id = 2, Name = "Jugador B", Position = 2}
        };

            // Le enseñamos al Mock qué hacer: "Cuando te pidan GetAllAsync, devuelve la lista falsa"
            _mockService.Setup(service => service.GetAllAsync())
                        .ReturnsAsync(fakePlayers);

            // ACT (Ejecución)
            var result = await _controller.GetAllPlayers();

            // ASSERT (Verificación)
            // 1. Verificamos que la respuesta sea un HTTP 200 OK
            var okResult = Assert.IsType<OkObjectResult>(result);

            // 2. Verificamos que dentro del OK vengan los datos correctos
            var returnedPlayers = Assert.IsType<List<Player>>(okResult.Value);
            Assert.Equal(2, returnedPlayers.Count); // Esperamos 2 jugadores
        }

        [Fact]
        public async Task GetPlayers_ShouldReturnNotFound_WhenListIsEmpty()
        {
            // ARRANGE
            _mockService.Setup(s => s.GetAllAsync())
                        .ReturnsAsync(new List<Player>()); // Lista vacía

            // ACT
            var result = await _controller.GetAllPlayers();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPlayers = Assert.IsType<List<Player>>(okResult.Value);
            Assert.Empty(returnedPlayers); // Verificamos que la lista esté vacía
        }

        [Fact]
        public async Task CreatePlayer_ShouldReturnCreatedAtAction_WhenPlayerIsCreated()
        {
            // ARRANGE
            var newPlayer = new Player { Name = "Jugador C", Position = 3 };
            var createdPlayer = new Player { Id = 3, Name = "Jugador C", Position = 3 };

            _mockService.Setup(s => s.AddAsync(newPlayer))
                        .ReturnsAsync(createdPlayer);

            // ACT
            var result = await _controller.CreatePlayer(newPlayer);

            // ASSERT
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedPlayer = Assert.IsType<Player>(createdAtActionResult.Value);
            Assert.Equal(createdPlayer.Id, returnedPlayer.Id);
            Assert.Equal(createdPlayer.Name, returnedPlayer.Name);
            Assert.Equal(createdPlayer.Position, returnedPlayer.Position);
        }
    }
}