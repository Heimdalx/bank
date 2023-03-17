using System.ComponentModel.DataAnnotations;

namespace Bank.Shared.Entities
{
    public class Cuenta
    {

        public int Id { get; set; }

        [Display(Name = "NumeroCuenta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public long NumeroCuenta { get; set; }

        [Display(Name = "TipoCuenta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(9, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string TipoCuenta { get; set; } = null!;

        [Display(Name = "SaldoInicial")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SaldoInicial { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Estado { get; set; }

        public Cliente? Cliente { get; set; }

        public int ClienteId { get; set; }

        public ICollection<Movimiento>? Movimientos { get; set; }
    }
}
