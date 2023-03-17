using Bank.API.Data;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Repositories
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
            try
            {
                _dataContext.Update(cliente);
                await _dataContext.SaveChangesAsync();
                return cliente;
            }
            catch (DbUpdateException ex)
            {

                throw new RepositoryException($"No existe el cliente con id {cliente.Id}", ex);
            }

        }

        public async Task<Cliente> CrearAsync(Cliente cliente)
        {
            try
            {
                _dataContext.Add(cliente);
                await _dataContext.SaveChangesAsync();
                return cliente;
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al agregar el cliente", ex);
            }
        }

        public async Task EliminarAsync(Cliente cliente)
        {
            try
            {
                _dataContext.Remove(cliente);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al eliminar el cliente", ex);
            }
        }

        public async Task<Cliente> FindFirstOrDefaultAsync(int id)
        {
            try
            {
                return await _dataContext.Clientes
                      .Include(cliente => cliente.Cuentas)
                      .ThenInclude(cuenta => cuenta.Movimientos)
                      .FirstOrDefaultAsync(cliente => cliente.Id == id);
            }
            catch (DbUpdateException ex)
            {

                throw new RepositoryException("Error al consultar el cliente", ex);
            }
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
