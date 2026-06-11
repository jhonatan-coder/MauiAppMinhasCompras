using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage, IQueryAttributable
{
	private Produto produtoAnexado;
	public EditarProduto()
	{
		InitializeComponent();
	}

	//
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue("ProdutoParaEditar", out var produtoObj) && produtoObj is Produto prod)
		{
			produtoAnexado = prod;
			txt_descricao.Text = prod.Descricao;
			txt_quantidade.Text = prod.Quantidade.ToString();
			txt_preco.Text = prod.Preco.ToString();
		}
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (produtoAnexado != null)
			{
				
				Produto p = new Produto
				{
				
					Id = produtoAnexado.Id,
					Descricao = txt_descricao.Text,
					Quantidade = Convert.ToDouble(txt_quantidade.Text),
					Preco = Convert.ToDouble(txt_preco.Text)
				};

				await App.Db.Update(p);
				await DisplayAlertAsync("Sucesso!","Registro Atualizado","OK");
				await Shell.Current.GoToAsync("..");
			}
			else
			{
				await DisplayAlertAsync("Erro", "Os dados do produto não foram carregados nesta página", "OK");
			}
		

		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }
}