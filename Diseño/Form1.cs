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

        private void ActualizarCombustible()
        {
            lblBomba1.Text = controlador.combustible[0].ToString("0.00") + " L";
            lblBomba2.Text = controlador.combustible[1].ToString("0.00") + " L";
            lblBomba3.Text = controlador.combustible[2].ToString("0.00") + " L";
            lblBomba4.Text = controlador.combustible[3].ToString("0.00") + " L";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarCombustible();
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

        private void button6_Click_1(object sender, EventArgs e)
        {

            Estadisticas form = new Estadisticas(controlador);
            form.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FormHistorial form = new FormHistorial(controlador);
            form.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Configuracion form = new Configuracion(controlador);
            ActualizarCombustible();
            form.ShowDialog();
        }
    }
}
