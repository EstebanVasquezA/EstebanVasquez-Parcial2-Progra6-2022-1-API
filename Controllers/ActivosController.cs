﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstebanVasquez_Parcial2_API.Models;

namespace EstebanVasquez_Parcial2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        private readonly EXAMEN_FINAL_PROGRA6Context _context;

        public ActivosController(EXAMEN_FINAL_PROGRA6Context context)
        {
            _context = context;
        }

        // GET: api/Activos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activo>>> GetActivos()
        {
            return await _context.Activos.ToListAsync();
        }

        // GET: api/Activos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activo>> GetActivo(int id)
        {
            var activo = await _context.Activos.FindAsync(id);

            if (activo == null)
            {
                return NotFound();
            }

            return activo;
        }

        // PUT: api/Activos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivo(int id, Activo activo)
        {
            if (id != activo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(activo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Activos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activo>> PostActivo(Activo activo)
        {
            _context.Activos.Add(activo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivo", new { id = activo.Codigo }, activo);
        }

        // DELETE: api/Activos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivo(int id)
        {
            var activo = await _context.Activos.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }

            _context.Activos.Remove(activo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivoExists(int id)
        {
            return _context.Activos.Any(e => e.Codigo == id);
        }
    }
}
