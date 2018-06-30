using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace boutique_first
{
    class AcoesBanco
    {
        public AcoesBanco() { }
        
        Conexao conexao = new Conexao();
        NpgsqlCommand cmd;
        public String mensagem;

        public Boolean Logar(String usuario, String senha)
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

            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows is true)
            {
                this.mensagem += "Login efetuado com sucesso!";
                conexao.Desconectar();
                return true;
            }

            return false;

        }

        // CADASTRO DE CLIENTE
        public int CadastrarCliente(String nome_cliente, String nome_mae, String data_nascimento, String observacoes, String cpf, String rg)
        {
            conexao.Desconectar();
            var conn = conexao.Conectar();
            String campos = "nome_cliente";
            String valores = "'" + nome_cliente + "'";
            if (nome_mae != "")
            {
                campos += ", nome_mae";
                valores += ", '" + nome_mae + "'";
            }
            if (data_nascimento != null)
            {
                campos += ", data_nascimento";
                valores += ", '" + data_nascimento + "'";
            }
            if (observacoes != "")
            {
                campos += ", observacoes";
                valores += ", '" + observacoes + "'";
            }
            if (cpf != "")
            {
                campos += ", cpf";
                valores += ", '" + cpf + "'";
            }
            if (rg != "")
            {
                campos += ", rg";
                valores += ", '" + rg + "'";
            }

            String strSql = "INSERT INTO tb_cliente (" + campos + ") " +
                    "values (" + valores + ") RETURNING id_cliente;";

            this.mensagem += "\nCampos: " + campos;
            this.mensagem += "\nvalores: " + valores;
            this.mensagem += "\nString: " + strSql;
            try
            {
                cmd = new NpgsqlCommand(strSql, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch (NpgsqlException e)
            {
                this.mensagem += "Por favor, insira dados válidos! " + e;
            }
            return 0;
        }

        //CADASTRO DE TELEFONE
        public void CadastrarTelefone(String num_tel, String tipo_tel, int id_cliente)
        {
            conexao.Desconectar();
            var conn = conexao.Conectar();
            try
            {
                cmd = new NpgsqlCommand(
                    "INSERT INTO tb_telefone (num_telefone, tipo_telefone, id_cliente) " +
                    "values ('" + num_tel + "', '" + tipo_tel + "', " + id_cliente + ")", conn);
                //NpgsqlDataReader dr = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                this.mensagem += "\nINSERT PARA TELEFONE NÃO FOI FEITO " + e;
            }
            conexao.Desconectar();

        }

        //CADASTRO DE ENDEREÇO
        public void CadastrarEndereco(int id_cliente, String lagradouro, String num_casa, String complemento,
            String cep, String bairro, String cidade, String estado)
        {
            conexao.Desconectar();
            var conn = conexao.Conectar();

            String campos = "lagradouro";
            String valores = "'" + lagradouro + "'";
            if (num_casa != "")
            {
                campos += ", num_casa";
                valores += ", '" + num_casa + "'";
            }
            if (complemento != "")
            {
                campos += ", complemento";
                valores += ", '" + complemento + "'";
            }
            if (cep != "")
            {
                campos += ", cep";
                valores += ", '" + cep + "'";
            }
            if (bairro != "")
            {
                campos += ", bairro";
                valores += ", '" + bairro + "'";
            }
            if (cidade != "")
            {
                campos += ", cidade";
                valores += ", '" + cidade + "'";
            }
            if (estado != "")
            {
                campos += ", estado";
                valores += ", '" + estado + "'";
            }
            

            try
            {
                cmd = new NpgsqlCommand(
                    "INSERT INTO tb_endereco (lagradouro, num_casa, complemento, cep, bairro, cidade, estado, id_cliente)" +
                    "values ('"+lagradouro+"', '"+num_casa+"', '"+complemento+"', '"+cep+"', '"+bairro+"', '"+cidade+"', '"+estado+"', '"+id_cliente+"')", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
            }
            catch (NpgsqlException e)
            {
                this.mensagem += "\nINSERT PARA TELEFONE NÃO FOI FEITO " + e;
            }
            conexao.Desconectar();
        }

    }
}
