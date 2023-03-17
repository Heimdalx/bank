using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("/api/movimientos")]
    public class MovimientosController : ControllerBase
    {
        /*  private readonly DataContext _dataContext;

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
          }*/

    }
}