using Bank.Domain.Data;
using Bank.Domain.Interfaces;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Domain.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task ActualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task EliminarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _dataContext.Clientes
                      .Include(cliente => cliente.Cuentas!)
                      .ThenInclude(cuenta => cuenta.Movimientos)
                       .ToListAsync();
        }
    }
}
