using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiGraphQL.Models.Invoices;

namespace RestApiGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesTblsController : ControllerBase
    {
        private readonly RestApiGraphQldbContext _context;

        public InvoicesTblsController(RestApiGraphQldbContext context)
        {
            _context = context;
        }

        // GET: api/InvoicesTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoicesTbl>>> GetInvoicesTbls()
        {
            return await _context.InvoicesTbls.ToListAsync();
        }

        // GET: api/InvoicesTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoicesTbl>> GetInvoicesTbl(long id)
        {
            var invoicesTbl = await _context.InvoicesTbls.FindAsync(id);

            if (invoicesTbl == null)
            {
                return NotFound();
            }

            return invoicesTbl;
        }

        // PUT: api/InvoicesTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoicesTbl(long id, InvoicesTbl invoicesTbl)
        {
            if (id != invoicesTbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoicesTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesTblExists(id))
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

        // POST: api/InvoicesTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoicesTbl>> PostInvoicesTbl(InvoicesTbl invoicesTbl)
        {
            _context.InvoicesTbls.Add(invoicesTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoicesTbl", new { id = invoicesTbl.Id }, invoicesTbl);
        }

        // DELETE: api/InvoicesTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoicesTbl(long id)
        {
            var invoicesTbl = await _context.InvoicesTbls.FindAsync(id);
            if (invoicesTbl == null)
            {
                return NotFound();
            }

            _context.InvoicesTbls.Remove(invoicesTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoicesTblExists(long id)
        {
            return _context.InvoicesTbls.Any(e => e.Id == id);
        }
    }
}
