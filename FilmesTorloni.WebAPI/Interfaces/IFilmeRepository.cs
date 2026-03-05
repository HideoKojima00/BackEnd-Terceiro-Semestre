using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Interfaces;

public interface IFilmeRepository
{
    void Cadastrar(Filme NovoFilme);
    void AtualizarIdCorpo(Filme FilmeAtualizado);
    void AtualizarIdUrl(Guid id, Filme FilmeAtualizado);
    List<Filme> Listar();
    void Deletar(Guid id);
    Filme BuscarPorId(Guid id);
}
