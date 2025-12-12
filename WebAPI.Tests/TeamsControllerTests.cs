using Moq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Entities;

namespace WebAPI.Tests
{
    public class TeamsControllerTests
    {
        private readonly Mock<IRepository<Team>> _mockService;
        private readonly TeamsController _controller;

        public TeamsControllerTests()
        {
            // ARRANGE (Preparación)
            // Creamos el simulacro del servicio
            _mockService = new Mock<IRepository<Team>>();

            // Inyectamos el servicio falso en el controlador real
            _controller = new TeamsController(_mockService.Object);
        }

        [Fact] // Esta etiqueta indica que es una prueba
        public async Task GetTeams_ShouldReturnOk_WhenTeamsExist()
        {
            // ARRANGE (Preparación de datos falsos)
            var fakeTeams = new List<Team>
            {
                new Team { Id = 1, Name = "Equipo A", TeamCode = "EQA" },
                new Team { Id = 2, Name = "Equipo B", TeamCode = "EQB" }
            };

            // Le enseñamos al Mock qué hacer: "Cuando te pidan GetTeamsAsync, devuelve la lista falsa"
            _mockService.Setup(service => service.GetAllAsync())
                        .ReturnsAsync(fakeTeams);

            // ACT (Ejecución)
            var result = await _controller.GetAllTeams();

            // ASSERT (Verificación)
            // 1. Verificamos que la respuesta sea un HTTP 200 OK
            var okResult = Assert.IsType<OkObjectResult>(result);

            // 2. Verificamos que dentro del OK vengan los datos correctos
            var returnedTeams = Assert.IsType<List<Team>>(okResult.Value);
            Assert.Equal(2, returnedTeams.Count); // Esperamos 2 equipos
        }

        [Fact]
        public async Task GetTeams_ShouldReturnNotFound_WhenListIsEmpty() // Opcional, depende de tu lógica
        {
            // ARRANGE
            _mockService.Setup(s => s.GetAllAsync())
                        .ReturnsAsync(new List<Team>()); // Lista vacía

            // ACT
            var result = await _controller.GetAllTeams();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var teams = Assert.IsType<List<Team>>(okResult.Value);
            Assert.Empty(teams);
        }

        [Fact]
        public async Task CreateTeam_ShouldReturnCreatedAtAction_WhenTeamIsCreated()
        {
            // ARRANGE
            var newTeam = new Team { Name = "Equipo C", TeamCode = "EQC" };
            var createdTeam = new Team { Id = 3, Name = "Equipo C", TeamCode = "EQC" };

            _mockService.Setup(s => s.AddAsync(newTeam))
                        .ReturnsAsync(createdTeam);

            // ACT
            var result = await _controller.CreateTeam(newTeam);

            // ASSERT
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedTeam = Assert.IsType<Team>(createdAtActionResult.Value);
            Assert.Equal(3, returnedTeam.Id);
            Assert.Equal("Equipo C", returnedTeam.Name);
            Assert.Equal("EQC", returnedTeam.TeamCode);
        }
    }
}