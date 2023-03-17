using Bank.Domain.Data;
using Bank.Domain.Interfaces;
using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Domain.UseCases
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _repository;

        public ClienteUseCase(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> ActualizarCliente(Cliente cliente)
        {
           return await _repository.ActualizarAsync(cliente);
        }

        public async Task<Cliente?> EliminarCliente(int id)
        {
            var cliente = await _repository.FindFirstOrDefaultAsync(id);
            if (cliente == null)
            {
                return null;
            }
            await _repository.EliminarAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> GuardarCliente(Cliente cliente)
        {
           return await _repository.CrearAsync(cliente);
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await _repository.ObtenerTodosAsync();
        }


        
    }
}
