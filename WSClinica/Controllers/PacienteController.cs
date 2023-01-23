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
    public class PacienteController : ControllerBase
    {
        private readonly DbClinicaContext context;
        public PacienteController(DbClinicaContext context)
        {
            this.context = context;
        }
        //GET: api/paciente
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();

        }
        //GET api/paciente/5
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            Paciente paciente = (from a in context.Pacientes
                                 where a.Id == id
                                 select a).SingleOrDefault();
            return paciente;
        }
        //PUT api/paciente/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }
            context.Entry(paciente).State = EntityState.Modified; //lo marcamos como objeto modificado
            context.SaveChanges(); //hacemos la modificación
            return NoContent();
        }
        //POST api/paciente
        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid) //si falló la validacion, entonces..
            {
                return BadRequest(ModelState);
            }
            context.Pacientes.Add(paciente); //si está todo ok, mandamos a la base.
            context.SaveChanges();
            return Ok(); //ES CODIGO 200

        }
        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {//el paciente eliminado se lo mandamos al cliente.
            var paciente = (from a in context.Pacientes
                            where a.Id == id
                            select a).SingleOrDefault();
            //ahí buscamos el paciente por id.

            if (paciente == null)
            {
                return NotFound();
            }
            context.Pacientes.Remove(paciente);
            context.SaveChanges();
            return paciente;

        }
    }
}
