using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Parcial_Mysql
{
    public partial class Form1 : Form
    {
        public string conexion_cadena = "Database=parcial;Data Source=localhost;User Id=grupo2;Password=grupo2";
        public string usuario_modificar;
        public Form1()
        {
            InitializeComponent();
        }

        private void bsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bmodificar_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            dateTimePicker1.Enabled = true;

          


            textBox1.Focus();

            bmodificar.Visible = false;
            bactualizar.Visible = true;

            usuario_modificar = textBox1.Text.ToString();

        }

        private void bnuevo_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            dateTimePicker1.Enabled = true;

           

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            comboBox1.Text = "Seleccione sexo";
            comboBox2.Text = "Seleccione estado civil";
            comboBox3.Text = "";

            dateTimePicker1.CustomFormat = "";

            textBox1.Focus();
            bnuevo.Visible = false;
            bguardar.Visible = true;
        }

        private void bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(conexion_cadena);
                string myInsertQuery = "INSERT INTO empleados(nombres,apellidos,fechanacimiento,lugarnacimiento,dui,nit,sexo,estado,lugarresidencia,celular,telefonocasa,correo,afiliadoafp) Values(?nombres,?apellidos,?fechanacimiento,?lugarnacimiento,?dui,?nit,?sexo,?estado,?lugarresidencia,?celular,?telefonocasa,?correo,?afiliadoafp)";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

               myCommand.Parameters.Add("?nombres", MySqlDbType.VarChar, 70).Value = textBox1.Text;
               myCommand.Parameters.Add("?apellidos", MySqlDbType.VarChar, 70).Value = textBox2.Text;
               myCommand.Parameters.Add("?fechanacimiento", MySqlDbType.VarChar, 25).Value = dateTimePicker1.Text;
               myCommand.Parameters.Add("?lugarnacimiento", MySqlDbType.VarChar, 50).Value = textBox3.Text;
               myCommand.Parameters.Add("?dui", MySqlDbType.Int32, 11).Value = textBox4.Text;
               myCommand.Parameters.Add("?nit", MySqlDbType.Int32, 20).Value = textBox5.Text;
               myCommand.Parameters.Add("?sexo", MySqlDbType.VarChar, 15).Value = comboBox1.Text;
               myCommand.Parameters.Add("?estado", MySqlDbType.VarChar, 15).Value = comboBox2.Text;
               myCommand.Parameters.Add("?lugarresidencia", MySqlDbType.VarChar, 50).Value = textBox6.Text;
               myCommand.Parameters.Add("?celular", MySqlDbType.Int32, 11).Value = textBox7.Text;
               myCommand.Parameters.Add("?telefonocasa", MySqlDbType.Int32, 11).Value = textBox8.Text;
               myCommand.Parameters.Add("?correo", MySqlDbType.VarChar, 40).Value = textBox9.Text;
               myCommand.Parameters.Add("?afiliadoafp", MySqlDbType.VarChar, 10).Value = comboBox3.Text;

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                string consulta = "SELECT * FROM empleados";

                MySqlConnection conexion = new MySqlConnection(conexion_cadena);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial";
            }
            catch
            {
                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bnuevo.Visible = true;
            bguardar.Visible = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox6.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            dateTimePicker1.Enabled = false;

          

            bnuevo.Focus();
        }

        private void beliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(conexion_cadena);
                string myInsertQuery = "DELETE From empleados WHERE idempleado = " + textBox10.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Usuario eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "SELECT * From empleados";

                MySqlConnection conexion = new MySqlConnection(conexion_cadena);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial";

            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al eliminar el usuario, primero realice la búsqueda");
            }
            bnuevo.Visible = true;
            bguardar.Visible = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            dateTimePicker1.Enabled = false;

        }

        private void bactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(conexion_cadena);

                string nom = textBox1.Text.ToString();
                string apelli = textBox2.Text.ToString();
                string lnaci = textBox3.Text.ToString();
                string dui = textBox4.Text.ToString();
                string nit = textBox5.Text.ToString();
                string lresi = textBox6.Text.ToString();
                string celu = textBox7.Text.ToString();
                string telecasa = textBox8.Text.ToString();
                string correo = textBox9.Text.ToString();

                string sexo = comboBox1.Text.ToString();
                string estado = comboBox2.Text.ToString();
                string afp = comboBox3.Text.ToString();

                string fecha = dateTimePicker1.CustomFormat.ToString();
                

                string myInsertQuery = "UPDATE empleados SET nombres = '" + nom + "',apellidos = '" + apelli + "',fechanacimiento = '" + fecha + "',lugarnacimiento = '" + lnaci + "',dui = '" +
                    dui + "',nit = '" + nit + "',sexo = '" + sexo + "',estado = '" + estado + "',lugarresidencia = '" + lresi + "',celular = '" + celu + "',telefonocasa = '" + telecasa +
                    "',correo = '" + correo + "',afiliadoafp = '" + afp + "'WHERE nombres = '" + usuario_modificar + "'";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();



                MessageBox.Show("Usuario modificado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "SELECT * FROM empleados";

                MySqlConnection conexion = new MySqlConnection(conexion_cadena);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bmodificar.Visible = true;
            bactualizar.Visible = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            dateTimePicker1.Enabled = false;


            bmodificar.Focus();
        }

        private void bbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string consult = "SELECT * From empleados WHERE idempleado = " + textBox10.Text + "";
                MySqlConnection coneccion = new MySqlConnection(conexion_cadena);
                MySqlDataAdapter comand = new MySqlDataAdapter(consult, coneccion);

                System.Data.DataSet ds = new System.Data.DataSet();

                comand.Fill(ds, "parcial");

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial";

                MySqlConnection myConnetion = new MySqlConnection(conexion_cadena);
                string myInsertQuery = "select * from empleados where idempleado = " + textBox10.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery, myConnetion);

                myCommand.Connection = myConnetion;
                myConnetion.Open();

                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    textBox1.Text = (myReader.GetString(1));
                    textBox2.Text = (myReader.GetString(2));
                    dateTimePicker1.CustomFormat = (myReader.GetString(3));
                    textBox3.Text = (myReader.GetString(4));
                    textBox4.Text = (myReader.GetString(5));
                    textBox5.Text = (myReader.GetString(6));
                    comboBox1.Text = (myReader.GetString(7));
                    comboBox2.Text = (myReader.GetString(8));
                    textBox6.Text = (myReader.GetString(9));
                    textBox7.Text = (myReader.GetString(10));
                    textBox8.Text = (myReader.GetString(11));
                    textBox9.Text = (myReader.GetString(12));
                    comboBox3.Text = (myReader.GetString(13));

                   
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myReader.Close();
                myConnetion.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Campo de busqueda esta vacio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            dateTimePicker1.Enabled = false;
           
            try
            {
                string consulta = "SELECT * FROM empleados";
                MySqlConnection conexion = new MySqlConnection(conexion_cadena);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "parcial");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial";
            }
            catch
            {

            }
        }
    }
}
