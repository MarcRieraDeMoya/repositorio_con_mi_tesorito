using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEquips.DATA_ACCES
{
    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using WpfEquips.MODEL;

    public class DAOImpMySQL : IDAO<Equips>
    {
        private MySQLConnection connexio;

        public DAOImpMySQL(MySQLConnection connexio)
        {
            this.connexio = connexio;
        }

        public bool Add(Equips ObjCreate)
        {
            bool fet = false;

            if (connexio.Connect())
            {
                string query = "INSERT INTO clubs (club_name, abv, hex_code, logo_link) VALUES (@nom, @abv, @press, @logo)";
                MySqlCommand cmd = new MySqlCommand(query, connexio.GetConnection());
                cmd.Parameters.AddWithValue("@nom", ObjCreate.Nom);
                cmd.Parameters.AddWithValue("@abv", ObjCreate.Abv);
                cmd.Parameters.AddWithValue("@press", ObjCreate.HexPress);
                cmd.Parameters.AddWithValue("@logo", ObjCreate.ImgClub);

                fet = cmd.ExecuteNonQuery() > 0;
                connexio.Disconnect();
            }

            return fet;
        }

        public bool Delete(string abreviatura)
        {
            bool fet = false;

            if (connexio.Connect())
            {
                string query = "DELETE FROM clubs WHERE abv = @abv";
                MySqlCommand cmd = new MySqlCommand(query, connexio.GetConnection());
                cmd.Parameters.AddWithValue("@abv", abreviatura);

                fet = cmd.ExecuteNonQuery() > 0;
                connexio.Disconnect();
            }

            return fet;
        }

        public List<Equips> GetAll()
        {
            List<Equips> llista = new List<Equips>();

            if (connexio.Connect())
            {
                string query = "SELECT * FROM clubs";
                MySqlCommand cmd = new MySqlCommand(query, connexio.GetConnection());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string abv = reader["abv"].ToString();
                    string nom = reader["club_name"].ToString();
                    string press = reader["hex_code"].ToString();
                    string logo = reader["logo_link"].ToString();

                    llista.Add(new Equips(nom, abv, press, logo));
                }

                reader.Close();
                connexio.Disconnect();
            }

            return llista;
        }

        public Equips GetTeam(string abreviatura)
        {
            Equips equipTrobat = null;

            if (connexio.Connect())
            {
                string query = "SELECT * FROM clubs WHERE abv = @abv";
                MySqlCommand cmd = new MySqlCommand(query, connexio.GetConnection());
                cmd.Parameters.AddWithValue("@abv", abreviatura);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string nom = reader["club_name"].ToString();
                    string press = reader["hex_code"].ToString();
                    string logo = reader["logo_link"].ToString();

                    equipTrobat = new Equips(nom, abreviatura, press, logo);
                }

                reader.Close();
                connexio.Disconnect();
            }

            return equipTrobat;
        }

        public bool Update(string abAntic, Equips equipNou)
        {
            bool fet = false;

            if (connexio.Connect())
            {
                string query = @"UPDATE clubs 
                         SET abv = @nouAbv, club_name = @nom, hex_code = @pressupost, logo_link = @logo 
                         WHERE abv = @anticAbv";

                MySqlCommand cmd = new MySqlCommand(query, connexio.GetConnection());
                cmd.Parameters.AddWithValue("@nouAbv", equipNou.Abv);
                cmd.Parameters.AddWithValue("@nom", equipNou.Nom);
                cmd.Parameters.AddWithValue("@pressupost", equipNou.HexPress);
                cmd.Parameters.AddWithValue("@logo", equipNou.ImgClub);
                cmd.Parameters.AddWithValue("@anticAbv", abAntic);

                fet = cmd.ExecuteNonQuery() > 0;
                connexio.Disconnect();
            }

            return fet;
        }




    }

}
