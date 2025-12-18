using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEquips
{
    using global::WpfEquips.DATA_ACCES;
    using global::WpfEquips.MODEL;
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System.Collections.Generic;
    using System.Windows;

    public partial class MainWindow : Window
    {
        private IDAO<Equips> daoActual;
        private bool actualitzacioEnCurs = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMySQL_Click(object sender, RoutedEventArgs e)
        {
            daoActual = DAOFactory.CreateDAOInstance(DataSource.MySQL);
            MostrarPanellFuncionalitats("MySQL");
        }

        private void BtnXML_Click(object sender, RoutedEventArgs e)
        {
            daoActual = DAOFactory.CreateDAOInstance(DataSource.XML);
            MostrarPanellFuncionalitats("XML");
        }

        private void BtnCSV_Click(object sender, RoutedEventArgs e)
        {
            daoActual = DAOFactory.CreateDAOInstance(DataSource.CSV);
            MostrarPanellFuncionalitats("CSV");
        }

        private void MostrarPanellFuncionalitats(string tipusFont)
        {
            titolFuncionalitats.Text = $"Opcions per a {tipusFont}";
            panelPrincipal.Visibility = Visibility.Collapsed;
            panelFuncionalitats.Visibility = Visibility.Visible;
            formulari.Visibility = Visibility.Collapsed;
        }

        private void BtnAfegir_Click(object sender, RoutedEventArgs e)
        {
            MostrarFormulari("Afegir un equip:", true, true, true, true);
            btnSeguentActualitzar.Visibility = Visibility.Collapsed;

            if (FormulariValid())
            {
                var equipNou = new Equips(txtNom.Text, txtAbreviatura.Text, txtPressupost.Text, txtLogo.Text);
                bool resultat = daoActual.Add(equipNou);
                MessageBox.Show(resultat ? "Equip afegit correctament." : "Error en afegir l'equip.");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MostrarFormulari("Eliminar un equip:", true, false, false, false);
            btnSeguentActualitzar.Visibility = Visibility.Collapsed;

            if (FormulariValid())
            {
                bool resultat = daoActual.Delete(txtAbreviatura.Text);
                MessageBox.Show(resultat ? "Equip eliminat correctament." : "Error en eliminar l'equip.");
            }
        }

        private void BtnMostrarTot_Click(object sender, RoutedEventArgs e)
        {
            List<Equips> dades = daoActual.GetAll();
            dataGrid.ItemsSource = dades;
            MostrarPanellDades();
        }

        private void BtnActualitzar_Click(object sender, RoutedEventArgs e)
        {
            actualitzacioEnCurs = false;

            MostrarFormulari("Actualitzar un equip: Introduïu l'abreviatura del equip a actualitzar.",
                true, false, false, false);

            btnSeguentActualitzar.Visibility = Visibility.Visible;
        }

        private void BtnSeguentActualitzar_Click(object sender, RoutedEventArgs e)
        {
            if (!actualitzacioEnCurs)
            {
                if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
                {
                    MessageBox.Show("Si us plau, introdueix una abreviatura.");
                    return;
                }

                Equips equip = daoActual.GetTeam(txtAbreviatura.Text);

                if (equip != null)
                {
                    txtNom.Text = equip.Nom;
                    txtPressupost.Text = equip.HexPress;
                    txtLogo.Text = equip.ImgClub;

                    MostrarFormulari("Actualitzar el equip: Modifiqueu els camps necessaris.",
                        true, true, true, true);

                    actualitzacioEnCurs = true;
                }
                else
                {
                    MessageBox.Show("Equip no trobat. Introduïu una abreviatura vàlida.");
                    txtAbreviatura.Clear();
                }
            }
            else
            {
                if (FormulariValid())
                {
                    Equips equipActualitzat = new Equips(txtNom.Text, txtAbreviatura.Text, txtPressupost.Text, txtLogo.Text);
                    bool resultat = daoActual.Update(txtAbreviatura.Text, equipActualitzat);  
                    MessageBox.Show(resultat ? "Equip actualitzat correctament." : "Error en actualitzar l'equip.");

                    panelFuncionalitats.Visibility = Visibility.Visible;
                    formulari.Visibility = Visibility.Collapsed;
                    btnSeguentActualitzar.Visibility = Visibility.Collapsed;
                    actualitzacioEnCurs = false;
                }
                else
                {
                    MessageBox.Show("Si us plau, omple tots els camps.");
                }
            }
        }

        private void BtnCercarEquip_Click(object sender, RoutedEventArgs e)
        {
            MostrarFormulari("Cercar un equip:", true, false, false, false);
            btnSeguentActualitzar.Visibility = Visibility.Collapsed;

            if (FormulariValid())
            {
                Equips equip = daoActual.GetTeam(txtAbreviatura.Text);
                MessageBox.Show(equip != null ? $"Equip trobat: {equip.Nom}" : "Equip no trobat.");
            }
        }

        private void MostrarFormulari(string titol, bool mostrarAbreviatura, bool mostrarNom, bool mostrarPressupost, bool mostrarLogo)
        {
            titolFuncionalitats.Text = titol;
            formulari.Visibility = Visibility.Visible;

            lblAbreviatura.Visibility = txtAbreviatura.Visibility = mostrarAbreviatura ? Visibility.Visible : Visibility.Collapsed;
            lblNom.Visibility = txtNom.Visibility = mostrarNom ? Visibility.Visible : Visibility.Collapsed;
            lblPressupost.Visibility = txtPressupost.Visibility = mostrarPressupost ? Visibility.Visible : Visibility.Collapsed;
            lblLogo.Visibility = txtLogo.Visibility = mostrarLogo ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnTornarFuncionalitats_Click(object sender, RoutedEventArgs e)
        {
            panelFuncionalitats.Visibility = Visibility.Collapsed;
            panelPrincipal.Visibility = Visibility.Visible;
        }

        private void BtnTornarDades_Click(object sender, RoutedEventArgs e)
        {
            panelDades.Visibility = Visibility.Collapsed;
            panelPrincipal.Visibility = Visibility.Visible;
        }

        private void MostrarPanellDades()
        {
            panelFuncionalitats.Visibility = Visibility.Collapsed;
            panelDades.Visibility = Visibility.Visible;
        }

        private bool FormulariValid()
        {
            return (!lblAbreviatura.IsVisible || !string.IsNullOrWhiteSpace(txtAbreviatura.Text)) &&
                   (!lblNom.IsVisible || !string.IsNullOrWhiteSpace(txtNom.Text)) &&
                   (!lblPressupost.IsVisible || !string.IsNullOrWhiteSpace(txtPressupost.Text)) &&
                   (!lblLogo.IsVisible || !string.IsNullOrWhiteSpace(txtLogo.Text));
        }
    }

}