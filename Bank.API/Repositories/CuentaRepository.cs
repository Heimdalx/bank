using Bank.API.Data;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly DataContext _dataContext;

        public CuentaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Cuenta> ActualizarAsync(Cuenta cuenta)
        {
            try
            {
                _dataContext.Update(cuenta);
                await _dataContext.SaveChangesAsync();
                return cuenta;
            }
            catch (DbUpdateException ex)
            {

                throw new RepositoryException($"No existe la cuenta con id {cuenta.Id}", ex);
            }

        }

        public async Task<Cuenta> CrearAsync(Cuenta cuenta)
        {
            try
            {
                _dataContext.Add(cuenta);
                await _dataContext.SaveChangesAsync();
                return cuenta;
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al agregar la cuenta", ex);
            }
        }

        public async Task EliminarAsync(Cuenta cuenta)
        {
            try
            {
                _dataContext.Remove(cuenta);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al eliminar la cuenta", ex);
            }
        }

        public async Task<Cuenta> FindFirstOrDefaultAsync(int id)
        {
            try
            {
                return await _dataContext.Cuentas
                    .Include(cuenta => cuenta.Movimientos)
                    .FirstOrDefaultAsync(cuenta => cuenta.Id == id);
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al consultar la cuenta", ex);
            }
        }



        public async Task<List<Cuenta>> ObtenerTodosAsync()
        {
            return await _dataContext.Cuentas
                      .Include(cuenta => cuenta.Movimientos)
                       .ToListAsync();
        }

    }
}
