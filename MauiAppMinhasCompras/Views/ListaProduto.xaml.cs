using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{

	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

	public ListaProduto()
	{
		InitializeComponent();
		lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
		base.OnAppearing();

		lista.Clear();//Limpa a lista antes de recarregar, desta forma não duplica os itens

		List<Produto> tmp = await App.Db.GetAll();

		tmp.ForEach(p => lista.Add(p));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Shell.Current.GoToAsync(nameof(NovoProduto));
		
		}
		catch (Exception ex)
		{
			DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			string q = e.NewTextValue;
			lista.Clear();
			List<Produto> tmp = await App.Db.Search(q);
			tmp.ForEach(p => lista.Add(p));

		}
		catch (Exception ex)
		{
            await DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			double soma = lista.Sum(p => p.Total);

			string msg = $"O valor total dos produtos é {soma:C}";
			await DisplayAlertAsync("Total", msg, "OK");

		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }

    private async void SwipeItem_Clicked(object sender, EventArgs e)
    {
		try
		{

			if (sender is SwipeItem item && item.BindingContext is Produto p)
			{
                bool confirm = await DisplayAlertAsync("Tem certeza?", "Remover produto?", "Sim", "Não");

                if (confirm)
                {
                    await App.Db.Delete(p.Id);// Exclui o item selecionado la do banco de dados
                    lista.Remove(p); // Exclui do observableCollection
                }
            }			

		}
        catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }

    private async void SwipeItem_Clicked_1(object sender, EventArgs e)
    {
		try
		{

			if (sender is SwipeItem item && item.BindingContext is Produto produtoSelecionado)
			{
				var parametros = new Dictionary<string, object>
				{
					{"ProdutoParaEditar", produtoSelecionado }
				};
				await Shell.Current.GoToAsync(nameof(EditarProduto), parametros);
			}			
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
		}
    }
}