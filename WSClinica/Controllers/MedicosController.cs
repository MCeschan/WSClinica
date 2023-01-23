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
    public class MedicosController : ControllerBase
    {
        private readonly DbClinicaContext context;
        public MedicosController(DbClinicaContext context)
        {
            this.context = context;
        }
        //GET: api/medico
        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();

        }
        //GET api/medico/5
        [HttpGet("{id}")]
        public ActionResult<Medico> GetById(int id)
        {
            Medico medico = (from a in context.Medicos
                               where a.IdMedico == id
                               select a).SingleOrDefault();
            return medico;
        }
        //PUT api/medico/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }
            context.Entry(medico).State = EntityState.Modified; //lo marcamos como objeto modificado
            context.SaveChanges(); //hacemos la modificación
            return NoContent();
        }
    
    //POST api/medico
    [HttpPost]
    public ActionResult Post(Medico medico)
    {
        if (!ModelState.IsValid) //si falló la validacion, entonces..
        {
            return BadRequest(ModelState);
        }
        context.Medicos.Add(medico); //si está todo ok, mandamos a la base.
        context.SaveChanges();
        return Ok(); //ES CODIGO 200

    }
    [HttpDelete("{id}")]
    public ActionResult<Medico> Delete(int id)
    {//el medico eliminado se lo mandamos al cliente.
        var medico = (from a in context.Medicos
                       where a.IdMedico == id
                       select a).SingleOrDefault();
        //ahí buscamos la clinica por id.

        if (medico == null)
        {
            return NotFound();
        }
        context.Medicos.Remove(medico);
        context.SaveChanges();
        return medico;

    }
}
}
