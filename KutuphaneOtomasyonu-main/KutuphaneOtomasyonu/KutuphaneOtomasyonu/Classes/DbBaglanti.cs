 using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using System.Windows.Controls;

namespace KutuphaneOtomasyonu.Classes
{
    public class DbBaglanti
    {
        string ConnectionString = "server=172.21.54.3;userid=multimode;password=Multimod.16;database=multimode;";
        MySqlConnection con;

        Anasayfa anasayfa = new Anasayfa();

        public void OpenConnection()
        {
            con = new MySqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con = new MySqlConnection(ConnectionString);
            con.Close();
        }

        public void ExecuteQueries(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, con);
            cmd.ExecuteNonQuery();
        }

        public void Update(string Query)
        {
            MySqlCommand update = new MySqlCommand(Query, con);
            MySqlDataReader updatereader = update.ExecuteReader();
        }

        public void Delete(string Query)
        {
            MySqlCommand delete = new MySqlCommand(Query, con);
            MySqlDataReader deletereader = delete.ExecuteReader();
        }

        public MySqlDataReader DataReader(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
            
        }

        public int LastInsertedId()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", con);
            int last = int.Parse(cmd.ExecuteScalar().ToString());
            return last;                
        }

        public void ShowDataInGridView(string Query, DataGrid dvg)
        {
            MySqlDataAdapter dr = new MySqlDataAdapter(Query, ConnectionString);
            DataTable table = new DataTable();
            dr.Fill(table);
            dvg.ItemsSource = table.DefaultView;
        }

        public void Filter_Search(string Query, DataGrid dvg, ComboBox cmb)
        {
            if (cmb.SelectedIndex == 1)
            {
                DataTable tbl = new DataTable();

                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
            else if (cmb.SelectedIndex == 2)
            {
                DataTable tbl = new DataTable();

                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
            else if (cmb.SelectedIndex == 3)
            {
                DataTable tbl = new DataTable();


                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
            else if (cmb.SelectedIndex == 4)
            {
                DataTable tbl = new DataTable();


                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
            else if (cmb.SelectedIndex == 5)
            {
                DataTable tbl = new DataTable();


                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
            else if (cmb.SelectedIndex == 6)
            {
                DataTable tbl = new DataTable();


                MySqlDataAdapter ara = new MySqlDataAdapter(Query, ConnectionString);
                ara.Fill(tbl);

                dvg.ItemsSource = (System.Collections.IEnumerable)tbl;
            }
        }
    }
}
