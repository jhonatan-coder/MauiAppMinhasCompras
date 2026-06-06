using MauiAppMinhasCompras.Views;

namespace MauiAppMinhasCompras
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListaProduto), typeof(ListaProduto));
            Routing.RegisterRoute(nameof(EditarProduto), typeof(EditarProduto));
            Routing.RegisterRoute(nameof(NovoProduto), typeof(NovoProduto));
        }
    }
}
