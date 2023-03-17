using Bank.Domain.Interfaces;
using Bank.Domain.UseCases;
using Bank.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Bank.API.Controllers
{

    [ApiController]
    [Route("/api/clientes")]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteUseCase _clienteUseCase;

        public ClientesController(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _clienteUseCase.ObtenerClientes());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cliente cliente)
        {
            try
            {
                return Ok(await _clienteUseCase.GuardarCliente(cliente));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe un cliente con el id: {cliente.Id}");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cliente cliente)
        {
            try
            {
                return Ok(_clienteUseCase.ActualizarCliente(cliente));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe un cliente con el id: {cliente.Id}");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var cliente = await _clienteUseCase.EliminarCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
