using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaPresentacion
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            //carga por defecto la base de datos
            //cboBD.Items.Add("BD_BYS_CARDOZO");
            //cboBD.SelectedIndex = 0;

            //segunda opcion: lista todas las bases del servidor
            cargarBasesDeDatos();
        }

        //lista todas las bases del servidor conectado
        private void cargarBasesDeDatos()
        {
            //se obtiene la cadena de conexion desde el archivo App.config
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            try
            {
                //intenta abrir la conexion
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //consulta SQL para obtener todas las bd del servidor

                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //agrega cada nombre de base al comboBox
                    while (reader.Read()) {
                        cboBD.Items.Add(reader["name"].ToString());
                    }
                }

                //selecciona el primer item si se cargaron bd
                if (cboBD.Items.Count > 0)
                    cboBD.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // muestra mensaje si ocurre un error al cargar las bd
                MessageBox.Show("Error al cargar las bases de datos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //boton para probar la conexion
        private void btnConectar_Click(object sender, EventArgs e)
        {
            //lee la cadena de conexion de app.config
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            try
            {
                //intenta abrir la conexion
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    MessageBox.Show("Conexión exitosa a la base de datos!",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch(Exception ex){
                MessageBox.Show("Error al conectar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //boton para elegir la ruta donde se guardarda el .bak
        private void btnRuta_Click(object sender, EventArgs e)
        {
            //obtener la base de datos seleccionada
            string nombreBD = cboBD.SelectedItem != null ? cboBD.SelectedItem.ToString() : "BaseDatos";

            //crea un nombre de archivo por defecto con la fecha actual
            string nombreArchivo = $"Backup_{nombreBD}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bak";


            //abre un dialogo para guardar archivos
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //filtra para mostrar solo .bak
            saveFileDialog.Filter = "Backup files (*.bak)|*.bak";
            saveFileDialog.Title = "Seleccionar ruta para guardar el backup";


            //sugiere el nombre por defecto
            saveFileDialog.FileName = nombreArchivo;

            //si el usuario selecciona una ubicacion, se guarda en el textbox
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                txtRuta.Text = saveFileDialog.FileName;
            }
        }

        //boton que ejecuta el guardado
        private void btnbackup_Click(object sender, EventArgs e)
        {
            //verifica que el usuario haya elegido una base de datos
            if(cboBD.SelectedItem == null) {
                MessageBox.Show("Debe seleccionar una base de datos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //verifica que haya una ruta seleccionada para guardar el .bak
            if (string.IsNullOrEmpty(txtRuta.Text)) {
                MessageBox.Show("Debe seleccionar una ruta para guardar el backup",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //obtiene la cadena de conexion y datos seleccionados
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            string databaseName = cboBD.SelectedItem.ToString();

            string rutaBackup = txtRuta.Text;

            //comando sql que realiza el respaldo completo de la base
            string query = $@"
                            BACKUP DATABASE [{databaseName}]
                            TO DISK = '{rutaBackup}'
                            WITH FORMAT, INIT, NAME = 'RespaldoBD_{databaseName}', SKIP, STATS = 10;";

            
            txtRuta.Clear();
            
            MessageBox.Show("Backup realizado correctamente", 
                "Éxito", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            try
            {
                //Ejecuta el comando en SQL SERVER
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Si algo falla (por permisos, ruta, etc) se muestra el error
                MessageBox.Show("Error al realizar el backup: " + ex.Message, 
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
