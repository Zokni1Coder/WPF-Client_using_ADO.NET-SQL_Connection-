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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace DMNA24Beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string[] f1Teams = {"Red Bull Racing", "Mercedes-AMG PETRONAS F1 Team", "Scuderia Ferrari" ,
        "Alpine F1 Team", "McLaren F1 Team", "Aston Martin Cognizant F1 Team", "Scuderia AlphaTauri",
         "Haas F1 Team", "Alfa Romeo Racing F1 Team", "Williams Racing"};

        static string connString = "server=127.0.0.1; user=root; database=formula1; password=";
        static MySqlConnection con = new MySqlConnection(connString);
        public MainWindow()
        {
            InitializeComponent();
            fillcombos();
        }

        public class versenyzo
        {
            public versenyzo(int rajtszam, string nev, string csapat, int szuletesiEv)
            {
                Rajtszam = rajtszam;
                Nev = nev;
                this.csapat = csapat;
                Szuletesiev = szuletesiEv;
            }

            private int rajtszam;

            public int Rajtszam
            {
                get { return rajtszam; }
                set
                {                   
                    rajtszam = value;
                }
            }

            private string nev;

            public string Nev
            {
                get { return nev; }
                set { nev = value; }
            }

            public string csapat { get; set; }

            private int szuletesiev;

            public int Szuletesiev
            {
                get { return szuletesiev; }
                set
                {                    
                    szuletesiev = value;
                }
            }
        }

        private void fillcombos()
        {
            try
            {
                combo1.Items.Clear();
                combo2.Items.Clear();
                combo3.Items.Clear();
                lista.Items.Clear();
                reszletesAdat.Items.Clear();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from drivers", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    versenyzo term = new versenyzo(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()));
                    lista.Items.Add(term);
                    combo3.Items.Add(dr[0].ToString());
                    reszletesAdat.Items.Add(term);
                    //MessageBox.Show(dr[0].ToString());
                }
                dr.Close();
                foreach (var item in f1Teams)
                {
                    combo1.Items.Add(item);
                    combo2.Items.Add(item);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fillcombos();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from drivers where rajtszam = @rsz", con);
                cmd.Parameters.AddWithValue("@rsz", keresesmezo.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                lista.Items.Clear();
                reszletesAdat.Items.Clear();
                while (dr.Read())
                {
                    versenyzo term = new versenyzo(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()));
                    lista.Items.Clear();
                    lista.Items.Add(term);
                    keresesmezo.Text = string.Empty;
                    reszletesAdat.Items.Add(term);
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

        private void foglalt(string value, int which)
        {
            MySqlCommand cmd1 = new MySqlCommand("select * from drivers", con);
            MySqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                switch (which)
                {
                    case 1:
                        {
                            if (dr[0].ToString() == value)
                            {
                                throw new rajtszamORNevException(value, 1);
                            }
                        }
                        break;

                    case 2:
                        {
                            if (dr[1].ToString() == value)
                            {
                                throw new rajtszamORNevException(value, 2);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            dr.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {               
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into drivers values(@rSz,@nev,@csapat,@szEv)", con);
                if (int.Parse(hozzaAdRSz.Text) < 1 || int.Parse(hozzaAdRSz.Text) > 99)
                {
                    throw new rajtszamORNevException(hozzaAdRSz.Text, 3);
                }
                foglalt(hozzaAdRSz.Text,1);
                cmd.Parameters.AddWithValue("@Rsz", hozzaAdRSz.Text);
                foglalt(hozzaAdNev.Text, 2);
                cmd.Parameters.AddWithValue("@nev", hozzaAdNev.Text);
                cmd.Parameters.AddWithValue("@csapat", combo1.Text);
                if (!(int.Parse(hozzaAdSzEv.Text) > (DateTime.Now.Year - 100) && int.Parse(hozzaAdSzEv.Text) < (DateTime.Now.Year - 18)))
                {
                    throw new korException(int.Parse(hozzaAdSzEv.Text));
                }
                cmd.Parameters.AddWithValue("@szEv", hozzaAdSzEv.Text);

                if (cmd.ExecuteNonQuery() < 0)
                {
                    MessageBox.Show("Something went wrong!");
                }
                con.Close();
                hozzaAdRSz.Text = "Racing number";
                hozzaAdNev.Text = "Name";
                combo1.Text = string.Empty;
                hozzaAdSzEv.Text = "Birth year";
                fillcombos();
                keresesmezo.Text = string.Empty;
            }
            catch (rajtszamORNevException x)
            {
                MessageBox.Show(x.kiiras);
                con.Close();
                switch (x.which)
                {
                    case 1:
                        hozzaAdRSz.Text = string.Empty;
                        break;
                    case 2:
                        hozzaAdNev.Text = string.Empty;
                        break;
                    case 3:
                        hozzaAdRSz.Text = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (korException x)
            {
                MessageBox.Show($"The driver can't be older than 100 or younger than 18! The given age: {x.Kor}");
                hozzaAdSzEv.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong data type or another error occurred!");
            }
        }

        private void torlesGomb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM drivers WHERE rajtszam = @rSz", con);
                cmd.Parameters.AddWithValue("@Rsz", combo3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                combo3.Text = string.Empty;
                fillcombos();
                keresesmezo.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                try
                {
                    versenyzo item = (versenyzo)lista.SelectedItem;
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from drivers where rajtszam = @rsz", con);
                    cmd.Parameters.AddWithValue("@rsz", item.Rajtszam);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    rsz.Content = dr[0];
                    modositNev.Text = dr[1].ToString();
                    modositSzEv.Text = dr[3].ToString();
                    int pos = 0;
                    for (int i = 0; i < f1Teams.Length; i++)
                    {
                        if (f1Teams[i] == dr[2].ToString())
                        {
                            pos = i;
                            break;
                        }
                    }
                    combo2.SelectedIndex = pos;
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update drivers set nev = @nev, csapat = @csapat, szuletesiev = @szEv where rajtszam = @rsz", con);
                cmd.Parameters.AddWithValue("@rsz", rsz.Content);
                cmd.Parameters.AddWithValue("@nev", modositNev.Text);


                cmd.Parameters.AddWithValue("@csapat", combo2.SelectedItem);
                if (!(int.Parse(modositSzEv.Text) > (DateTime.Now.Year - 100) && int.Parse(modositSzEv.Text) < (DateTime.Now.Year - 18)))
                {
                    throw new korException(int.Parse(hozzaAdSzEv.Text));
                }
                cmd.Parameters.AddWithValue("@szEv", modositSzEv.Text);
                cmd.ExecuteNonQuery();
            }
            catch (korException x)
            {
                MessageBox.Show($"The driver can't be older than 100 or younger than 18! The given age: {x.Kor}");
                hozzaAdSzEv.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                fillcombos();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
