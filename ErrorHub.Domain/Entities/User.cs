using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorHub.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatória.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail obrigatório.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória.")]
        public string Password { get; set; }
    }
}
