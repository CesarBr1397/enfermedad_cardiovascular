using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entidad.Models
{
    public class EnfermedadCronica
    {
        [Key]
        public int id_enf_cronica { get; set; }

        public string? nombre { get; set; }

        public string? descripcion { get; set; }

        [JsonIgnore]
        public DateOnly fecha_registro
        {
            get => DateOnly.FromDateTime(fecha_registro2); // Convierte de DateTime a DateOnly
            set => fecha_registro2 = value.ToDateTime(TimeOnly.MinValue); // Convierte de DateOnly a DateTime
        }

        // Propiedad interna para almacenar la representación como DateTime
        [NotMapped]
        public DateTime fecha_registro2 { get; set; }

        [JsonIgnore]
        public DateOnly fecha_inicio
        {
            get => DateOnly.FromDateTime(fecha_inicio2);
            set => fecha_inicio2 = value.ToDateTime(TimeOnly.MinValue);
        }

        [NotMapped]
        public DateTime fecha_inicio2 { get; set; }

        [Required]
        public bool estado { get; set; }

        [JsonIgnore]
        public DateOnly fecha_actualizacion
        {
            get => DateOnly.FromDateTime(fecha_actualizacion2);
            set => fecha_actualizacion2 = value.ToDateTime(TimeOnly.MinValue);
        }

        [NotMapped]
        public DateTime fecha_actualizacion2 { get; set; }
    }
}
