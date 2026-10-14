using System.ComponentModel.DataAnnotations;

namespace Semana09.Caso4.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Escribe el nombre del paciente")]
        public string Paciente { get; set; } = "";

        [Required(ErrorMessage = "Escribe el correo")]
        [EmailAddress(ErrorMessage = "El correo no es valido")]
        public string Correo { get; set; } = "";

        [Required(ErrorMessage = "Elige una especialidad")]
        public string Especialidad { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Display(Name = "Primera vez")]
        public bool PrimeraVez { get; set; }
    }
}
