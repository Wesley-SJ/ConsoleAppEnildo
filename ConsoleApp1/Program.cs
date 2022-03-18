using System;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do usuário");
            string vnome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do usuário");
            string vcargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do usuário");
            string vdata = Console.ReadLine();

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=db_exemplo;uid=root;pwd=12345678");
            conexao.Open();

            string strinsereUsu = string.Format("INSERT INTO tb_usuario(nomeUsu,cargo,DataNasc) " +
                                                 "VALUES('{0}', '{1}', '{2}');", vnome, vcargo, vdata);

            MySqlCommand comandoApagar = new MySqlCommand(strinsereUsu, conexao);
            comandoApagar.ExecuteNonQuery();

            string selectUsuario = "SELECT * FROM tb_usuario;";
            MySqlCommand cmd = new MySqlCommand(selectUsuario, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo {2}, Data {3}", reader["idUsu"], reader["nomeUsu"], reader["cargo"], reader["DataNasc"]);
            }
            Console.ReadLine();
        }
    }
}
