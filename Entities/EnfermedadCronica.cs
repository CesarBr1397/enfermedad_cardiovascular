using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad.Models
{
    public class EnfermedadCronica
    {
        [Key]
        public int id_enf_cronica { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required]
        public string? descripcion { get; set; }
        [Required]
        public DateOnly fecha_registro { get; set; }
        [Required]
        public DateOnly fecha_inicio { get; set; }
        [Required]
        public bool estado { get; set; }
        public DateOnly fecha_actualizacion { get; set; }
    }
}
