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
using SVClib;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace SVC
{
    public partial class frmQuejasySugerencias : Form
    {
        libQuejasySugerencias q = new libQuejasySugerencias();
        public frmQuejasySugerencias()
        {
            InitializeComponent();
        }
        private void mysql_agregar()
        {
           if( q.nuevaQuejaMysql(txtNOMBRE.Text, txtDESCRIPCION.Text, lblFECHA.Text))
            {
                MessageBox.Show("Se registro en Mysql");
            }
            else
            {
                MessageBox.Show("No se registro en Mysql");
            }
                    
        }
        private void sql_agregar()
        {
                if (q.nuevaQuejasql(txtNOMBRE.Text, txtDESCRIPCION.Text, lblFECHA.Text))
                    MessageBox.Show("Perfecto sql server");
                else MessageBox.Show("Malisimo sql server");
            }
        private void pg_agregar()
        {
            if(q.nuevaQuejapg(txtNOMBRE.Text, txtDESCRIPCION.Text, lblFECHA.Text))
            {
                MessageBox.Show("Perfecto se registro postgres");
            }else
            {
                MessageBox.Show("Que mal, que mal postgres");
            }
        }

        private void btnMENUPRINCIPAL_Click(object sender, EventArgs e)
        {
            frmLogin a = new frmLogin();
            a.botones();
            a.Show();          
            this.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFECHA.Text = DateTime.Now.ToLongDateString();
        }
        private void quejasysugerencias_Load(object sender, EventArgs e)
        {
            lblFECHA.Text = DateTime.Now.ToLongDateString();
        }
        private void btnENVIAR_Click(object sender, EventArgs e)
        {
            sql_agregar();
            mysql_agregar();
            pg_agregar();         
        }
    }
}
