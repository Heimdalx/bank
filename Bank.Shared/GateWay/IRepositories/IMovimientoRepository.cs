using Bank.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces.IRepositories
{
    public interface IMovimientoRepository
    {
        Task<List<Movimiento>> ObtenerTodosAsync();
        Task<Movimiento> CrearAsync(Movimiento movimiento);
        Task<Movimiento> FindFirstOrDefaultAsync(int id);
        Task<List<Movimiento>> ObtenerMovimientosPorCuenta( int idCliente, DateTime fecha);
    }
}
