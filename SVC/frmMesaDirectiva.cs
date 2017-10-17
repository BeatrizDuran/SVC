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
using iTextSharp;
using System.IO;
using libConnection;
using SVClib;

namespace SVC
{
    public partial class frmMesaDirectiva : Form
    {
        LaConexion BD = new LaConexion();
        libMesaDirectiva m = new libMesaDirectiva(); 
        public frmMesaDirectiva()
        {
            InitializeComponent();
        }
        private void mesa_load()
        {
            dgvMESADIRECTIVA.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM mesa_directiva";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvMESADIRECTIVA.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2),
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                    BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                    BD.Dr.GetString(11), BD.Dr.GetString(12), BD.Dr.GetString(13), BD.Dr.GetString(14), BD.Dr.GetString(15));
            }
            BD.con.Close();
        }
        private void buscar()
        {
            dgvMESADIRECTIVA.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM mesa_directiva WHERE ClaveMesa='" + txtCLAVEMESADIRECTIVA.Text + "' OR NomPresidente='" + txtPRESIDENTEmesaDIRECTIVA.Text + "'";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvMESADIRECTIVA.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2),
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                   BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                    BD.Dr.GetString(11), BD.Dr.GetString(12));
            }
            BD.con.Close();
        }
        private void limpiar()
        {
            txtCLAVEMESADIRECTIVA.Clear();
            txtDIRECCIÓN.Clear();
            txtPRESIDENTEclaveELECTOR.Clear();
            txtPRESIDENTEmesaDIRECTIVA.Text = "NOMBRES Y APELLIDOS";
            txtPRIMERESCRUTADOR.Text = "NOMBRES Y APELLIDOS";
            txtPRIMERescrutadorCLAVEelector.Clear();
            txtPRIMERsuplente.Text = "NOMBRES Y APELLIDOS";
            txtPRIMERsuplenteCLAVEelector.Clear();
            txtSMESADIRECTIVA.Text = "NOMBRES Y APELLIDOS";
            txtCEMESADIRECTIVA.Clear();
            txtSEGUNDOescrutador.Text = "NOMBRES Y APELLIDOS";
            txtSEGUNDOescrutadorCLAVEelector.Clear();
            txtSEGUNDOsuplente.Text = "NOMBRES Y APELLIDOS";
            txtSEGUNDOsuplenteCLAVEelector.Clear();
            txtTERCERsuplente.Text = "NOMBRES Y APELLIDOS";
            txtTERCERsuplenteCLAVEelector.Clear();
        }
        private void generarPDF()
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Mesa directiva.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(9);
                PdfPCell Titulo = new PdfPCell(new Phrase("Catalogo de integrantes"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 9;
                Table.AddCell(Titulo);
                Table.AddCell("Clave");
                Table.AddCell("Dirección");
                Table.AddCell("Presidente");
                Table.AddCell("Secretario");
                Table.AddCell("Primer escrutador");
                Table.AddCell("Segundo escrutador");
                Table.AddCell("Primer suplente");
                Table.AddCell("Segundo suplente");
                Table.AddCell("Tercer suplente");

                for (int i = 0; i < dgvMESADIRECTIVA.Rows.Count; i++)
                {
                    Table.AddCell(dgvMESADIRECTIVA[0, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[1, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[2, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[4, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[6, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[8, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[10, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[12, i].Value.ToString());
                    Table.AddCell(dgvMESADIRECTIVA[14, i].Value.ToString());
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
            System.Diagnostics.Process.Start("Mesa directiva.pdf");
        }
        private void leaveMesaDirectiva()
        {
            txtCLAVEMESADIRECTIVA.SelectionStart = txtCLAVEMESADIRECTIVA.TextLength;
            if (libValidaciones.libValidaciones.numeros(txtCLAVEMESADIRECTIVA.Text))
            { MessageBox.Show("Correcto"); }
            else { MessageBox.Show("Solo numeros"); }
        }
        private void leaveSECRETARIO()
        {

            txtSMESADIRECTIVA.SelectionStart = txtSMESADIRECTIVA.TextLength;
            if (libValidaciones.libValidaciones.letras(txtSMESADIRECTIVA.Text))
            { MessageBox.Show("Correcto"); }
            else { MessageBox.Show("Solo letras"); }
        }       
        private void leavePRIMERESCRUTADOR()
        {
            txtPRIMERESCRUTADOR.SelectionStart = txtPRIMERESCRUTADOR.TextLength;
            if (libValidaciones.libValidaciones.letras(txtPRIMERESCRUTADOR.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }
        private void leaveSEGUNDOESCRUTADOR()
        {
            txtSEGUNDOescrutador.SelectionStart = txtSEGUNDOescrutador.TextLength;
            if (libValidaciones.libValidaciones.letras(txtSEGUNDOescrutador.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }
        private void leavePRESIDENTE()
        {

            txtPRESIDENTEmesaDIRECTIVA.SelectionStart = txtPRESIDENTEmesaDIRECTIVA.TextLength;
            if (libValidaciones.libValidaciones.letras(txtPRESIDENTEmesaDIRECTIVA.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }
        private void leavePRIMERSUPLENTE()
        {
            txtPRIMERsuplente.SelectionStart = txtPRIMERsuplente.TextLength;
            if (libValidaciones.libValidaciones.letras(txtPRIMERsuplente.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }
        private void leaveSEGUNDOSUPLENTE()
        {
            txtSEGUNDOsuplente.SelectionStart = txtSEGUNDOsuplente.TextLength;
            if (libValidaciones.libValidaciones.letras(txtSEGUNDOsuplente.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }
        private void textChangedTERCERSUPLENTE()
        {
            txtTERCERsuplente.SelectionStart = txtTERCERsuplente.TextLength;
            if (libValidaciones.libValidaciones.letras(txtTERCERsuplente.Text))
            {
                MessageBox.Show("Correcto");
            }
            else { MessageBox.Show("Solo letras"); }
        }

        private void btnAGREGAR_Click(object sender, EventArgs e)
        {          
            if (m.registrarDatos(txtCLAVEMESADIRECTIVA.Text,txtDIRECCIÓN.Text,txtPRESIDENTEmesaDIRECTIVA.Text,
                txtPRESIDENTEclaveELECTOR.Text,txtSMESADIRECTIVA.Text,txtCEMESADIRECTIVA.Text,txtPRIMERESCRUTADOR.Text,
                txtPRIMERescrutadorCLAVEelector.Text,txtSEGUNDOescrutador.Text,txtSEGUNDOescrutadorCLAVEelector.Text,
                txtPRIMERsuplente.Text,txtPRIMERsuplenteCLAVEelector.Text,txtSEGUNDOsuplente.Text,txtSEGUNDOsuplenteCLAVEelector.Text,
                txtTERCERsuplente.Text,txtTERCERsuplenteCLAVEelector.Text))
            {
                MesaDirectiva_Load(sender, e);
                MessageBox.Show("Datos agregados!");
            }
            else { MessageBox.Show("ERROR al agregar información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void MesaDirectiva_Load(object sender, EventArgs e)
        {
            mesa_load();
        }
        private void dgvMESADIRECTIVA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCLAVEMESADIRECTIVA.Text = dgvMESADIRECTIVA[0, e.RowIndex].Value.ToString();
                txtDIRECCIÓN.Text = dgvMESADIRECTIVA[1, e.RowIndex].Value.ToString();
                txtPRESIDENTEmesaDIRECTIVA.Text = dgvMESADIRECTIVA[2, e.RowIndex].Value.ToString();
                txtPRESIDENTEclaveELECTOR.Text = dgvMESADIRECTIVA[3, e.RowIndex].Value.ToString();
                txtSMESADIRECTIVA.Text = dgvMESADIRECTIVA[4, e.RowIndex].Value.ToString();
                txtCEMESADIRECTIVA.Text = dgvMESADIRECTIVA[5, e.RowIndex].Value.ToString();
                txtPRIMERESCRUTADOR.Text = dgvMESADIRECTIVA[6, e.RowIndex].Value.ToString();
                txtPRIMERescrutadorCLAVEelector.Text = dgvMESADIRECTIVA[7, e.RowIndex].Value.ToString();
                txtSEGUNDOescrutador.Text = dgvMESADIRECTIVA[8, e.RowIndex].Value.ToString();
                txtSEGUNDOescrutadorCLAVEelector.Text = dgvMESADIRECTIVA[9, e.RowIndex].Value.ToString();
                txtPRIMERsuplente.Text = dgvMESADIRECTIVA[10, e.RowIndex].Value.ToString();
                txtPRIMERsuplenteCLAVEelector.Text = dgvMESADIRECTIVA[11, e.RowIndex].Value.ToString();
                txtSEGUNDOsuplente.Text = dgvMESADIRECTIVA[12, e.RowIndex].Value.ToString();
                txtSEGUNDOsuplenteCLAVEelector.Text = dgvMESADIRECTIVA[13, e.RowIndex].Value.ToString();
                txtTERCERsuplente.Text = dgvMESADIRECTIVA[14, e.RowIndex].Value.ToString();
                txtTERCERsuplenteCLAVEelector.Text = dgvMESADIRECTIVA[15, e.RowIndex].Value.ToString();
            }
        }
        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {           
            if (m.modificarDatos(txtCLAVEMESADIRECTIVA.Text,txtDIRECCIÓN.Text,txtPRESIDENTEmesaDIRECTIVA.Text,
                txtPRESIDENTEclaveELECTOR.Text,txtSMESADIRECTIVA.Text,txtCEMESADIRECTIVA.Text,txtPRIMERESCRUTADOR.Text,
                txtPRIMERescrutadorCLAVEelector.Text,txtSEGUNDOescrutador.Text,txtSEGUNDOescrutadorCLAVEelector.Text,
                txtPRIMERsuplente.Text,txtPRIMERsuplenteCLAVEelector.Text,txtSEGUNDOsuplente.Text,
                txtSEGUNDOsuplenteCLAVEelector.Text,txtTERCERsuplente.Text,txtTERCERsuplenteCLAVEelector.Text))
            {
                MesaDirectiva_Load(sender, e);
                MessageBox.Show("Se modifico con exitó", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Error al modificar"); }
        }
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvMESADIRECTIVA.SelectedCells[0].RowIndex;
            string pk = dgvMESADIRECTIVA.Rows[ren].Cells[0].Value.ToString();
            if (BD.Eliminar("mesa_directiva",pk))
            {
                MesaDirectiva_Load(sender, e);
                MessageBox.Show("Registro Eliminado");
            }
            else { MessageBox.Show("Error al eliminar"); }
        }
        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
            MesaDirectiva_Load(sender, e);
        }
        private void btnGENERARPDF_Click(object sender, EventArgs e)
        {
            generarPDF();
        }
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            frmSesionAdministrador u = new frmSesionAdministrador();
            u.ShowDialog();
            this.Hide();
        }
        private void txtCLAVEMESADIRECTIVA_Leave(object sender, EventArgs e)
        {
            leaveMesaDirectiva();
        }
        private void txtSMESADIRECTIVA_Leave(object sender, EventArgs e)
        {
            leaveSECRETARIO();
        }
        private void txtPRIMERESCRUTADOR_Leave(object sender, EventArgs e)
        {
            leavePRIMERESCRUTADOR();
        }
        private void txtSEGUNDOescrutador_Leave(object sender, EventArgs e)
        {
            leaveSEGUNDOESCRUTADOR();
        }
        private void txtPRESIDENTEmesaDIRECTIVA_Leave(object sender, EventArgs e)
        {
            leavePRESIDENTE();
        }
        private void txtPRIMERsuplente_Leave(object sender, EventArgs e)
        {
            leavePRIMERSUPLENTE();
        }
        private void txtSEGUNDOsuplente_Leave(object sender, EventArgs e)
        {
            leaveSEGUNDOSUPLENTE();
        }
        private void txtTERCERsuplente_TextChanged(object sender, EventArgs e)
        {
            textChangedTERCERSUPLENTE(); 
        }
    }
}
