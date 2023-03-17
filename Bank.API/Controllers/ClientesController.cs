using Bank.API.Data;
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

        private readonly DataContext _dataContext;

        public ClientesController(DataContext dataContext)
        {
            _dataContext= dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _dataContext.Clientes
               // .Include(cliente => cliente.Cuentas!)
               // .ThenInclude(cuenta => cuenta.Movimientos)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cliente cliente)
        {
            try
            {
                _dataContext.Add(cliente);
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe un cliente con el id: {cliente.ClienteId}");
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
                _dataContext.Update(cliente);
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest($"Ya existe un cliente con el id: {cliente.ClienteId}");
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
            var cliente = await _dataContext.Clientes.FirstOrDefaultAsync(cliente => cliente.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _dataContext.Remove(cliente);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
