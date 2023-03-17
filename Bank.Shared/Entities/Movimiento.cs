using System.ComponentModel.DataAnnotations;

namespace Bank.Shared.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Display(Name = "TipoMovimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(6, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string TipoMovimiento { get; set; } = null!;

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Valor { get; set; }

        [Display(Name = "Saldo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Saldo { get; set; }

        public Cuenta? Cuenta { get; set; }

        public int CuentaId { get; set; }



    }
}
