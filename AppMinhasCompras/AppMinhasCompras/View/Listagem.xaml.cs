using AppMinhasCompras.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMinhasCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        public Listagem()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new NovoProduto());
            }catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
            
            
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
            
        {
            ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

            Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.GetALL();
                foreach (Produto item in temp)
                {
                    lista_produtos.Add(item);
                }
                ref_carregando.IsRefreshing = false;
            });
            lst_produtos.ItemsSource = lista_produtos;
            
     
        }
    }
}