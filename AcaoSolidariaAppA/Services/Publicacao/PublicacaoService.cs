using AcaoSolidariaApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.PublicacaoService
{
    public class PublicacaoService
    {
        private const string apiUrlBase = "http://10.0.2.2:7687/Publicacao";

        public async Task CriarPublicacaoAsync(Publicacao publicacao)
        {
            Request request = new Request();
            string urlComplementar = "/criarPublicacao";

            await request.PostAsync(apiUrlBase + urlComplementar, publicacao, string.Empty);
        }

        public async Task<List<Publicacao>> ListarPublicacoesAsync()
        {
            Request request = new Request();
            string urlComplementar = "/listarPublicacoes";

            return await request.GetAsync<List<Publicacao>>(apiUrlBase + urlComplementar, string.Empty);
        }


        public async Task<ObservableCollection<Publicacao>> ListarPublicacoes2Async()
        {
            Request request = new Request();
            string urlComplementar = "/listarPublicacoes";

            return await request.GetAsync<ObservableCollection<Publicacao>>(apiUrlBase + urlComplementar, string.Empty);
        }

        public async Task<Publicacao> ObterPublicacaoAsync(int idPublicacao)
        {
            Request request = new Request();
            string urlComplementar = $"/obterPublicacao/{idPublicacao}";

            return await request.GetAsync<Publicacao>(apiUrlBase + urlComplementar, string.Empty);
        }

        public async Task CandidatarPublicacaoAsync(int idPublicacao)
        {
            Request request = new Request();
            string urlComplementar = $"/candidatarProjeto/{idPublicacao}";

            await request.PostAsync<Task>(apiUrlBase + urlComplementar, null, string.Empty);
        }

        // Adicione os métodos abaixo conforme necessário
        public async Task AtualizarPublicacaoAsync(int idPublicacao, Publicacao publicacaoAtualizacao)
        {
            Request request = new Request();
            string urlComplementar = $"/atualizarPublicacao/{idPublicacao}";

            await request.PutAsync(apiUrlBase + urlComplementar, publicacaoAtualizacao, string.Empty);
        }

        public async Task ExcluirPublicacaoAsync(int idPublicacao)
        {
            Request request = new Request();
            string urlComplementar = $"/excluirPublicacao/{idPublicacao}";

            await request.DeleteAsync(apiUrlBase + urlComplementar, string.Empty);
        }
    }
}
