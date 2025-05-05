using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Proveedores.Application.Services;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proveedores.Tests.Services
{
    public class ProveedorServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsListOfProveedores()
        {
            // Arrange
            var mockRepo = new Mock<IProveedorRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(new List<Proveedor>
                    {
                        new Proveedor { Nit = "123", RazonSocial = "Test S.A." },
                        new Proveedor { Nit = "456", RazonSocial = "Otro S.A." }
                    });

            var service = new ProveedorService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Test S.A.", result[0].RazonSocial);
        }

        [Fact]
        public async Task CreateAsync_CallsRepositoryCreateOnce()
        {
            // Arrange
            var mockRepo = new Mock<IProveedorRepository>();
            var proveedor = new Proveedor { Nit = "789", RazonSocial = "Nuevo S.A." };

            var service = new ProveedorService(mockRepo.Object);

            // Act
            await service.CreateAsync(proveedor);

            // Assert
            mockRepo.Verify(r => r.CreateAsync(proveedor), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ProveedorNoExiste_ReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<IProveedorRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync((Proveedor)null!); // Simula que no encuentra el proveedor

            var service = new ProveedorService(mockRepo.Object);

            // Act
            var result = await service.GetByIdAsync("no-existe");

            // Assert
            Assert.Null(result);
        }


    }
}
