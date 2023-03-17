using Bank.Shared.Entities;

namespace Bank.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente> CrearAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
        Task EliminarAsync(Cliente cliente);
    }
}
