using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class Gastos : ContentPage
    {
        public Gastos()
        {
            InitializeComponent();
            CarregarGastos();
        }

        private async void CarregarGastos() //Buscar os produtos do banco de dados
        {
            List<Produto> produtos = await App.Db.GetAll();

            
            var relatorio = produtos
                .GroupBy(p => p.Categoria) // Soma os preços da categoria
                .Select(g => new
                {
                    Categoria = g.Key,
                    TotalGasto = g.Sum(p => p.Total) //Soma os preços de cada categoria
                })
                .ToList();

            lst_gastos.ItemsSource = relatorio;
        }
    }
}