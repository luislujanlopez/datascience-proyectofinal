using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalWebApi.Data;
using ProyectoFinalWebApi.Models;

namespace ProyectoFinalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            return await _context.Pedidos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);
            if (Pedido == null) return NotFound();
            return Pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Post([FromBody] Pedido Pedido)
        {
            _context.Pedidos.Add(Pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pedido.Id }, Pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedido PedidoActualizado)
        {
            if (id != PedidoActualizado.Id) return BadRequest();

            _context.Entry(PedidoActualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);
            if (Pedido == null) return NotFound();

            _context.Pedidos.Remove(Pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
       
    }
}
