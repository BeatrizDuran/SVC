using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using System.IO;
using MySql.Data.MySqlClient;
using SVClib;
using libConnection;
using libValidaciones;

namespace SVC
{
    public partial class frmCasillas : Form
    {
        ConnectionMySql BD = new ConnectionMySql();
        libCasillas c = new libCasillas();
        public frmCasillas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// carga los elementos en el modulo de las casillas
        /// </summary>
        private void casillas_load()
        {
            dgvCASILLAS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM casillas";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvCASILLAS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2),
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                   BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10));
            }
            BD.con.Close();
        }
        /// <summary>
        /// Generar los datos en el datagridview desde la base de datos
        /// </summary>
        private void buscar()
        {
            dgvCASILLAS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM casillas WHERE ClaveCasilla='" + txtCLAVE.Text + "' OR ColoniaCasilla='" + txtCOLONIA.Text + "' OR CodigoPostalCasilla='" + mtxtCODIGOPOSTAL.Text + "'";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvCASILLAS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2),
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                    BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10));
            }
            BD.con.Close();
        }
        /// <summary>
        /// Genera el pdf
        /// </summary>
        private void generarPDF()
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Casillas.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(11);
                PdfPCell Titulo = new PdfPCell(new Phrase("Catalogo de casillas"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 11;
                Table.AddCell(Titulo);
                Table.AddCell("Clave");
                Table.AddCell("Colonia");
                Table.AddCell("Dirección");
                Table.AddCell("Código postal");
                Table.AddCell("Presidente");
                Table.AddCell("Secretario");
                Table.AddCell("Primer escrutador");
                Table.AddCell("Segundo escrutador");
                Table.AddCell("Primer suplente");
                Table.AddCell("Segundo suplente");
                Table.AddCell("Tercer suplente");
                for (int i = 0; i < dgvCASILLAS.Rows.Count; i++)
                {
                    Table.AddCell(dgvCASILLAS[0, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[1, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[2, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[3, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[4, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[5, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[6, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[7, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[8, i].Value.ToString());
                    Table.AddCell(dgvCASILLAS[9, i].Value.ToString());

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
            System.Diagnostics.Process.Start("Casillas.pdf");
        }
        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void campos()
        {
            txtCLAVE.Clear();
            txtCOLONIA.Clear();
            txtDIRECCION.Clear();
            mtxtCODIGOPOSTAL.Clear();
            txtPRESIDENTE.Text = "NOMBRES Y APELLIDOS";
            txtPRIMERESCRUTADOR.Text = "NOMBRES Y APELLIDOS";
            txtPRIMERSUPLENTE.Text = "NOMBRES Y APELLIDOS";
            txtSECRETARIO.Text = "NOMBRES Y APELLIDOS";
            txtSEGUNDOESCRUTADOR.Text = "NOMBRES Y APELLIDOS";
            txtSEGUNDOSUPLENTE.Text = "NOMBRES Y APELLIDOS";
            txtTERCERSUPLENTE.Text = "NOMBRES Y APELLIDOS";
        }

        private void btnAGREGAR_Click(object sender, EventArgs e)
        {          
            if (c.registrarCasilla(txtCLAVE.Text,txtCOLONIA.Text,txtDIRECCION.Text,mtxtCODIGOPOSTAL.Text,
                txtPRESIDENTE.Text,txtSECRETARIO.Text,txtPRIMERESCRUTADOR.Text,txtSEGUNDOESCRUTADOR.Text,
                txtPRIMERSUPLENTE.Text,txtSEGUNDOSUPLENTE.Text,txtTERCERSUPLENTE.Text))
            {
                Casillas_Load(sender, e);
                MessageBox.Show("Datos agregados!");
            }
            else { MessageBox.Show("ERROR al agregar información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Casillas_Load(object sender, EventArgs e)
        {
            casillas_load();
        }
        private void dgvCASILLAS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
               txtCLAVE.Text =dgvCASILLAS[0, e.RowIndex].Value.ToString();
               txtCOLONIA.Text = dgvCASILLAS[1, e.RowIndex].Value.ToString();
               txtDIRECCION.Text = dgvCASILLAS[2, e.RowIndex].Value.ToString();
               mtxtCODIGOPOSTAL.Text = dgvCASILLAS[3, e.RowIndex].Value.ToString();
               txtPRESIDENTE.Text = dgvCASILLAS[4, e.RowIndex].Value.ToString();
               txtSECRETARIO.Text = dgvCASILLAS[5, e.RowIndex].Value.ToString();
               txtPRIMERESCRUTADOR.Text = dgvCASILLAS[6, e.RowIndex].Value.ToString();
               txtSEGUNDOESCRUTADOR.Text = dgvCASILLAS[7, e.RowIndex].Value.ToString();
               txtPRIMERSUPLENTE.Text = dgvCASILLAS[8, e.RowIndex].Value.ToString();
               txtSEGUNDOSUPLENTE.Text = dgvCASILLAS[9, e.RowIndex].Value.ToString();
               txtTERCERSUPLENTE.Text = dgvCASILLAS[10, e.RowIndex].Value.ToString();                
            }
        }
        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {
            if (c.modificarCasilla(txtCLAVE.Text, txtCOLONIA.Text, txtDIRECCION.Text, mtxtCODIGOPOSTAL.Text,
                txtPRESIDENTE.Text, txtSECRETARIO.Text, txtPRIMERESCRUTADOR.Text, txtSEGUNDOESCRUTADOR.Text,
                txtPRIMERSUPLENTE.Text, txtSEGUNDOSUPLENTE.Text, txtTERCERSUPLENTE.Text))
            {
                Casillas_Load(sender, e);
                MessageBox.Show("Se modifico con exitó", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Error al modificar"); }
        }
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvCASILLAS.SelectedCells[0].RowIndex;
            string pk = dgvCASILLAS.Rows[ren].Cells[0].Value.ToString();
            if (c.eliminarDatos("casillas",pk))
            {
                Casillas_Load(sender, e);
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
            campos();
            Casillas_Load(sender, e);
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
       
    }
}
