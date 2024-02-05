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
using System.Data;
using MySql.Data.MySqlClient;

namespace DMNA24Beadando
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        static string connString = "server=127.0.0.1; user=root; database=formula1; password=";
        static MySqlConnection con = new MySqlConnection(connString);
        public Login()
        {
            InitializeComponent();
            //try
            //{
            //    con.Open();
            //    //MessageBox.Show("Succes");
            //    MySqlCommand cmd = new MySqlCommand("select nev from drivers", con);
            //    MySqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        MessageBox.Show(dr[0].ToString());
            //    }
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("Failed");
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.Show();
        }

        private void nyitas(MainWindow mw)
        {
            this.Hide();
            mw.Show();
        }

        //public class user
        //{
        //    private string nev;
        //    private string kod;
        //    public bool adminE;

        //    public user(string nev, string kod, bool adminE)
        //    {
        //        this.nev = nev;
        //        this.kod = kod;
        //        this.adminE = adminE;
        //    }
        //}

        private void bejelentkezesClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from userok WHERE userName=@nev and password=@pass", con);
                cmd.Parameters.AddWithValue("@nev", felnev.Text);
                cmd.Parameters.AddWithValue("@pass", kod.Password);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    User temp = new User(dr[0].ToString(), dr[1].ToString(), bool.Parse(dr[2].ToString()));
                    //MessageBox.Show(temp.ToString());
                    MainWindow mw = new MainWindow();

                    if (temp.adminE)
                    {
                        nyitas(mw);
                    }
                    else
                    {
                        mw.hozzaAd.IsEnabled = false;
                        mw.torlesGomb.IsEnabled = false;
                        mw.modositGomb.IsEnabled = false;
                        nyitas(mw);
                        MessageBox.Show("Because you are not an admin, you can only list and search!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect User name or Password!");
                    felnev.Text = string.Empty;
                    kod.Password = string.Empty;
                }               
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
