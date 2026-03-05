using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;

namespace Filmes.WebAPI.Repository;

public class FilmeRepository : IFilmeRepository
{
    private readonly FilmeContext _context;
    public FilmeRepository(FilmeContext context)
    {
        _context = context;
    }

    public void AtualizarIdCorpo(Filme FilmeAtualizado)
    {
        try
        {
            Filme FilmeBuscado = _context.Filmes.Find(FilmeAtualizado.IdFilme)!; // Busca o filme pelo ID
            if (FilmeBuscado != null)
            {
                FilmeBuscado.Titulo = FilmeAtualizado.Titulo;
                FilmeBuscado.IdGenero = FilmeAtualizado.IdGenero;
            }
            _context.Filmes.Update(FilmeBuscado!); // Atualiza o filme no contexto
            _context.SaveChanges(); // Salva as alterações no banco de dados

        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AtualizarIdUrl(Guid id, Filme FilmeAtualizado)
    {
        try
        {
            Filme FilmeBuscado = _context.Filmes.Find(id.ToString())!; // Busca o filme pelo ID

            if (FilmeBuscado != null)
            {
                FilmeBuscado.Titulo = FilmeAtualizado.Titulo;
                FilmeBuscado.IdGenero = FilmeAtualizado.IdGenero;
            }
            _context.Filmes.Update(FilmeBuscado!); // Atualiza o filme no contexto
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Filme BuscarPorId(Guid id)
    {
        try
        {
            Filme filme = _context.Filmes.Find(id.ToString())!;
            return filme;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Cadastrar(Filme NovoFilme)
    {
        try
        {

            NovoFilme.IdFilme = Guid.NewGuid().ToString();

            _context.Filmes.Add(NovoFilme);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        try
        {
            Filme FilmeBuscado = _context.Filmes.Find(id.ToString())!; // Busca o filme pelo ID
            if (FilmeBuscado != null)
            {
                _context.Filmes.Remove(FilmeBuscado); // Remove o filme do contexto
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Filme> Listar()
    {
        try
        {
            List<Filme> listaFilmes = _context.Filmes.ToList();
            return listaFilmes;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
