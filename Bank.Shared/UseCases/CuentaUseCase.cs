using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Domain.Interfaces.IUseCases;
using Bank.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.UseCases
{
    public class CuentaUseCase : ICuentaUseCase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaUseCase(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }
        public async Task<Cuenta> ActualizarCuenta(Cuenta cuenta)
        {

            return await _cuentaRepository.ActualizarAsync(cuenta);
        }

        public async Task<Cuenta?> EliminarCuenta(int id)
        {
            Cuenta cuenta = await NoExisteCuentaExcepcion(id);
            await _cuentaRepository.EliminarAsync(cuenta);
            return cuenta;
        }


        public async Task<Cuenta> GuardarCuenta(Cuenta cuenta)
        {
            await ExisteCuentaExcepcion(cuenta);
            return await _cuentaRepository.CrearAsync(cuenta);
        }

        public async Task<List<Cuenta>> ObtenerCuentas()
        {
            return await _cuentaRepository.ObtenerTodosAsync();
        }

        private async Task<Cuenta> NoExisteCuentaExcepcion(int id)
        {
            var cliente = await FindCuenta(id);
            if (cliente == null)
            {
                throw new UseCaseException($"No existe una cuenta con el id: {id}");
            }

            return cliente;
        }

        private async Task ExisteCuentaExcepcion(Cuenta cuenta)
        {
            if (await FindCuenta(cuenta.Id) != null)
            {
                throw new UseCaseException($"Ya existe una cuenta con el id: {cuenta.Id}");
            }
        }

        public async Task<Cuenta> FindCuenta(int id)
        {
            return await _cuentaRepository.FindFirstOrDefaultAsync(id);
        }
    }
}
