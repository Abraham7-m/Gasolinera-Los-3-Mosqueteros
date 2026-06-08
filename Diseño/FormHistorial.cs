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
    public partial class FormHistorial : Form
    {
        private Controlador controlador;
        public FormHistorial(Controlador c)
        {

            InitializeComponent();
            controlador = c;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = controlador.registros;
            dgvRegistros.Columns["Litros"].DefaultCellStyle.Format = "N2";
            dgvRegistros.Columns["Total"].DefaultCellStyle.Format = "N2";
            dgvRegistros.Columns["PrecioLitro"].DefaultCellStyle.Format = "N2";
        }
    }
}
