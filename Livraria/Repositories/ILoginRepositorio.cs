using Livraria.Models;

namespace Livraria.Repositories
{
    // Lista de "promessas": o que o repositório de login sabe fazer
    public interface ILoginRepositorio
    {
        // Procura um usuário pelo e-mail
        LoginModel? BuscarPorEmail(string email);

        // Salva um novo usuário no banco
        void Cadastrar(LoginModel login);
    }
}