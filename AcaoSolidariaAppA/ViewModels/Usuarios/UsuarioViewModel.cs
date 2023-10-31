using AcaoSolidariaAppA.Models;
using AcaoSolidariaAppA.Views;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcaoSolidariaAppA.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        private ICommand _criarUsuarioCommand;
        private string nome;
        private string email;
        private string senha;
        private string descricao;

        public ICommand CriarUsuarioCommand =>
            _criarUsuarioCommand ?? (_criarUsuarioCommand = new Command(async () => await CriarUsuario(nome, email, senha, descricao)));

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                descricao = value;
                OnPropertyChanged();
            }
        }

        private async Task<bool> CriarUsuario(string nome, string email, string senha, string descricao)
        {
            try
            {
                Usuario novoUsuario = new Usuario // Preencha com os dados do novo usu�rio
                {
                    Nome = nome,
                    Email = email,
                    SenhaUsuario = senha,
                    DescricaoHabilidades = descricao
                };

                using var httpClient = new HttpClient();
                var json = JsonSerializer.Serialize(novoUsuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var response = await httpClient.PostAsync("http://localhost:8080/api/Usuario/criarUsuario", content);

                if (response.IsSuccessStatusCode)
                {
                    // Usu�rio criado com sucesso
                    await App.Current.MainPage.Navigation.PushAsync(new BoasVindasView());
                    return true;
                }
                else
                {
                    // Lidar com falhas de cria��o do usu�rio
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                // Lidar com exce��es relacionadas � solicita��o HTTP
                Console.WriteLine($"Erro na solicita��o HTTP: {e.Message}");
                return false;
            }
            catch (JsonException je)
            {
                // Lidar com erros de serializa��o JSON
                Console.WriteLine($"Erro de serializa��o JSON: {je.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Lidar com outras exce��es n�o especificadas
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return false;
            }
        }

    }
}
