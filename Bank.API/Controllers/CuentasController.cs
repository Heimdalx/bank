using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces.IUseCases;
using Bank.Domain.UseCases;
using Bank.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("/api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaUseCase _cuentaUseCase;

        public CuentasController(ICuentaUseCase cuentaUseCase)
        {
            _cuentaUseCase = cuentaUseCase;
        }
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _cuentaUseCase.ObtenerCuentas());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cuenta cuenta)
        {
            try
            {
                return Ok(await _cuentaUseCase.GuardarCuenta(cuenta));
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
        public async Task<ActionResult> PutAsync(Cuenta cuenta)
        {
            try
            {
                return Ok(await _cuentaUseCase.ActualizarCuenta(cuenta));
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
                await _cuentaUseCase.EliminarCuenta(id);
                return NoContent();
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var cuenta = await _cuentaUseCase.FindCuenta(id);
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
    }
}
