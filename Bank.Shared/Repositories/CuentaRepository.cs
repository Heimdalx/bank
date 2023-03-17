using Bank.Domain.Data;
using Bank.Domain.Exceptions;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
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
                return await _dataContext.Cuentas.FirstOrDefaultAsync(cuenta => cuenta.Id == id);
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al consultar el cliente", ex);
            }
        }

        public Task<Cuenta> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cuenta>> ObtenerTodosAsync()
        {
            return await _dataContext.Cuentas
                      .Include(cuenta => cuenta.Movimientos)
                       .ToListAsync();
        }

    }
}
