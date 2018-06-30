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
    /// Lógica interna para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        // inicialização de var
        String nome_cliente;
        String nome_mae;
        String nascimento;
        String cpf;
        String rg;
        String observacoes;
        String tel1;
        String ttel1;
        String tel2;
        String ttel2;
        String lagradouro;
        String num_casa;
        String complemento;
        String cep;
        String bairro;
        String cidade;
        String estado;

        Conexao conn = new Conexao();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 princ = new Window1();
            //princ.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nome_cliente = TxbNomeCliente.Text;
            nome_mae = TxbNomeMae.Text;
            nascimento = DataNasc.Text;
            cpf = TxbCpf.Text;
            rg = TxbRG.Text;
            observacoes = TxtObservacoes.Text;
            ttel1 = TxbTipoTel1.Text;
            tel1 = TxbTelefone1.Text;
            ttel2 = TxbTipoTel2.Text;
            tel2 = TxbTelefone2.Text;
            lagradouro = TxbLagradouro.Text;
            num_casa = TxbNumeroCasa.Text;
            complemento = TxbComplemento.Text;
            cep = TxbCEP.Text;
            bairro = TxbBairro.Text;
            cidade = TxbCidade.Text;
            estado = TxbEstado.Text;
            
            AcoesBanco cad_cliente = new AcoesBanco();

            //CADASTRO DE CLIENTE RETORNA ID

            int id_cliente = cad_cliente.CadastrarCliente(nome_cliente, nome_mae, nascimento, observacoes, cpf, rg);
            MessageBox.Show("Cadastro de Cliente realizado: " + id_cliente);

            cad_cliente.CadastrarTelefone(tel1, ttel1, id_cliente);
            if (tel2 != null)
            {
                cad_cliente.CadastrarTelefone(tel2, ttel2, id_cliente);
            }
            cad_cliente.CadastrarEndereco(id_cliente, lagradouro, num_casa, complemento, cep, bairro, cidade, estado);

            MessageBox.Show(cad_cliente.mensagem);
            


        }

        private void TxbNomeCliente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
