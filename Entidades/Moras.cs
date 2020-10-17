using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroDetallado_PrestamoMoras.DAL;

namespace RegistroDetallado_PrestamoMoras.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
        }

        [ForeignKey("MoraId")]
        public virtual List<Moras_Detalle> Detalle { get; set; } = new List<Moras_Detalle>();
    }
}