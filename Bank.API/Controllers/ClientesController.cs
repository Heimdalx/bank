using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IUseCases;
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
            catch (UseCaseException ex)
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
            catch (UseCaseException ex)
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
                await _clienteUseCase.EliminarCliente(id);
                return NoContent();
            }
            catch(UseCaseException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var cliente = await _clienteUseCase.FindCliente(id);
                if (cliente == null)
                {
                    return NotFound($"No se encontró ningún cliente con el id: {id}");
                }
                return Ok(cliente);
            }
            catch (UseCaseException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{clienteId}/movimientos")]
        public async Task<ActionResult<List<Movimiento>>> GenerarReporte(int clienteId , [FromQuery] DateTime fecha)
        {
            try
            {
                var movimientos = await _clienteUseCase.GenerarReporte(fecha, clienteId);
                if (movimientos.Any())
                {
                    return Ok(movimientos);
                }
                else
                {
                    return NotFound($"No se encontraron movimientos para la fecha {fecha} en la cuenta del cliente {clienteId}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
