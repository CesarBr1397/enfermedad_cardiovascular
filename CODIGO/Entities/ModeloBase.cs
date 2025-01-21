using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace TsaakAPI.Entities
{
    public class ModeloBase
    {

        public int id_enf_cardiovascular { get; set; }
        
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