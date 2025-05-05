using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Proveedores.Infrastructure.Data;

namespace Proveedores.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _collection;

        public ProveedorRepository(IOptions<MongoDbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _collection = database.GetCollection<Proveedor>(mongoSettings.Value.CollectionName);
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Proveedor proveedor)
        {
            await _collection.InsertOneAsync(proveedor);
        }

        public async Task UpdateAsync(string id, Proveedor proveedor)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, proveedor);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}
