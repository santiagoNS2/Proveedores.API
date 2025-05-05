using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proveedores.Application.Interfaces;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;

        public ProveedorService(IProveedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Proveedor proveedor)
        {
            proveedor.FechaCreacion = DateTime.UtcNow;
            await _repository.CreateAsync(proveedor);
        }

        public async Task UpdateAsync(string id, Proveedor proveedor)
        {
            await _repository.UpdateAsync(id, proveedor);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
