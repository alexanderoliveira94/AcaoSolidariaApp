using AcaoSolidariaApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.Voluntarios
{
    public class VoluntarioService : Request
    {
        //private readonly Request _request;
        //private const string apiUrlBase = "http://localhost:5165/api/"; // Substitua pela URL base da sua API

        //public VoluntarioService()
        //{
        //    _request = new Request();
        //}

        //public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        //{
        //    //Registrar: Rota para o método na API que registrar o usuário
        //    string urlComplementar = "/Registrar";
        //    u.IdUsuario = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
        //    return u;
        //}
        //public async Task<Voluntario> PostAutenticarUsuarioAsync(Usuario u)
        //{
        //    //Autenticar: Rota para o método na API que autentica com login e senha
        //    string urlComplementar = "/Autenticar";
        //    u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
        //    return u;
        //}

        //public async Task<int> PutAtualizarLocalizacaoAsync(Usuario u)
        //{
        //    string urlComplementar = "/AtualizarLocalizacao";
        //    var result = await _request.PutAsync(apiUrlBase + urlComplementar, u, _token);
        //    return result;
        //}

        //public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        //{
        //    string urlComplementar = string.Format("{0}", "/GetAll");
        //    ObservableCollection<Models.Usuario> listaUsuarios = await
        //    _request.GetAsync<ObservableCollection<Models.Usuario>>(apiUrlBase + urlComplementar, _token);
        //    return listaUsuarios;
        //}



    }
}
