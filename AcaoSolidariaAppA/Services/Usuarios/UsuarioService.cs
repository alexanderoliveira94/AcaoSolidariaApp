using AcaoSolidariaAppA.Models;
using AcaoSolidariaAppA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Services.Usuarios
{
    public class UsuarioService : Request
    {
    
        private readonly Request _request;
        private const string apiUrlBase = "http://localhost:8080/api/Usuario/criarUsuario";
        //xyz --> Site da sua API

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            //Registrar: Rota para o método na API que registrar o usuário
            string urlComplementar = "/criarUsuario";
            u.IdUsuario = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }
      

    }
}
