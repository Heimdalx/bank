using Bank.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces.IUseCases
{
    public interface ICuentaUseCase
    {
        Task<Cuenta> GuardarCuenta(Cuenta cuenta);
        Task<Cuenta> ActualizarCuenta(Cuenta cuenta);
        Task<Cuenta?> EliminarCuenta(int id);
        Task<Cuenta> FindCuenta(int id);
        Task<List<Cuenta>> ObtenerCuentas();
    }
}
