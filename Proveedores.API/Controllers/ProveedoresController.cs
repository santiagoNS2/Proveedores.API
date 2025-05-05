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

        /// <summary>
        /// Obtiene todos los proveedores registrados en el sistema.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Obtiene un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor</param>
        /// <returns>Proveedor con el ID indicado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetById(string id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null) return NotFound();
            return Ok(proveedor);
        }

        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="dto">Datos del proveedor a registrar</param>
        /// <returns>Proveedor creado</returns>
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

        /// <summary>
        /// Actualiza los datos de un proveedor existente.
        /// </summary>
        /// <param name="id">ID del proveedor a actualizar</param>
        /// <param name="proveedor">Objeto proveedor actualizado</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Proveedor proveedor)
        {
            await _service.UpdateAsync(id, proveedor);
            return NoContent();
        }

        /// <summary>
        /// Elimina un proveedor por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor a eliminar</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
