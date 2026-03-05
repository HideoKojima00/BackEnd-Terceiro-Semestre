using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Controllers
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorEmailESenha(object value1, object value2);
    }
}