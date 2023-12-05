using System;
using AcaoSolidariaAppA.Views.Usuarios;
using Microsoft.Maui.Controls;

namespace AcaoSolidariaAppA.Views;

public partial class BoasVindasView : ContentPage
{
	public BoasVindasView()
	{
        InitializeComponent();
	}
    private async void EntrarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AutenticacaoUsuario());
    }

    private void EsqueceuSenhaBtn_Clicked(object sender, EventArgs e)
    {
        // Adicione a lógica para lidar com o botão "Esqueceu a senha" aqui
    }

    private async void RegistrarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EscolhaOngVoluntario());
    }
}