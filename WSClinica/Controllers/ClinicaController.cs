using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly DbClinicaContext context;
        public ClinicaController(DbClinicaContext context)
        {
            this.context = context;
        }
        //GET: api/clinica
        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> Get()
        {
            return context.Clinicas.ToList();

        }
        //GET api/clinica/5
        [HttpGet("{id}")]
        public ActionResult<Clinica> GetById(int id)
        {
            Clinica clinica = (from a in context.Clinicas
                           where a.ID == id
                           select a).SingleOrDefault();
            return clinica;
        }
        //PUT api/clinica/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Clinica clinica)
        {
            if (id != clinica.ID)
            {
                return BadRequest();
            }
            context.Entry(clinica).State = EntityState.Modified; //lo marcamos como objeto modificado
            context.SaveChanges(); //hacemos la modificación
            return NoContent();
        }
        //POST api/clinica
        [HttpPost]
        public ActionResult Post(Clinica clinica)
        {
            if (!ModelState.IsValid) //si falló la validacion, entonces..
            {
                return BadRequest(ModelState);
            }
            context.Clinicas.Add(clinica); //si está todo ok, mandamos a la base.
            context.SaveChanges();
            return Ok(); //ES CODIGO 200

        }
        [HttpDelete("{id}")]
        public ActionResult<Clinica> Delete(int id)
        {//la clinica eliminada se lo mandamos al cliente.
            var clinica = (from a in context.Clinicas
                         where a.ID == id
                         select a).SingleOrDefault();
            //ahí buscamos la clinica por id.

            if (clinica == null)
            {
                return NotFound();
            }
            context.Clinicas.Remove(clinica);
            context.SaveChanges();
            return clinica;

        }
    }
}
