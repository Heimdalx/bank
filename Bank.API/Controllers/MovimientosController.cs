using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IUseCases;
using Bank.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("/api/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoUseCase _movimientoUseCase;

        public MovimientosController(IMovimientoUseCase movimientoUseCase)
        {
            _movimientoUseCase = movimientoUseCase;
        }
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _movimientoUseCase.ObtenerMovimientos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var cuenta = await _movimientoUseCase.FindMovimiento(id);
                if (cuenta == null)
                {
                    return NotFound($"No se encontró ningúna cuenta con el id: {id}");
                }
                return Ok(cuenta);
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

        [HttpPost]
        public async Task<ActionResult> PostAsync(Movimiento movimiento)
        {
            try
            {
                return Ok(await _movimientoUseCase.GuardarMovimiento(movimiento));
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

    }
}