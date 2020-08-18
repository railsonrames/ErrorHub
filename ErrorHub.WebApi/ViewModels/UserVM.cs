using System.ComponentModel.DataAnnotations;

namespace ErrosHub.WebApi.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail obrigatório.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória.")]
        public string Password { get; set; }
    }
}
