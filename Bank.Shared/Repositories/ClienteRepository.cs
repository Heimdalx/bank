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

        public async Task<Cliente> ActualizarAsync(Cliente cliente)
        {

            _dataContext.Update(cliente);
            await _dataContext.SaveChangesAsync();
            return cliente;

        }

        public async Task<Cliente> CrearAsync(Cliente cliente)
        {
             _dataContext.Add(cliente);
            await  _dataContext.SaveChangesAsync();
            return cliente;
        }

        public async Task EliminarAsync(Cliente cliente)
        {

            _dataContext.Remove(cliente);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Cliente> FindFirstOrDefaultAsync(int id)
        {
           return await _dataContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
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
