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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace boutique_first
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            AcoesBanco login = new AcoesBanco();
            var res = login.Logar(txbUsuario.Text, txbSenha.Text);
            MessageBox.Show(login.mensagem);
            if (res.Equals(true)){
                Window1 window1 = new Window1();
                this.Close();
                window1.Show();
            } 
            
            
        }
    }
}
