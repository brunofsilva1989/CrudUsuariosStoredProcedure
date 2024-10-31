using System.ComponentModel.DataAnnotations;

namespace CrudUsuariosStoredProcedure.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório"),
         EmailAddress(ErrorMessage = "Formato do email incorreto!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo cargo é obrigatório")]
        public string Cargo { get; set; }
    }
}
