
using Bank.API.Data;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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

                throw new RepositoryException("Error al consultar el movimiento", ex);
            }
        }

        public async Task<List<Movimiento>> ObtenerMovimientosPorCuenta(int idCliente, DateTime fecha)
        {
            try
            {
                return await _dataContext.Movimientos
                        .Include(m => m.Cuenta)
                        .ThenInclude(c => c.Cliente)
                        .Where(m => m.Cuenta!.ClienteId == idCliente && m.Fecha.Date == fecha.Date)
                        .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("Error al consultar los movimientos", ex);
            }
        }

        public async Task<List<Movimiento>> ObtenerTodosAsync()
        {

            return await _dataContext.Movimientos.ToListAsync();
        }
    }
}
