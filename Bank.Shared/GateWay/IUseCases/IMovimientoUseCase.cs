using Bank.Shared.Entities;

namespace Bank.Domain.Interfaces.IUseCases
{
    public interface IMovimientoUseCase
    {
        Task<Movimiento> GuardarMovimiento(Movimiento movimiento);
        Task<Movimiento> FindMovimiento(int id);
        Task<List<Movimiento>> ObtenerMovimientos();
    }
}
