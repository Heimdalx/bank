using Bank.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces
{
    public interface IClienteUseCase
    {
        Task<Cliente> GuardarCliente(Cliente cliente);
        Task<Cliente> EliminarCliente(Cliente cliente);
        Task<List<Cliente>> ObtenerClientes();
    }
}
