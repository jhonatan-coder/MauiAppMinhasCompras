using SQLite;

namespace MauiAppMinhasCompras.Models
{

    public class Produto
    {
        string _descricao;
        double _preco;
        double _quantidade;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => _descricao; 
            set 
            {
                if (value == null)
                {
                    throw new Exception("Porfavor, preencha a descrição.");
                }

                _descricao = value;
            } 
        }

        public double Preco { get; set; }
        public double Quantidade { get; set; }

        public double Total
        {
            get => Quantidade * Preco;
        }
    }
}
