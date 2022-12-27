using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public static class GlobalDB
    {
        public static string Connection = "server=localhost;user=admin;database=projektBP2;port=3306;password=12345";
        public static MySqlConnection con = new MySqlConnection(Connection);

        // komanda
        public static MySqlCommand cmd;
        public static void NapisiUpit(string upit)
        {
            cmd = new MySqlCommand(upit, con);
        }

        //reader
        public static MySqlDataReader reader;
        public static MySqlDataReader PozoviReadera()
        {
            return reader = cmd.ExecuteReader();
        }

        public static void OtvoriVezu()
        {
            con.Open();
        }

        public static void ZatvoriVezu()
        {
            reader.Close();
            cmd.Dispose();
            con.Close();
        }
    }
}
