using LivrosAPI.Models;
using LivrosAPI.Repository;

namespace LivrosAPI.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Livro> GetAll() => _repository.GetAll();

        public Livro GetById(int id) => _repository.GetById(id);

        public void Add(Livro livro) => _repository.Add(livro);

        public void Update(int id, Livro livro)
        {
            var livroExistente = _repository.GetById(id);
            if (livroExistente == null) return;

            livro.Id = id;
            _repository.Update(livro);
        }

        public void Delete(int id) => _repository.Delete(id);
    }
}
