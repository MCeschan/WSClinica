using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Especialidad")]
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        public string Nombre { get; set; }

        public List<Medico> Medicos { get; set; }

    }
}
