using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Proveedores.API;
using Proveedores.Application.DTOs;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Proveedores.API.Controllers;
using Proveedores.Tests;



[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Proveedores.Tests.Integration

{

    public class ProveedoresApiTests : IClassFixture<WebApplicationFactory<Proveedores.API.Program>>
    {
        private readonly HttpClient _client;

        public ProveedoresApiTests(WebApplicationFactory<Proveedores.API.Program> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new System.Uri("http://localhost:5000")
            });
        }

        [Fact]
        public async Task Post_And_Get_Proveedor_ShouldWork()
        {
            // Paso 1: obtener token JWT
            var loginRequest = new LoginRequest
            {
                Username = "admin", // debe existir en tu API
                Password = "1234"
            };

            var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginRequest);
            loginResponse.EnsureSuccessStatusCode();

            var tokenResponse = await loginResponse.Content.ReadFromJsonAsync<TokenResponse>(); // asegúrate de tener esta clase
            string token = tokenResponse?.Token ?? throw new Exception("No se recibió el token");

            // Agregar encabezado de autorización
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Arrange: crear proveedor
            var nuevo = new CrearProveedorDto
            {
                Nit = "999888777",
                RazonSocial = "Proveedor Prueba",
                Direccion = "Cra 10 #20-30",
                Ciudad = "Bogotá",
                Departamento = "Cundinamarca",
                Correo = "test@proveedor.com",
                Activo = true,
                FechaCreacion = System.DateTime.UtcNow,
                NombreContacto = "Juan Prueba",
                CorreoContacto = "juan@proveedor.com"
            };

            // Act: enviar POST
            var postResponse = await _client.PostAsJsonAsync("/api/Proveedores", nuevo);
            postResponse.EnsureSuccessStatusCode();

            // Act: enviar GET
            var getResponse = await _client.GetAsync("/api/Proveedores");
            getResponse.EnsureSuccessStatusCode();

            var content = await getResponse.Content.ReadAsStringAsync();

            // Assert: verificar que contiene los datos enviados
            content.Should().Contain("Proveedor Prueba");
            content.Should().Contain("999888777");
        }
    }
}
