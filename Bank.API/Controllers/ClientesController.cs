using Bank.Domain.Exceptions;
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
            catch (ClienteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cliente cliente)
        {
            try
            {
                return Ok(await _clienteUseCase.ActualizarCliente(cliente));
            }
            catch (ClienteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _clienteUseCase.EliminarCliente(id);
                return NoContent();
            }
            catch(ClienteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
