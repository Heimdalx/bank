using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("/api/cuentas")]
    public class CuentasController : ControllerBase
    {/*

        private readonly DataContext _dataContext;

        public CuentasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _dataContext.Cuentas
                 .Include(cuenta => cuenta.Movimientos)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cuenta cuenta)
        {
            try
            {
                _dataContext.Add(cuenta);
                await _dataContext.SaveChangesAsync();
                return Ok(cuenta);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe una cuenta con el id: {cuenta.Id}");
                }
                else if (ex.InnerException!.Message.Contains("FOREIGN"))
                {
                    return BadRequest($"No existe un cliente con id: {cuenta.ClienteId}");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cuenta cuenta)
        {
            try
            {
                _dataContext.Update(cuenta);
                await _dataContext.SaveChangesAsync();
                return Ok(cuenta);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe una cuenta con el numero: {cuenta.NumeroCuenta}");
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
            var cuenta = await _dataContext.Cuentas.FirstOrDefaultAsync(cuenta => cuenta.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            _dataContext.Remove(cuenta);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }*/
    }
}
