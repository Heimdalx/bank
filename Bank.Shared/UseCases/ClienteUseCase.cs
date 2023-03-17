using Bank.Domain.Data;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Domain.Interfaces.IUseCases;
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
            Cliente cliente = await NoExisteClienteExcepcion(id);
            await _repository.EliminarAsync(cliente);
            return cliente;
        }


        public async Task<Cliente> GuardarCliente(Cliente cliente)
        {
            await ExisteClienteExcepcion(cliente);
            return await _repository.CrearAsync(cliente);
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await _repository.ObtenerTodosAsync();
        }

        private async Task<Cliente> NoExisteClienteExcepcion(int id)
        {
            var cliente = await FindCliente(id);
            if (cliente == null)
            {
                throw new UseCaseException($"No existe un cliente con el id: {id}");
            }

            return cliente;
        }

        private async Task ExisteClienteExcepcion(Cliente cliente)
        {
            if (await FindCliente(cliente.Id) != null)
            {
                throw new UseCaseException($"Ya existe un cliente con el id: {cliente.Id}");
            }
        }

        public async Task<Cliente> FindCliente(int id)
        {
            return await _repository.FindFirstOrDefaultAsync(id);
        }
    }
}
