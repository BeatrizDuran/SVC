using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libConnection;
using MySql.Data.MySqlClient;
namespace SVC
{
    public partial class frmNuevoLogin : Form
    {
        public frmNuevoLogin()
        {
            //Singleton.GetInstance();
            InitializeComponent();
          
        }
        LaConexion obtenerDatos = new LaConexion();
        public static string nombre, ApellidoP, ApellidoM, ClaveElector;
        
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnACCEDERLOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                obtenerDatos.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
                obtenerDatos.con.Open();
                string query = "SELECT * FROM USUARIOS WHERE ClaveElector='" + txtUSUARIO.Text + "' AND PasswordCiudadano='" + txtCONTRASENA.Text + "'";
                obtenerDatos.comd = new MySqlCommand(query, obtenerDatos.con);
                obtenerDatos.Dr = obtenerDatos.comd.ExecuteReader();
                if (!obtenerDatos.Dr.HasRows)
                {
                    MessageBox.Show("Usuario o contraseña incorrecto", "Error 1002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (obtenerDatos.Dr.Read())
                    {
                        // MessageBox.Show(lector.GetString(2) + lector.GetString(3) + lector.GetString(4));
                        nombre = obtenerDatos.Dr.GetString(0);
                        ApellidoM = obtenerDatos.Dr.GetString(1);
                        ApellidoP = obtenerDatos.Dr.GetString(2);
                        ClaveElector = obtenerDatos.Dr.GetString(3);
                        if (obtenerDatos.Dr.GetString(12) == "ADMINISTRADOR")
                        {
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                            //new SesionAdministrador().ShowDialog();
                            if (MessageBox.Show("Sesión iniciada!, ¿Desea entrar al modulo de administrador?", "Inicio de sesión", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                frmNuevoAdmin b = new frmNuevoAdmin();
                                this.Hide();
                                b.ShowDialog();
                            }
                        }
                        if (obtenerDatos.Dr.GetString(10) == "CIUDADANO")
                        {
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                           // MessageBox.Show("Sesión iniciada!", "Inicio de sesión", MessageBoxButtons.OK);
                        }
                        if (obtenerDatos.Dr.GetString(12) == "PRESIDENTE M.D.")
                        {
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                            //new SesionAdministrador().ShowDialog();
                            if (MessageBox.Show("Sesión iniciada!, ¿Desea entrar al modulo de Presidete Mesa directiva?", "Inicio de sesión", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                frmNuevoAdmin b = new frmNuevoAdmin();
                                this.Hide();
                                b.ShowDialog();
                            }
                        }
                    }
                    this.Show();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
