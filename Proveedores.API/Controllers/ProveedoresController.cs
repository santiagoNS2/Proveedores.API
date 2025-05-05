using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proveedores.Application.Interfaces;
using Proveedores.Domain.Entities;
using Proveedores.Application.DTOs;
using Proveedores.Application.Services;

namespace Proveedores.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    [Authorize]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorService _service;

        public ProveedoresController(IProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetById(string id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null) return NotFound();
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProveedorDto dto)
        {
            var proveedor = new Proveedor
            {
                Nit = dto.Nit,
                RazonSocial = dto.RazonSocial,
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                Departamento = dto.Departamento,
                Correo = dto.Correo,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion,
                NombreContacto = dto.NombreContacto,
                CorreoContacto = dto.CorreoContacto
            };

            await _service.CreateAsync(proveedor);
            return Ok(proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Proveedor proveedor)
        {
            await _service.UpdateAsync(id, proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
