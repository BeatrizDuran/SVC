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

namespace SVC
{
    public partial class frmQuejasySugerencias : Form
    {
        quejita q = new quejita();
        public frmQuejasySugerencias()
        {
            InitializeComponent();
        }
        private void enviar()
        {
            if (q.nuevaQueja(txtNOMBRE.Text, txtDESCRIPCION.Text, lblFECHA.Text))
            {
                MessageBox.Show("Perfecto");
            }
            else
            {
                MessageBox.Show("Malisimo");
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
            enviar();          
        }
    }
}
