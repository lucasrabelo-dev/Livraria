// Ferramenta que conversa com o MySQL
using MySql.Data.MySqlClient;
using Livraria.Models;

namespace Livraria.Repositories
{
    // Esta classe cumpre as "promessas" da interface ILoginRepositorio
    public class LoginRepositorio : ILoginRepositorio
    {
        // Guarda o endereço do banco (vem do appsettings.json)
        private readonly string _conexaoTexto;

        public LoginRepositorio(IConfiguration configuracao)
        {
            _conexaoTexto = configuracao.GetConnectionString("DefaultConnection")!;
        }

        // Procura um usuário pelo e-mail
        public LoginModel? BuscarPorEmail(string email)
        {
            // Abre a porta do banco
            using var conexao = new MySqlConnection(_conexaoTexto);
            conexao.Open();

            // O comando SQL (@email será trocado pelo e-mail de verdade)
            var sql = "SELECT id, nome, email, senhahash FROM login WHERE email = @email";
            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@email", email);

            // Lê o resultado
            using var leitor = comando.ExecuteReader();
            if (leitor.Read())
            {
                return new LoginModel
                {
                    Id = leitor.GetInt32("id"),
                    Nome = leitor.GetString("nome"),
                    Email = leitor.GetString("email"),
                    SenhaHash = leitor.GetString("senhahash")
                };
            }

            // Não achou ninguém
            return null;
        }

        // Salva um novo usuário no banco
        public void Cadastrar(LoginModel login)
        {
            using var conexao = new MySqlConnection(_conexaoTexto);
            conexao.Open();

            var sql = "INSERT INTO login (nome, email, senhahash) VALUES (@nome, @email, @senhahash)";
            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", login.Nome);
            comando.Parameters.AddWithValue("@email", login.Email);
            comando.Parameters.AddWithValue("@senhahash", login.SenhaHash);

            // Executa o comando
            comando.ExecuteNonQuery();
        }
    }
}