using MauiAppMinhasCompras.Models;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (string.IsNullOrEmpty(txt_descricao.Text))
			{
				await DisplayAlertAsync("Erro", "Por favor, insira a descrição do produto!", "OK");
				return;
			}
			double preco = Convert.ToDouble(txt_preco.Text);
			if (preco <= 0)
			{
				await DisplayAlertAsync("Erro","Por favor, insira um preço válido","OK");
				return;
			}
			double quantidade = Convert.ToDouble(txt_quantidade.Text);
			if (quantidade <= 0)
			{
				await DisplayAlertAsync("Erro", "Por favor, adicione uma quantidade válida","OK");
				return;
			}
			Produto p = new Produto //instanciando um objeto do tipo Produto
            {
                //Atribuindo os valores dos campos do formulário para as propriedades do objeto

                Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};
			await App.Db.Insert(p);//chamando o método Insert do banco de daods para inserir o registro do produto
            await DisplayAlertAsync("Sucesso!","Registro inserido","OK");
			await Shell.Current.GoToAsync(nameof(ListaProduto));
			/*txt_descricao.Text = string.Empty;
			txt_quantidade.Text = string.Empty;
			txt_preco.Text = string.Empty;*/
			
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }
}