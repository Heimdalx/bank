using Bank.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces.IRepositories
{
    public interface ICuentaRepository
    {
        Task<List<Cuenta>> ObtenerTodosAsync();
        Task<Cuenta> CrearAsync(Cuenta cuenta);
        Task<Cuenta> ActualizarAsync(Cuenta cuenta);
        Task EliminarAsync(Cuenta cuenta);
        Task<Cuenta> FindFirstOrDefaultAsync(int id);

        Task<List<Cuenta>> ObtenerCuentasPorCliente(int id);
    }
}
