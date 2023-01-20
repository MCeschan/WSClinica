using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set;}

        public int ClinicaID { get; set;}
        [ForeignKey("ClinicaID")]

        public Clinica Clinica { get; set;}
    }
}
