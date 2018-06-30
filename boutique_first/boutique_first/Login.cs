using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace boutique_first
{
    class Login
    {
        Conexao conexao = new Conexao();
        NpgsqlCommand cmd;
        public String mensagem;


        // Login tenta conexão

        public Login(String usuario, String senha)
        {
            try
            {   //select do postgres
                var conn = conexao.Conectar();
                cmd = new NpgsqlCommand(
                    "SELECT * FROM tb_login where usuario = '" + usuario.ToLower() + "' and senha = '" + senha + "'", conn);

            }
            catch (NpgsqlException e)
            {
                this.mensagem += "Erro ao efetuar login: " + e;
            }
        }

        public Boolean Logar()
        {
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows is true)
            {
                this.mensagem += "Login efetuado com sucesso!";
                return true;
            }

            return false;

        }

        public Boolean CadastrarCliente(String nome, String mae, String cpf)
        {
            NpgsqlConnection conn = conexao.Conectar();
            //var conn = conexao.Conectar();
            try
            {
                cmd = new NpgsqlCommand(
                    "INSERT INTO tb_cliente nome_cliente, nome_mae, cpf" +
                    "values ('" + nome + "', '" + mae + "', '" + cpf + "')", conn);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("INSERT PARA CLIENTE NÃO FOI FEITO");
            }

            return false;
        }
    }
}
