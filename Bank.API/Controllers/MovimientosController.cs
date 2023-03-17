using Bank.API.Data;
using Bank.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("/api/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MovimientosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _dataContext.Movimientos
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Movimiento movimiento)
        {
            try
            {
                _dataContext.Add(movimiento);
                await _dataContext.SaveChangesAsync();
                return Ok(movimiento);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe una cuenta con el id: {movimiento.Id}");
                }
                else if (ex.InnerException!.Message.Contains("FOREIGN"))
                {
                    return BadRequest($"No existe una cuenta con id: {movimiento.CuentaId}");
                }
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Movimiento movimiento)
        {
            try
            {
                _dataContext.Update(movimiento);
                await _dataContext.SaveChangesAsync();
                return Ok(movimiento);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe un movimiento con el numero: {movimiento.Id}");
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
            var movimiento = await _dataContext.Movimientos.FirstOrDefaultAsync(movimiento => movimiento.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }
            _dataContext.Remove(movimiento);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}