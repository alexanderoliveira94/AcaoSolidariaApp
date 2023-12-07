using AcaoSolidariaAppA.Models;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.Usuarios
{
    public class UsuarioService
    {
        //private const string apiUrlBase = ("http://localhost:7687/Usuario"); //TESTE GERAL EM REDE LOCAL FORA DO EMULADOR
        private const string apiUrlBase = ("http://10.0.2.2:7687/Usuario"); //PARA APENAS TESTAR NO ANDROID
                      
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

        public async Task AtualizarUsuarioAsync(int id, Usuario usuarioAtualizacao)
        {
            Request request = new Request();
            string urlComplementar = $"/atualizarUsuario/{id}";
            await request.PutAsync(apiUrlBase + urlComplementar, usuarioAtualizacao, string.Empty);
        }
    }
}
