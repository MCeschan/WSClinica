using System;
using System.Collections.Generic;

namespace WSClinica.Models
{
    public class Clinica
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicioActividades { get; set; }

        public string Email { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
}
