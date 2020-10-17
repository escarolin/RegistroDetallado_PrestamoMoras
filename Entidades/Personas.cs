using System;
using System.ComponentModel.DataAnnotations;


namespace RegistroDetallado_PrestamoMoras.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public decimal Balance { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}