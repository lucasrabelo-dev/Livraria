// Ferramenta para validar campos (obrigatório, e-mail válido...)
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    // Esta classe é o "molde" de um usuário, igual à tabela login do banco
    public class LoginModel
    {
        // Número do usuário (o banco cria sozinho)
        public int Id { get; set; }

        // Nome da pessoa (não pode ficar vazio)
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; } = string.Empty;

        // E-mail da pessoa (não pode ficar vazio e precisa ser válido)
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        // A senha guardada de forma embaralhada (nunca a senha de verdade)
        public string SenhaHash { get; set; } = string.Empty;
    }
}