using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO.Ports;
using System.Windows.Forms;

namespace GasolineraLos3Mosqueteros
{
    public class Controlador
    {

        public List<Abastecimiento> registros = new List<Abastecimiento>();

        private string rutaArchivo = @"C:\temp\historial_abastecimientos.json";

        public PreciosGasolina precios = new PreciosGasolina();

        public double[] combustible = { 50, 50, 50, 50 }; //Cada bomba tiene 50 litros de gasolina

        //Puerto Serial (Conexion con arduino)
        public SerialPort puerto = new SerialPort("COM10", 9600);
        
        public Controlador()
        {
            CargarCombustible();
            CargarJson();
        }
        public void GuardarCombustible()
        {
            string json = JsonConvert.SerializeObject(combustible, Formatting.Indented);
            File.WriteAllText("combustible.json", json);
        }

        public void CargarCombustible()
        {
            if (File.Exists("combustible.json"))
            {
                string json = File.ReadAllText("combustible.json");
                combustible = JsonConvert.DeserializeObject<double[]>(json);
            }
            else
            {
                combustible = new double[] { 50, 50, 50, 50 };
                GuardarCombustible();
            }
        }

        public double ObtenerPrecio(string tipo)
        {
            if (tipo == "Regular")
                return precios.Regular;

            if (tipo == "Super")
                return precios.Super;

            if (tipo == "Premium")
                return precios.Premium;

            if (tipo == "Diesel")
                return precios.Diesel;

            return 10;
        }

        public void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(registros, Formatting.Indented);

            File.WriteAllText(rutaArchivo, json);
        }

        public void CargarJson()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);

                registros = JsonConvert.DeserializeObject<List<Abastecimiento>>(json) ?? new List<Abastecimiento>();
            }
        }

        public string ObtenerRutaArchivo()
        {
            return rutaArchivo;
        }

        public void EnviarArduino(int bomba, int segundos)
        {
            try
            {
                if (!puerto.IsOpen)
                {
                    puerto.Open();
                }

                puerto.WriteLine(bomba + "," + segundos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Arduino: " + ex.Message);
            }
        }
    }
}
