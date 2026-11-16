// Ferramenta para validar campos
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    // Os dados que a pessoa digita na tela de login
    public class LoginViewModel
    {
        // E-mail digitado
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        // Senha digitada (só passa pela tela, não é guardada)
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}