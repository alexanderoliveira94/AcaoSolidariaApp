using AcaoSolidariaAppA.Models;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.Ong
{
    public class OngService
    {
        private const string apiUrlBase = "http://10.0.2.2:7687/Ong";

        public async Task<ONG> PostRegistrarOngAsync(ONG u)
        {
            Request request = new Request();
            string urlComplementar = "/Registrar";
            u.IdOng = await request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

        public async Task<ONG> PostAutenticarOngAsync(ONG u)
        {
            Request request = new Request();
            string urlComplementar = "/autenticarOng";
            u = await request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }

        public async Task CriarOngAsync(ONG u)
        {
            Request request = new Request();
            string urlComplementar = "/registrarOng";
            await request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
        }

        public async Task AtualizarOngAsync(int id, Usuario usuarioAtualizacao)
        {
            Request request = new Request();
            string urlComplementar = $"/atualizarOng/{id}";
            await request.PutAsync(apiUrlBase + urlComplementar, usuarioAtualizacao, string.Empty);
        }
    }
}
