using LivrosAPI.Data;
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
            _ctx.Livros.Update(livro);
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
    }
}
