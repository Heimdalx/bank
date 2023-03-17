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

        public  Task<Cliente> EliminarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public  Task<Cliente> GuardarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await _repository.ObtenerTodosAsync();
        }

        
    }
}
