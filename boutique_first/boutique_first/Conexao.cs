using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace boutique_first
{
    class Conexao
    {
        String connString = "Host=localhost;Database=db_boutique;Username=postgres;Password=1234;Persist Security Info=True";
        NpgsqlConnection conn = new NpgsqlConnection();
    
        // construtor
        public Conexao()
        {
            conn.ConnectionString = connString;
        }
        
        // metodo para conectar com o bd
        public NpgsqlConnection Conectar()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        // metodo para desconectar
        public void Desconectar()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
