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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using libConnection;
using SVClib;
using libValidaciones;
using System.Text.RegularExpressions;
namespace SVC
{
    public partial class frmQuejasySugerenciasAdmin : Form
    {
        LaConexion c = new LaConexion();
        libQuejasySugerencias q = new libQuejasySugerencias();
       
        public frmQuejasySugerenciasAdmin()
        {
            InitializeComponent();
        }                   
        private void QYS_Load(object sender, EventArgs e)
        {
            dgvQYS.Rows.Clear();
            c.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            c.con.Open();
            string query = "SELECT * FROM quejas_sugerencias";
            c.comd = new MySqlCommand(query, c.con);
            c.Dr = c.comd.ExecuteReader();
            while (c.Dr.Read())
            {
                dgvQYS.Rows.Add(c.Dr.GetString(0), c.Dr.GetString(1), c.Dr.GetString(2));
            }
            c.con.Close();
        }       
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvQYS.SelectedCells[0].RowIndex;
            string pk = dgvQYS.Rows[ren].Cells[0].Value.ToString();
            if (q.eliminarQueja("quejas_sugerencias",pk))
            {
                MessageBox.Show("Todo bien");
            }else
            {
                MessageBox.Show("Noooo");
            }          
        }
        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
            dgvQYS.Rows.Clear();
            c.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            c.con.Open();
            string query = "SELECT * FROM quejas_sugerencias WHERE Fecha='" + txtFECHA.Text + "' OR NombreUsuario='" + txtNOMBREUSUARIO.Text + "'";
            c.comd = new MySqlCommand(query, c.con);
            c.Dr = c.comd.ExecuteReader();
            while (c.Dr.Read())
            {
                dgvQYS.Rows.Add(c.Dr.GetString(0), c.Dr.GetString(1), c.Dr.GetString(2));
            }
           c. con.Close();
        }
        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            txtFECHA.Clear();
            txtNOMBREUSUARIO.Clear();
            QYS_Load(sender, e);
        }
        private void btnGENERARPDF_Click(object sender, EventArgs e)
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Quejas y sugerencias.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(3);
                PdfPCell Titulo = new PdfPCell(new Phrase("Quejas y sugerencias"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 3;
                Table.AddCell(Titulo);
                Table.AddCell("Nombre");
                Table.AddCell("Descripcion");
                Table.AddCell("Fecha");               
                for (int i = 0; i < dgvQYS.Rows.Count; i++)
                {
                    Table.AddCell(dgvQYS[0, i].Value.ToString());
                    Table.AddCell(dgvQYS[1, i].Value.ToString());
                    Table.AddCell(dgvQYS[2, i].Value.ToString());                    
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
            System.Diagnostics.Process.Start("Quejas y sugerencias.pdf");
        }
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            frmSesionAdministrador c = new frmSesionAdministrador();
            c.ShowDialog();
            this.Hide();
        }
       
    }
}
