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
    public class SubProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubProducto>>> Get()
        {
            return await _context.SubProductos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubProducto>> Get(int id)
        {
            var SubProducto = await _context.SubProductos.FindAsync(id);
            if (SubProducto == null) return NotFound();
            return SubProducto;
        }

        [HttpPost]
        public async Task<ActionResult<SubProducto>> Post([FromBody] SubProducto SubProducto)
        {
            _context.SubProductos.Add(SubProducto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = SubProducto.Id }, SubProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SubProducto SubProductoActualizado)
        {
            if (id != SubProductoActualizado.Id) return BadRequest();

            _context.Entry(SubProductoActualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubProductoExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var SubProducto = await _context.SubProductos.FindAsync(id);
            if (SubProducto == null) return NotFound();

            _context.SubProductos.Remove(SubProducto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SubProductoExists(int id)
        {
            return _context.SubProductos.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<ActionResult<List<SubProducto>>> GetSubproductosPorProducto(int idProducto)
        {
            return await _context.SubProductos.Where(e => e.IdProducto == idProducto).ToListAsync();
        }
    }
}
