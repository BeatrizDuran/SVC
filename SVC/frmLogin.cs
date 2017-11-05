using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using libConnection;

namespace SVC
{
    public partial class frmLogin : Form
    {
        ConnectionMySql obtenerDatos = new ConnectionMySql();
        public static string nombre, ApellidoP, ApellidoM,ClaveElector;
        public static frmLogin _instance;
        public void botones()
        {
            btnALCADIA.Enabled = true;
            btnESTATAL.Enabled = true;
            btnGOBERNATURA.Enabled = true;
            btnPRESIDENCIAL.Enabled = true;
            btnQUEJASYSUGERENCIAS.Enabled = true;                    
        }
        /// <summary>
        /// Implementando el patron singleton
        /// </summary>
        public frmLogin instance
        {
            get{
                if (frmLogin._instance == null)
                {
                    frmLogin._instance = new frmLogin();
                }
                return frmLogin._instance;
            }
        }
      
        private void cerrarsesion()
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar Sesion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                btnPRESIDENCIAL.Enabled = false;
                btnGOBERNATURA.Enabled = false;
                btnALCADIA.Enabled = false;
                btnESTATAL.Enabled = false;
                btnQUEJASYSUGERENCIAS.Enabled = false;
                txtCONTRASENA.Text = "";
                txtUSUARIO.Text = "Ingrese su clave de elector";
                MessageBox.Show("Sesión cerrada");
            }
        }
        private void acceder()
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
                            botones();
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                            //new SesionAdministrador().ShowDialog();
                            if (MessageBox.Show("Sesión iniciada!, ¿Desea entrar al modulo de administrador?", "Inicio de sesión", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                frmSesionAdministrador b = new frmSesionAdministrador();
                                b.instance.Show();
                                this.Hide();
                            }
                        }
                        if (obtenerDatos.Dr.GetString(10) == "CIUDADANO")
                        {
                            botones();
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                           // MessageBox.Show("Sesión iniciada!", "Inicio de sesión", MessageBoxButtons.OK);
                        }
                        if (obtenerDatos.Dr.GetString(12) == "PRESIDENTE M.D.")
                        {
                            botones();
                            txtCONTRASENA.Text = "";
                            txtUSUARIO.Text = "Ingrese su clave de elector";
                            //new SesionAdministrador().ShowDialog();
                            if (MessageBox.Show("Sesión iniciada!, ¿Desea entrar al modulo de Presidete Mesa directiva?", "Inicio de sesión", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                frmSesionAdministrador b = new frmSesionAdministrador();
                                this.Hide();
                                b.instance.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnQUEJASYSUGERENCIAS_Click(object sender, EventArgs e)
        {
            frmQuejasySugerencias a = new frmQuejasySugerencias();
            a.Show();
            this.Hide();
        }       
        private void btnALCADIA_Click(object sender, EventArgs e)
        {
            frmAlcadia a = new frmAlcadia();
            a.instance.Show();
            this.Hide();
        }
        private void btnGOBERNATURA_Click(object sender, EventArgs e)
        {
            frmGobernatura a = new frmGobernatura();
            a.Show();
            this.Hide();
        }
        private void btnESTATAL_Click(object sender, EventArgs e)
        {
            frmEstatal a = new frmEstatal();
            a.Show();
            this.Hide();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnCERRARSESIÓN_Click(object sender, EventArgs e)
        {
            cerrarsesion();
        }
        private void btnPRESIDENCIAL_Click(object sender, EventArgs e)
        {
            frmPresidencia a = new frmPresidencia();
            a.Show();
            this.Hide();
        }
        private void btnACCEDERLOGIN_Click(object sender, EventArgs e)
        {
            acceder();
        }
    }
}
