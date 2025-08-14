using LivrosAPI.Data;
using LivrosAPI.DTO;
using LivrosAPI.Models;

namespace LivrosAPI.Repository
{
    public class LivroRepository: ILivroRepository
    {
        private readonly AppDbContext _ctx;

        public LivroRepository(AppDbContext ctx) 
        { 
            _ctx = ctx;
        }

        public IEnumerable<Livro> GetAll() => _ctx.Livros.ToList();
        public Livro GetById(int id) => _ctx.Livros.Find(id);


        public void Add(Livro livro) 
        {
            _ctx.Livros.Add(livro);
            _ctx.SaveChanges();
        }

        public void Update(Livro livro)
        {
            var livroExistente = _ctx.Livros.Find(livro.Id);
            if (livroExistente == null) return;

            _ctx.Entry(livroExistente).CurrentValues.SetValues(livro);
            _ctx.SaveChanges();
        }


        public void Delete(int id) 
        {
            var livro = _ctx.Livros.Find(id);
            if (livro != null) 
            { 
                _ctx.Livros.Remove(livro);
                _ctx.SaveChanges();
            }
        }

        public void AddNovoLivro(LivroDTO dto) 
        {
            var novoLivro = new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Genero = dto.Genero,
                Ano = dto.Ano,
            };

            _ctx.Livros.Add(novoLivro);
            _ctx.SaveChanges();
            
        }
    }
}
