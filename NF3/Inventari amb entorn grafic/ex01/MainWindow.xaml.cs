using ex01.MODEL;
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

namespace ex01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Inventari inventari;
        public MainWindow()
        {
            InitializeComponent();
            inventari = new Inventari();
            lblCategoria.Visibility = Visibility.Collapsed;
            lblNom.Visibility = Visibility.Collapsed;
            lblPreu.Visibility = Visibility.Collapsed;
            lblQuantitat.Visibility = Visibility.Collapsed;
            lbl_Id.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Collapsed;
            txtId.Visibility = Visibility.Collapsed;
            txtNom.Visibility = Visibility.Collapsed;
            txtPreu.Visibility = Visibility.Collapsed;
            txtQuantitat.Visibility = Visibility.Collapsed;

            

           
        }




        private void btnNou_Click(object sender, RoutedEventArgs e)
        {
            lblCategoria.Visibility = Visibility.Visible;
            lblNom.Visibility = Visibility.Visible;
            lblPreu.Visibility = Visibility.Visible;
            lblQuantitat.Visibility = Visibility.Visible;
            lbl_Id.Visibility = Visibility.Visible;

            txtCategoria.Visibility = Visibility.Visible;
            txtId.Visibility = Visibility.Visible;
            txtNom.Visibility = Visibility.Visible;
            txtPreu.Visibility = Visibility.Visible;
            txtQuantitat.Visibility = Visibility.Visible;

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            lbl_Id.Visibility = Visibility.Visible;
            txtId.Visibility = Visibility.Visible;


        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            lblCategoria.Visibility = Visibility.Visible;
            lblNom.Visibility = Visibility.Visible;
            lblPreu.Visibility = Visibility.Visible;
            lblQuantitat.Visibility = Visibility.Visible;
            lbl_Id.Visibility = Visibility.Visible;

            txtCategoria.Visibility = Visibility.Visible;
            txtId.Visibility = Visibility.Visible;
            txtNom.Visibility = Visibility.Visible;
            txtPreu.Visibility = Visibility.Visible;
            txtQuantitat.Visibility = Visibility.Visible;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            lblCategoria.Visibility = Visibility.Visible;
            lblNom.Visibility = Visibility.Visible;
            lblPreu.Visibility = Visibility.Visible;
            lblQuantitat.Visibility = Visibility.Visible;
            lbl_Id.Visibility = Visibility.Visible;

            txtCategoria.Visibility = Visibility.Visible;
            txtId.Visibility = Visibility.Visible;
            txtNom.Visibility = Visibility.Visible;
            txtPreu.Visibility = Visibility.Visible;
            txtQuantitat.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            lblCategoria.Visibility = Visibility.Collapsed;
            lblNom.Visibility = Visibility.Collapsed;
            lblPreu.Visibility = Visibility.Collapsed;
            lblQuantitat.Visibility = Visibility.Collapsed;
            lbl_Id.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Collapsed;
            txtId.Visibility = Visibility.Collapsed;
            txtNom.Visibility = Visibility.Collapsed;
            txtPreu.Visibility = Visibility.Collapsed;
            txtQuantitat.Visibility = Visibility.Collapsed;
        }

        
    }
}