using MauiAppMinhasCompras.Models;

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
			Produto p = new Produto //instanciando um objeto do tipo Produto
            {
                //Atribuindo os valores dos campos do formulário para as propriedades do objeto

                Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};
			await App.Db.Insert(p);//chamando o método Insert do banco de daods para inserir o registro do produto
            await DisplayAlertAsync("Sucesso!","Registro inserido","OK");

		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }
}