using AcaoSolidariaAppA.Models;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.Usuarios
{
    public class UsuarioService
    {
        private const string apiUrlBase = "http://localhost:7687/Usuario";

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            Request request = new Request();
            string urlComplementar = "/Registrar";
            u.IdUsuario = await request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            Request request = new Request();
            string urlComplementar = "/Autenticar";
            u = await request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }
    }
}
