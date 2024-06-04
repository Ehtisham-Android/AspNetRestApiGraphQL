using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiGraphQL.Models.Emp;

namespace RestApiGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpTblsController : ControllerBase
    {
        private readonly RestApiGraphQldbContext _context;

        public EmpTblsController(RestApiGraphQldbContext context)
        {
            _context = context;
        }

        // GET: api/EmpTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpTbl>>> GetEmpTbls()
        {
            return await _context.EmpTbls.ToListAsync();
        }

        // GET: api/EmpTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpTbl>> GetEmpTbl(long id)
        {
            var empTbl = await _context.EmpTbls.FindAsync(id);

            if (empTbl == null)
            {
                return NotFound();
            }

            return empTbl;
        }

        // PUT: api/EmpTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpTbl(long id, EmpTbl empTbl)
        {
            if (id != empTbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(empTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpTblExists(id))
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

        // POST: api/EmpTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpTbl>> PostEmpTbl(EmpTbl empTbl)
        {
            _context.EmpTbls.Add(empTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpTbl", new { id = empTbl.Id }, empTbl);
        }

        // DELETE: api/EmpTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpTbl(long id)
        {
            var empTbl = await _context.EmpTbls.FindAsync(id);
            if (empTbl == null)
            {
                return NotFound();
            }

            _context.EmpTbls.Remove(empTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpTblExists(long id)
        {
            return _context.EmpTbls.Any(e => e.Id == id);
        }
    }
}
