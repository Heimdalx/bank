
using Bank.API.Data;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.API.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly DataContext _dataContext;

        public MovimientoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Movimiento> CrearAsync(Movimiento movimiento)
        {

            try
            {
                _dataContext.Add(movimiento);
                await _dataContext.SaveChangesAsync();
                return movimiento;
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al agregar el movimiento", ex);
            }
        }

        public async Task<Movimiento> FindFirstOrDefaultAsync(int id)
        {

            try
            {
                return await _dataContext.Movimientos
                      .FirstOrDefaultAsync(movimiento => movimiento.Id == id);
            }
            catch (DbUpdateException ex)
            {

                throw new RepositoryException("Error al consultar el cliente", ex);
            }
        }

        public async Task<List<Movimiento>> ObtenerTodosAsync()
        {

            return await _dataContext.Movimientos.ToListAsync();
        }
    }
}
