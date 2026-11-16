using Livraria.Models;

namespace Livraria.Repositories
{
    // Lista de "promessas": o que o repositório de livros sabe fazer
    public interface ILivroRepositorio
    {
        // Salva um novo livro no banco
        void Cadastrar(LivroModel livro);

        // Devolve todos os livros cadastrados
        List<LivroModel> Listar();
    }
}