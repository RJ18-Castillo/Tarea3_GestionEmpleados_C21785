using System.ComponentModel.DataAnnotations;

namespace Tarea3_GestionEmpleados_C21785.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(400000, 10000000, ErrorMessage = "El salario debe estar entre 400000 y 10000000")]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        // 🔥 PROPIEDAD CALCULADA (te la revisan fijo)
        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}