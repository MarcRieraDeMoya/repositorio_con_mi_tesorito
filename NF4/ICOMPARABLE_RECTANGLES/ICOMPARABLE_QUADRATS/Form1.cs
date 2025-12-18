using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICOMPARABLE_RECTANGLES
{
    public partial class Form1 : Form
    {
        private List<Rectangle> rectangles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rectangles = LlegirRectangles();
            MostrarDadesDataGrid();
        }

        private void MostrarDadesDataGrid()
        {
            this.dvRectangles.DataSource = rectangles.ToArray();
        }

        private List<Rectangle> LlegirRectangles()
        {
            StreamReader sr = new StreamReader("rectangles.csv");
            string linia = sr.ReadLine(); 

            while(linia != null)
            {
               linia = sr.ReadLine();
            }
        }

        private void btnOrdenarNom_Click(object sender, EventArgs e)
        {
            rectangles.Sort();
            MostrarDadesDataGrid();
        }

        private void btnOrdenarX_Click(object sender, EventArgs e)
        {
            rectangles.Sort(new Rectangle.ComparadorX());
            MostrarDadesDataGrid();
        }

        private void btnOrdenarAmplada_Click(object sender, EventArgs e)
        {
            rectangles.Sort(new Rectangle.ComparadorAmplada());
            MostrarDadesDataGrid();
        }

        private void btnOrdenarArea_Click(object sender, EventArgs e)
        {
            rectangles.Sort(new Rectangle.ComparadorArea());
            MostrarDadesDataGrid();
        }
    }
}
