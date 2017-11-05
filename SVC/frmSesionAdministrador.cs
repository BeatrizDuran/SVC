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

namespace SVC
{
    public partial class frmSesionAdministrador : Form
    {
        public static string nombre, ApellidoP, ApellidoM;
        public static frmSesionAdministrador _instance;
        public frmSesionAdministrador()
        {
            InitializeComponent();
        }
        public frmSesionAdministrador instance
        {
            get
            {
                if (frmSesionAdministrador._instance == null)
                {
                    frmSesionAdministrador._instance = new frmSesionAdministrador();
                }
                return frmSesionAdministrador._instance;
            }
        }
        private void btnCERRARSESION_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar Sesion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                btnAGREGARNUEVACASILLA.Enabled = false;
                btnAGREGARNUEVAMESA.Enabled = false;
                btnAGREGARNUEVOPARTIDO.Enabled = false;
                btnAGREGARNUEVOUSUARIO.Enabled = false;              
                btnQUEJASYSUGERENCIAS.Enabled = false;
                btnREPORTES.Enabled = false;
                txtPASSWORDOTRO.Text = "";              
                MessageBox.Show("Sesión cerrada");
            }
        }
        private void btnAGREGARNUEVOUSUARIO_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
                con.Open();
                string query = "SELECT * FROM USUARIOS WHERE PasswordOtro='" + txtPASSWORDOTRO.Text + "'";
                MySqlCommand com = new MySqlCommand(query, con);
                MySqlDataReader lector = com.ExecuteReader();
                if (!lector.HasRows)
                {
                    //MessageBox.Show("Su clave es incorrecta", "Error 1003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (lector.Read())
                    {
                        // MessageBox.Show(lector.GetString(2) + lector.GetString(3) + lector.GetString(4));
                        nombre = lector.GetString(0);
                        ApellidoM = lector.GetString(1);
                        ApellidoP = lector.GetString(2);
                        if (lector.GetString(12) == "ADMINISTRADOR")
                        {
                            frmUsuarios u = new frmUsuarios();
                            u.administrador();
                            u.ShowDialog();
                            this.Hide();
                        }
                        if (lector.GetString(12) == "PRESIDENTE M.D.")
                        {
                            frmUsuarios u = new frmUsuarios();                        
                            u.ShowDialog();
                            this.Hide();
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
        private void btnQUEJASYSUGERENCIAS_Click(object sender, EventArgs e)
        {
            frmQuejasySugerenciasAdmin c = new frmQuejasySugerenciasAdmin();
            c.Show();           
            this.Hide();
        }
        private void btnAGREGARNUEVOPARTIDO_Click(object sender, EventArgs e)
        {
            frmPartidos c = new frmPartidos();
            c.Show();
            this.Hide();
        }
        private void btnAGREGARNUEVAMESA_Click(object sender, EventArgs e)
        {
            frmMesaDirectiva u = new frmMesaDirectiva();
            u.ShowDialog();
            this.Hide();
        }
        private void btnREPORTES_Click(object sender, EventArgs e)
        {
            frmReportes u = new frmReportes();
            u.ShowDialog();
            this.Hide();
        }
        private void btnAGREGARNUEVACASILLA_Click(object sender, EventArgs e)
        {
            frmCasillas u = new frmCasillas();
            u.ShowDialog();
            this.Hide();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            frmLogin c = new frmLogin();
            c.instance.Show();
            c.instance.botones();
            this.Hide();
        }
        private void btnACCEDER_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
                con.Open();
                string query = "SELECT * FROM USUARIOS WHERE PasswordOtro='" + txtPASSWORDOTRO.Text + "'";
                MySqlCommand com = new MySqlCommand(query, con);
                MySqlDataReader lector = com.ExecuteReader();
                if (!lector.HasRows)
                {
                    MessageBox.Show("Su clave es incorrecta", "Error 1003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (lector.Read())
                    {
                        // MessageBox.Show(lector.GetString(2) + lector.GetString(3) + lector.GetString(4));
                        nombre = lector.GetString(0);
                        ApellidoM = lector.GetString(1);
                        ApellidoP = lector.GetString(2);
                        if (lector.GetString(12) == "ADMINISTRADOR")
                        {
                            btnAGREGARNUEVACASILLA.Enabled = true;
                            btnAGREGARNUEVAMESA.Enabled = true;
                            btnAGREGARNUEVOPARTIDO.Enabled = true;
                            btnAGREGARNUEVOUSUARIO.Enabled = true;                                                
                            btnQUEJASYSUGERENCIAS.Enabled = true;
                            btnREPORTES.Enabled = true;                            
                        }
                        if (lector.GetString(12) == "PRESIDENTE M.D.")
                        {
                            btnAGREGARNUEVACASILLA.Enabled = false;
                            btnAGREGARNUEVAMESA.Enabled = false;
                            btnAGREGARNUEVOPARTIDO.Enabled = false;
                            btnAGREGARNUEVOUSUARIO.Enabled = true;                          
                            btnQUEJASYSUGERENCIAS.Enabled = false;
                            btnREPORTES.Enabled = true;
                        }

                    }
                }
            }
            catch  (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            }
    }
}
