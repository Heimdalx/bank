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
    public class MovimientoUseCase : IMovimientoUseCase
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private const string DEBITO = "Debito";

        public MovimientoUseCase(IMovimientoRepository movimientoRepository,ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }
        public async Task<Movimiento> FindMovimiento(int id)
        {
            return await _movimientoRepository.FindFirstOrDefaultAsync(id);
        }

        public async Task<Movimiento> GuardarMovimiento(Movimiento movimiento)
        {
            Cuenta cuenta = await _cuentaRepository.FindFirstOrDefaultAsync(movimiento.CuentaId);
            if (cuenta == null)
            {
                throw new UseCaseException($"No existe una cuenta con el id: {movimiento.CuentaId}");
            }
            if (DEBITO.Equals(movimiento.TipoMovimiento))
            {
                if((cuenta.SaldoInicial - movimiento.Valor ) < 0)
                {
                    throw new UseCaseException($"Saldo no disponible");
                }
                cuenta.SaldoInicial -= movimiento.Valor;
                movimiento.Saldo = cuenta.SaldoInicial;
            }

            return await _movimientoRepository.CrearAsync(movimiento);
        }

        public async Task<List<Movimiento>> ObtenerMovimientos()
        {
            return await _movimientoRepository.ObtenerTodosAsync();
        }
    }
}
