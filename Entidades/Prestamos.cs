using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDetallado_PrestamoMoras.Entidades
{
    public class Prestamos
    {
        [Key]

        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("PersonaId")]
        public virtual List<Moras_Detalle> Detalle { get; set; } = new List<Moras_Detalle>();
    }
}