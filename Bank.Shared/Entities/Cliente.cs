using System.ComponentModel.DataAnnotations;

namespace Bank.Shared.Entities
{
    public class Cliente : Persona
    {
        public string ClienteId { get; set; } = null!;

        [Display(Name = "Contrasena")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Contrasena { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Estado { get; set; }
    }
}
