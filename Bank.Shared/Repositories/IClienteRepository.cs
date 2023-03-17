using Bank.Shared.Entities;

namespace Bank.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente> CrearAsync(Cliente cliente);
        Task<Cliente> ActualizarAsync(Cliente cliente);
        Task EliminarAsync(Cliente cliente);
        Task<Cliente> FindFirstOrDefaultAsync(int id);
    }
}
