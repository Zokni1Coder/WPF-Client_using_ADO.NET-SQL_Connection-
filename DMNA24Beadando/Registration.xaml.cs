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
using MySql.Data.MySqlClient;

namespace DMNA24Beadando
{
    public partial class Registration : Window
    {
        static string connString = "server=127.0.0.1; user=root; database=formula1; password=";
        static MySqlConnection con = new MySqlConnection(connString);
        static string adminKod = "LH44";
        public Registration()
        {
            InitializeComponent();
        }

        private void foglalt(string nev)
        {
            MySqlCommand cmd = new MySqlCommand("select * from userok", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == nev)
                {
                    throw new userNameFoglalt(nev);
                }
            }
            dr.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into userok values(@userName,@password,@admin)", con);
                foglalt(nev.Text);
                cmd.Parameters.AddWithValue("@userName", nev.Text);
                cmd.Parameters.AddWithValue("@password", kod.Password);
                if (admine.Text != adminKod && admine.Text != string.Empty)
                {
                    throw new adminException();
                }
                cmd.Parameters.AddWithValue("@admin", admine.Text == adminKod ? "1" : "0");

                if (kod.Password != kodujra.Password)
                {
                    throw new nemAzonosKodException();
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Login lg = new Login();
                    this.Hide();
                    lg.Show();
                }
                else
                {
                    MessageBox.Show("Unsuccessful registration!");
                    nev.Text = string.Empty;
                    kod.Password = string.Empty;
                    admine.Text = string.Empty;
                    kodujra.Password = string.Empty;
                }
            }
            catch (userNameFoglalt x)
            {
                MessageBox.Show($"The name \"{x.nev}\" is already in use!");
                nev.Text = string.Empty;
            }
            catch (nemAzonosKodException)
            {
                MessageBox.Show("The two password must be the same!");
                kod.Password = string.Empty;
                kodujra.Password = string.Empty;
            }
            catch (adminException)
            {
                MessageBox.Show("Are you an admin? The password for validation is incorrect!");
                admine.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
