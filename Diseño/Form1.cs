using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasolineraLos3Mosqueteros
{
    public partial class Form1 : Form
    {
        Controlador controlador = new Controlador();
        public Form1()
        {
            InitializeComponent();
            controlador.CargarJson();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAbastecimiento form = new FormAbastecimiento(1, controlador);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAbastecimiento form = new FormAbastecimiento(2, controlador);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAbastecimiento form = new FormAbastecimiento(3, controlador);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAbastecimiento form = new FormAbastecimiento(4, controlador);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormHistorial form = new FormHistorial(controlador);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Estadisticas form = new Estadisticas(controlador);
            form.Show();
        }
    }
}
