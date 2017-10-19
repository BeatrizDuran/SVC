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
using MySql.Data.MySqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SVC
{
    public partial class frmCandidatos : Form
    {
        ConnectionMySql bd = new ConnectionMySql();
        libCandidatos c = new libCandidatos();
        public frmCandidatos()
        {
            InitializeComponent();
        }

        private void btnAGREGAR_Click(object sender, EventArgs e)
        {
            if (c.registroCandidatos(txtCLAVE.Text,txtNOMBRE.Text,txtAPELLIDOP.Text,txtAPELLIDOM.Text,
                txtCLAVEELECTOR.Text,cbNIVELELECCION.Text,cbTIPOPUESTO.Text,textBox1.Text))
            {
                Candidatos_Load(sender, e);
                MessageBox.Show("Datos agregados!");
            }
            else { MessageBox.Show("ERROR al agregar información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {
            if (c.modificarRegistro(txtCLAVE.Text, txtNOMBRE.Text, txtAPELLIDOP.Text, txtAPELLIDOM.Text,
               txtCLAVEELECTOR.Text, cbNIVELELECCION.Text, cbTIPOPUESTO.Text, textBox1.Text))
            {
                Candidatos_Load(sender, e);
                MessageBox.Show("Datos agregados!");
            }
            else { MessageBox.Show("ERROR al agregar información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvCANDIDATOS.SelectedCells[0].RowIndex;
            string pk = dgvCANDIDATOS.Rows[ren].Cells[0].Value.ToString();
            if (c.eliminarRegistro("partidos", pk))
            {
                Candidatos_Load(sender, e);
                MessageBox.Show("Registro Eliminado");
            }
            else { MessageBox.Show("Error al eliminar"); }
        }

        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
            dgvCANDIDATOS.Rows.Clear();
            bd.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            bd.con.Open();
            string query = "SELECT * FROM partidos_candidatos WHERE idCandidato='" + txtCLAVE.Text + "' OR CandidatoNombre='" + txtNOMBRE.Text + "'";
            bd.comd = new MySqlCommand(query, bd.con);
            bd.Dr = bd.comd.ExecuteReader();
            while (bd.Dr.Read())
            {
                dgvCANDIDATOS.Rows.Add(bd.Dr.GetString(0), bd.Dr.GetString(1), bd.Dr.GetString(2),
                    bd.Dr.GetString(3), bd.Dr.GetString(4), bd.Dr.GetString(5), bd.Dr.GetString(6),
                   bd.Dr.GetString(7));
            }
            bd.con.Close();
        }

        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            txtNOMBRE.Text = "";
            txtCLAVEELECTOR.Text = "";
            txtCLAVE.Text = "";
            txtAPELLIDOP.Text = "";
            txtAPELLIDOM.Text = "";
            cbNIVELELECCION.Text = "";
            textBox1.Text = "";
            cbTIPOPUESTO.Text = "";
            Candidatos_Load(sender, e);
        }

        private void Candidatos_Load(object sender, EventArgs e)
        {
            dgvCANDIDATOS.Rows.Clear();
            bd.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            bd.con.Open();
            string query = "SELECT * FROM partidos_candidatos";
            bd.comd = new MySqlCommand(query, bd.con);
            bd.Dr = bd.comd.ExecuteReader();
            while (bd.Dr.Read())
            {
                dgvCANDIDATOS.Rows.Add(bd.Dr.GetString(0), bd.Dr.GetString(1),
                    bd.Dr.GetString(2), bd.Dr.GetString(3), bd.Dr.GetString(4),
                    bd.Dr.GetString(5), bd.Dr.GetString(6), bd.Dr.GetString(7));
            }
            bd.con.Close();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            frmPartidos u = new frmPartidos();
            u.ShowDialog();
            this.Hide();
        }

        private void btnGENERARPDF_Click(object sender, EventArgs e)
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Candidatos.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(8);
                PdfPCell Titulo = new PdfPCell(new Phrase("Catalogo de candidatos"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 8;
                Table.AddCell(Titulo);
                Table.AddCell("Clave");
                Table.AddCell("Nombre");
                Table.AddCell("Apellido Paterno");
                Table.AddCell("Apellido Materno");
                Table.AddCell("Clave de Elector");
                Table.AddCell("Nivel de Elección");
                Table.AddCell("Candidato a:");
                Table.AddCell("Partido");

                for (int i = 0; i < dgvCANDIDATOS.Rows.Count; i++)
                {
                    Table.AddCell(dgvCANDIDATOS[0, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[1, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[2, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[3, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[4, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[5, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[6, i].Value.ToString());
                    Table.AddCell(dgvCANDIDATOS[7, i].Value.ToString());

                }
                pdf.Add(Table);
                //Fin del pdf
                pdf.Close();
            }
            catch (DocumentException error)
            {
                MessageBox.Show(error.ToString());
            }
            catch (IOException errorcito)
            {
                MessageBox.Show(errorcito.ToString());
            }
            System.Diagnostics.Process.Start("Candidatos.pdf");
        }

        private void dgvCANDIDATOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCLAVE.Text = dgvCANDIDATOS[0, e.RowIndex].Value.ToString();
                txtNOMBRE.Text = dgvCANDIDATOS[1, e.RowIndex].Value.ToString();
                txtAPELLIDOP.Text = dgvCANDIDATOS[2, e.RowIndex].Value.ToString();
                txtAPELLIDOM.Text = dgvCANDIDATOS[3, e.RowIndex].Value.ToString();
                txtCLAVEELECTOR.Text = dgvCANDIDATOS[4, e.RowIndex].Value.ToString();
                cbNIVELELECCION.Text = dgvCANDIDATOS[5, e.RowIndex].Value.ToString();
                cbTIPOPUESTO.Text = dgvCANDIDATOS[6, e.RowIndex].Value.ToString();
                textBox1.Text = dgvCANDIDATOS[7, e.RowIndex].Value.ToString();              
            }
        }

    }
}
