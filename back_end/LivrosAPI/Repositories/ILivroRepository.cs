using LivrosAPI.Models;

namespace LivrosAPI.Repository
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> GetAll();
        Livro GetById(int id);
        void Add(Livro livro);
        void Update(Livro livro);
        void Delete(int id);

    }
}
