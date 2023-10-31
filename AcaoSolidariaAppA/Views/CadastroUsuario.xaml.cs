using AcaoSolidariaApp.Models;
using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Views
{
    public partial class CadastroUsuario : ContentPage
    {
        //private readonly HttpClient _httpClient;
        //private readonly string _baseAddress = "http://192.168.0.123:5165/api/Usuario";

        public CadastroUsuario()
        {
            InitializeComponent();
            //_httpClient = new HttpClient();
        }

        //private async void RegistrarUsuarioBtn_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Console.WriteLine("Iniciando a criação do usuário.");

        //        if (string.IsNullOrWhiteSpace(NomeEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) ||
        //            string.IsNullOrWhiteSpace(DescricaoEntry.Text) || string.IsNullOrWhiteSpace(SenhaEntry.Text) ||
        //            string.IsNullOrWhiteSpace(ConfirmarSenhaEntry.Text))
        //        {
        //            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
        //            return;
        //        }

        //        if (SenhaEntry.Text != ConfirmarSenhaEntry.Text)
        //        {
        //            await DisplayAlert("Erro", "As senhas não correspondem.", "OK");
        //            return;
        //        }

        //        var usuario = new Usuario
        //        {
        //            Nome = NomeEntry.Text,
        //            Email = EmailEntry.Text,
        //            SenhaUsuario = SenhaEntry.Text,
        //            DataRegistro = DateTime.Now,
        //            DescricaoHabilidades = DescricaoEntry.Text,
        //            AvaliacaoMedia = 0
        //        };
        //        var json = JsonSerializer.Serialize(usuario);
        //        Console.WriteLine($"JSON enviado para a API: {json}");

        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PostAsync($"{_baseAddress}/criarUsuario", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("Usuário criado com sucesso.");
        //            await DisplayAlert("Sucesso", "Usuário criado com sucesso.", "OK");
        //            await Navigation.PushAsync(new BoasVindasView());
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Erro ao enviar dados: {response.ReasonPhrase}");
        //            throw new HttpRequestException($"Erro ao enviar dados: {response.ReasonPhrase}");
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.WriteLine($"Erro ao enviar dados: {ex.Message}");
        //        await DisplayAlert("Erro", $"Erro ao enviar dados: {ex.Message}", "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        //        await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
        //    }
        //}
    }
}
