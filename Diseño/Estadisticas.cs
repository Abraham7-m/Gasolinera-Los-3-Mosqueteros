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
    public partial class Estadisticas : Form
    {
        private Controlador controlador;

        public Estadisticas(Controlador c)
        {
            InitializeComponent();
            controlador = c;
        }


        private void Estadisticas_Load(object sender, EventArgs e)
        {
            int[] usos = new int[4];
            double[] dinero = new double[4];

            for (int i = 0; i < controlador.registros.Count; i++)
            {
                int bomba = controlador.registros[i].Bomba;

                usos[bomba - 1]++;

                dinero[bomba - 1] += controlador.registros[i].Total;
            }

            dgvEstadisticas.Rows.Clear();

            for (int i = 0; i < 4; i++)
            {
                dgvEstadisticas.Rows.Add(
                    "Bomba " + (i + 1),
                    usos[i],
                    "Q" + dinero[i].ToString("0.00")
                );
            }

            int mayor = 0;
            int menor = 0;

            for (int i = 1; i < 4; i++)
            {
                if (usos[i] > usos[mayor])
                {
                    mayor = i;
                }

                if (usos[i] < usos[menor])
                {
                    menor = i;
                }
            }

            double totalDinero = 0;

            for (int i = 0; i < controlador.registros.Count; i++)
            {
                totalDinero += controlador.registros[i].Total;
            }

            label4.Text = "Total de abastecimientos: " + controlador.registros.Count;

            label5.Text =
                "Dinero total: Q" +
                totalDinero.ToString("0.00");

            label2.Text =
                "Bomba más usada: Bomba " + (mayor + 1);

            label3.Text =
                "Bomba menos usada: Bomba " + (menor + 1);
        }
    }
}
