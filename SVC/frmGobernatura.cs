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
using SVClib;

namespace SVC
{
    public partial class frmGobernatura : Form
    {
        ConnectionMySql BD = new ConnectionMySql();
        libVotos v = new libVotos();
        public static frmGobernatura _instanceGobernatura;
        public frmGobernatura()
        {
            InitializeComponent();
        }
        public frmGobernatura instance
        {
            get
            {
                if (frmGobernatura._instanceGobernatura == null)
                {
                    frmGobernatura._instanceGobernatura = new frmGobernatura();
                }
                return frmGobernatura._instanceGobernatura;
            }
        }
        private void Gobernatura_Load(object sender, EventArgs e)
        {
            label5.Text = frmLogin.ClaveElector;
            lblNOMBRE.Text = "Nombre: " + frmLogin.nombre;
            lblFOLIO.Text = DateTime.Now.Ticks.ToString();
            {

                BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
                BD.con.Open();
                string query = "SELECT * FROM partidos_candidatos WHERE TipoPuesto = 'GOBERNADOR'";
                BD.comd = new MySqlCommand(query, BD.con);
                BD.Da = new MySqlDataAdapter(BD.comd);
                DataTable dt = new DataTable();
                BD.Da.Fill(dt);
                cbCLAVECANDIDATO.ValueMember = "idCandidato";
                cbCLAVECANDIDATO.DisplayMember = "idCandidato";
                cbCLAVECANDIDATO.DataSource = dt;
                cbNOMBRE.ValueMember = "idCandidato";
                cbNOMBRE.DisplayMember = "CandidatoNombre";
                cbNOMBRE.DataSource = dt;
                BD.Dr = BD.comd.ExecuteReader();
                while (BD.Dr.Read())
                {
                    dataGridView1.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2), BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6), BD.Dr.GetString(7));
                }
                BD.con.Close();
            }
        }
        private void btnVOTAR1_Click(object sender, EventArgs e)
        {  
            if (v.registroVoto(lblFOLIO.Text, textBox1.Text, cbCLAVECANDIDATO.Text))
            {
                MessageBox.Show("Su voto quedo registrado");
            }
            else { MessageBox.Show("ERROR al guardar el voto"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin a = new frmLogin();
            a.Show();
            a.botones();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cbCLAVECANDIDATO.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                cbNOMBRE.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFOLIO.Text = DateTime.Now.Ticks.ToString();
        }
    }
}
