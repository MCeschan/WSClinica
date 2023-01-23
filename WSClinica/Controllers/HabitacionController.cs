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
    public class HabitacionController : ControllerBase
    {
        private readonly DbClinicaContext context;
        public HabitacionController(DbClinicaContext context)
        {
            this.context = context;
        }
        //GET: api/habitacion
        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();

        }
        //GET api/habitacion/5
        [HttpGet("{id}")]
        public ActionResult<Habitacion> GetById(int id)
        {
            Habitacion habitacion = (from a in context.Habitaciones
                                     where a.Id == id
                                     select a).SingleOrDefault();
            return habitacion;
        }
        //PUT api/habitacion/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }
            context.Entry(habitacion).State = EntityState.Modified; //lo marcamos como objeto modificado
            context.SaveChanges(); //hacemos la modificación
            return NoContent();
        }
        //POST api/habitacion
        [HttpPost]
        public ActionResult Post(Habitacion habitacion)
        {
            if (!ModelState.IsValid) //si falló la validacion, entonces..
            {
                return BadRequest(ModelState);
            }
            context.Habitaciones.Add(habitacion); //si está todo ok, mandamos a la base.
            context.SaveChanges();
            return Ok(); //ES CODIGO 200

        }
        [HttpDelete("{id}")]
        public ActionResult<Habitacion> Delete(int id)
        {//la habitacion eliminada se lo mandamos al cliente.
            var habitacion = (from a in context.Habitaciones
                              where a.Id == id
                              select a).SingleOrDefault();
            //ahí buscamos la habitacion por id.

            if (habitacion == null)
            {
                return NotFound();
            }
            context.Habitaciones.Remove(habitacion);
            context.SaveChanges();
            return habitacion;

        }
    }
}
