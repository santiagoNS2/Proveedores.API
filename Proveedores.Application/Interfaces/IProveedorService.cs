using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proveedores.Domain.Entities;

namespace Proveedores.Application.Interfaces
{
   public  interface IProveedorService
    {
        Task<List<Proveedor>> GetAllAsync();
        Task<Proveedor?> GetByIdAsync(string id);
        Task CreateAsync(Proveedor proveedor);
        Task UpdateAsync(string id, Proveedor proveedor);
        Task DeleteAsync(string id);
    }
}
