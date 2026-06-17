using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalasReuniaoApi.Data;
using SalasReuniaoApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace SalasReuniaoApi.Controllers
{
    [ApiController]
    [Route("salas")]
    [Authorize]
    
    public class SalaReuniaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalaReuniaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaReuniao>>> Get()
        {
            return await _context.SalasReuniao.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(SalaReuniao sala)
        {
            _context.SalasReuniao.Add(sala);
            await _context.SaveChangesAsync();
            return Ok(sala);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SalaReuniao sala)
        {
            var salaBanco = await _context.SalasReuniao.FindAsync(id);

            if (salaBanco == null)
            {
                return NotFound();
            }

            salaBanco.Nome = sala.Nome;
            salaBanco.Capacidade = sala.Capacidade;
            salaBanco.PossuiProjetor = sala.PossuiProjetor;

            await _context.SaveChangesAsync();

            return Ok(salaBanco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sala = await _context.SalasReuniao.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            _context.SalasReuniao.Remove(sala);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}