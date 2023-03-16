using System.ComponentModel.DataAnnotations;

namespace Bank.Shared.Entities
{
    public class Persona
    {

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Genero { get; set; } = null!;

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(3, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public int Edad { get; set; }

        [Display(Name = "Identificacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Identificacion { get; set; } = null!;

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public int Telefono { get; set; }






    }
}
