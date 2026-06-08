using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GasolineraLos3Mosqueteros
{
    public partial class FormAbastecimiento : Form
    {
        private int numeroBomba;

        private Controlador controlador;

        Timer timer = new Timer();

        double litros = 0;
        double monto = 0;
        double precio;

        int segundos = 0;

        DateTime horaInicio;

        bool tanqueActivo = false;

        public FormAbastecimiento(int bomba, Controlador c)
        {
            InitializeComponent();

            numeroBomba = bomba;
            controlador = c;

            label4.Text = "ABASTECIMIENTO - BOMBA " + bomba;
        }

        private void Abastecimiento_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;

                //ocultar monto y boton detener
                btnDetener.Visible = false;
                label3.Visible = true;
                txtMonto.Visible = true;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;

                btnDetener.Visible = true;
                label3.Visible = false;
                txtMonto.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string nit = txtNit.Text;

            monto = 0;
            litros = 0;

            string tipoGasolina = cmbGasolina.Text;
            precio = controlador.ObtenerPrecio(tipoGasolina);

            if (nombre == "" || nit == "")
            {
                MessageBox.Show("Ingrese nombre y NIT");
                return;
            }

            bool esPrepago = checkBox1.Checked;
            bool esTanque = checkBox2.Checked;

            if (!esPrepago && !esTanque)
            {
                MessageBox.Show("Seleccione un tipo de abastecimiento");
                return;
            }
            if (esPrepago)
            {
                if (!double.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("Monto inválido");
                    return;
                }

                litros = monto / precio;

                double disponible = controlador.combustible[numeroBomba - 1];

                if (litros > disponible)
                {
                    litros = disponible;
                    monto = litros * precio;
                }

                controlador.combustible[numeroBomba - 1] -= litros;

                segundos = (int)litros;

                MessageBox.Show("Iniciar prepago ");

                controlador.EnviarArduino(numeroBomba, segundos);
            }

            else if (esTanque)
            {
                horaInicio = DateTime.Now;
                tanqueActivo = true;

                // tiempo largo para que quede encendida

                MessageBox.Show("Tanque lleno iniciado. Presione detener para finalizar.");
                controlador.EnviarArduino(numeroBomba, 999);
                return;

            }

            Abastecimiento nuevo = new Abastecimiento();

            nuevo.Cliente = nombre;
            nuevo.Nit = nit;
            nuevo.Bomba = numeroBomba;
            nuevo.Tipo = esPrepago ? "Prepago" : "Tanque lleno";
            nuevo.Litros = litros;
            nuevo.Total = monto;
            nuevo.Fecha = DateTime.Now;
            nuevo.TipoGasolina = tipoGasolina;
            nuevo.PrecioLitro = precio;

            controlador.registros.Add(nuevo);
            controlador.GuardarJson();


            MessageBox.Show("Abastecimiento registrado correctamente " + segundos);
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string nit = txtNit.Text;

            monto = 0;
            litros = 0;

            string tipoGasolina = cmbGasolina.Text;
            precio = controlador.ObtenerPrecio(tipoGasolina);

            if (nombre == "" || nit == "")
            {
                MessageBox.Show("Ingrese nombre y NIT");
                return;
            }

            bool esPrepago = checkBox1.Checked;
            bool esTanque = checkBox2.Checked;

            if (!esPrepago && !esTanque)
            {
                MessageBox.Show("Seleccione un tipo de abastecimiento");
                return;
            }
            if (esPrepago)
            {
                if (!double.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("Monto inválido");
                    return;
                }

                litros = monto / precio;

                double disponible = controlador.combustible[numeroBomba - 1];

                if (litros > disponible)
                {
                    litros = disponible;
                    monto = litros * precio;
                }

                controlador.combustible[numeroBomba - 1] -= litros;

                segundos = (int)litros;

                MessageBox.Show("Iniciar prepago ");

                controlador.EnviarArduino(numeroBomba, segundos);
            }

            else if (esTanque)
            {
                horaInicio = DateTime.Now;
                tanqueActivo = true;

                // tiempo largo para que quede encendida

                MessageBox.Show("Tanque lleno iniciado. Presione detener para finalizar.");
                controlador.EnviarArduino(numeroBomba, 999);
                return;

            }

            Abastecimiento nuevo = new Abastecimiento();

            nuevo.Cliente = nombre;
            nuevo.Nit = nit;
            nuevo.Bomba = numeroBomba;
            nuevo.Tipo = esPrepago ? "Prepago" : "Tanque lleno";
            nuevo.Litros = litros;
            nuevo.Total = monto;
            nuevo.Fecha = DateTime.Now;
            nuevo.TipoGasolina = tipoGasolina;
            nuevo.PrecioLitro = precio;

            controlador.registros.Add(nuevo);
            controlador.GuardarJson();


            MessageBox.Show("Abastecimiento registrado correctamente " + segundos);
        }

        private void FormAbastecimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
