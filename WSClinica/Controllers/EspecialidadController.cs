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
    public class EspecialidadController : ControllerBase
    {
        private readonly DbClinicaContext context;

        public EspecialidadController(DbClinicaContext context)
        {
            this.context = context;
        }

        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            Especialidad especialidad = (from e in context.Especialidades
                                         where e.IdEspecialidad == id
                                         select e).SingleOrDefault();
            return especialidad;
        }

        //api/autor
        [HttpPost]
        public ActionResult Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return Ok();
        }

        //update
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return BadRequest();
            }
            context.Entry(especialidad).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        //DELETE api/autor/{id}
        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            Especialidad especialidad = (from e in context.Especialidades
                           where e.IdEspecialidad == id
                           select e).SingleOrDefault();
            if (especialidad == null)
            {
                return NotFound();
            }
            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return especialidad;
        }
    }
}
