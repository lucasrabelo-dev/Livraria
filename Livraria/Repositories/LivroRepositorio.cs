using MySql.Data.MySqlClient;
using Livraria.Models;

namespace Livraria.Repositories
{
    // Cumpre as "promessas" da interface ILivroRepositorio
    public class LivroRepositorio : ILivroRepositorio
    {
        // Endereço do banco (vem do appsettings.json)
        private readonly string _conexaoTexto;

        public LivroRepositorio(IConfiguration configuracao)
        {
            _conexaoTexto = configuracao.GetConnectionString("DefaultConnection")!;
        }

        // Salva um livro novo
        public void Cadastrar(LivroModel livro)
        {
            using var conexao = new MySqlConnection(_conexaoTexto);
            conexao.Open();

            var sql = "INSERT INTO livro (isbn, nome, descricao, valor) VALUES (@isbn, @nome, @descricao, @valor)";
            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@isbn", livro.Isbn);
            comando.Parameters.AddWithValue("@nome", livro.Nome);
            // Se a descrição estiver vazia, guarda "vazio" no banco
            comando.Parameters.AddWithValue("@descricao", (object?)livro.Descricao ?? DBNull.Value);
            comando.Parameters.AddWithValue("@valor", livro.Valor);

            comando.ExecuteNonQuery();
        }

        // Busca todos os livros
        public List<LivroModel> Listar()
        {
            var lista = new List<LivroModel>();

            using var conexao = new MySqlConnection(_conexaoTexto);
            conexao.Open();

            var sql = "SELECT id, isbn, nome, descricao, valor FROM livro";
            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();

            // Lê linha por linha e coloca na lista
            while (leitor.Read())
            {
                lista.Add(new LivroModel
                {
                    Id = leitor.GetInt32("id"),
                    Isbn = leitor.GetString("isbn"),
                    Nome = leitor.GetString("nome"),
                    Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao")) ? null : leitor.GetString("descricao"),
                    Valor = leitor.GetDecimal("valor")
                });
            }

            return lista;
        }
    }
}