using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace boutique_first
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conexao conn = new Conexao();
            conn.Desconectar();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCadastrarCliente(object sender, RoutedEventArgs e)
        {
            Window2 cad_cliente = new Window2();
            this.Hide();
            cad_cliente.ShowDialog();
        }

        private void BtnListarClientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCarneEmAberto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegistrarCompra_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
