using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Implan
{
    class BD
    {
        NpgsqlConnection cnn;

        public NpgsqlConnection ini
        {
            get
            {
                string servidor = "localhost";
                string porta = "5432";
                string usuario = "postgres";
                string pwd = "ifsp";
                string bd = "implan";
                string conexao;

                conexao = string.Format(
                    "Server={0};Port={1};User Id={2};Password={3};Database={4};Pooling=false;",
                    servidor, porta, usuario, pwd, bd);
                cnn = new NpgsqlConnection(conexao);

                return cnn;
            }
        }
    }
}