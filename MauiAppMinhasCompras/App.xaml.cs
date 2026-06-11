using MauiAppMinhasCompras.Views;
using MauiAppMinhasCompras.Helpers;
using System.Diagnostics;
namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db; /* Variável estática para armazenar a instância do banco de dados.
                                          Isso garante que a mesma instância seja usada em toda a aplicação,
                                          evitando múltiplas conexões desnecessárias ao banco de dados.*/

        /*Propriedade estática para acessar a instância do banco de dados.
        Ela verifica se a instância já foi criada; se não, ela cria uma nova instância usando
        o caminho do banco de dados definido.*/
        public static SQLiteDatabaseHelper Db 
        {
            get
            {
                if (_db == null)
                {
                    // path ira armazenar o caminho que o banco de dados será criado.
                    //GetFolderPath pega informações de uma pasta/caminho específico.
                    //SpecialFolder.LocalApplicationData é o diretório que ira conter os arquivos da minha aplicação
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "banco_sqlite_compras.db32"
                        );

                    // Cria uma nova instância do banco de dados usando o caminho definido.
                    _db = new SQLiteDatabaseHelper(path);

                }
               return _db;
            }
        }

        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            var window = new Window(new AppShell());

            window.Width = DeviceInfo.Platform switch
            {
                var p when p == DevicePlatform.iOS => 375,
                var p when p == DevicePlatform.Android => 360,
                _ => 1280
            };

            window.Height = DeviceInfo.Platform switch
            {
                var p when p == DevicePlatform.iOS => 667,
                var p when p == DevicePlatform.Android => 640,
                _ => 720
            };


            return window;
        }
    }
}