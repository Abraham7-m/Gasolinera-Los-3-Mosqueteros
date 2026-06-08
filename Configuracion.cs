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
    public partial class Configuracion : Form
    {
        private Controlador controlador;

        public Configuracion(Controlador c)
        {

            InitializeComponent();

            controlador = c;

            textRegular.Text = controlador.precios.Regular.ToString();
            textSuper.Text = controlador.precios.Super.ToString();
            textPremiun.Text = controlador.precios.Premium.ToString();
            textDiesel.Text = controlador.precios.Diesel.ToString();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlador.precios.Regular = double.Parse(textRegular.Text);
            controlador.precios.Super = double.Parse(textSuper.Text);
            controlador.precios.Premium = double.Parse(textPremiun.Text);
            controlador.precios.Diesel = double.Parse(textDiesel.Text);

            MessageBox.Show("Precios actualizados");
            this.Close();
        }

        private void textPremiun_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
