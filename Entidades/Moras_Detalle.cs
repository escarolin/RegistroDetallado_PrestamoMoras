using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDetallado_PrestamoMoras.Entidades
{
    public class Moras_Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Fecha")]
        public Moras moras { get; set; } = new Moras();

        public Moras_Detalle()
        {
            IdDetalle = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public Moras_Detalle(int moraId, int prestamoId, float valor)
        {
            IdDetalle = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}