
using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Controllers;
using FilmesTorloni.WebAPI.Models;

namespace Filmes.WebAPI.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly FilmeContext _context;
    private object Criptografia;

    public UsuarioRepository(FilmeContext context)
    {
        _context = context;
    }

    public Usuario BuscarPorEmailESenha(string email, string senha)
    {
        try
        {
            Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;

            if(usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHask(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }
            }
            return null!;
        }
        catch(Exception)
        {
            throw;
        }
    }

    public Usuario BuscarPorEmailESenha(object value1, object value2)
    {
        throw new NotImplementedException();
    }

    public Usuario BuscarPorId(Guid id)
    {
        try
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id.ToString())!;
            if(usuarioBuscado != null)
            {
                return usuarioBuscado;
            }
            return null!;
        }
        catch
        {
            throw;
        }
    }

    public void Cadastrar(Usuario novoUsuario)
    {
        try{
            novoUsuario.IdUsuario = Guid.NewGuid().ToString();
            novoUsuario.Senha = BCrypt.Net.BCrypt.HashPassword(novoUsuario.Senha);

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
        }
        catch(Exception)
        {
            throw;
        }
    }
}
