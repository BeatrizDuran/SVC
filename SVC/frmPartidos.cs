using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;
using MySql.Data.MySqlClient;
using SVClib;
using libConnection;

namespace SVC
{
    public partial class frmPartidos : Form
    {
        ConnectionMySql BD = new ConnectionMySql();
        libPartidos p = new libPartidos();
        public frmPartidos()
        {
            InitializeComponent();
        }
        private string ruta = "";
        private void partidos()
        {
            dgvPARTIDOS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM partidos";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvPARTIDOS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1),
                    BD.Dr.GetString(2), BD.Dr.GetString(3), BD.Dr.GetString(4),
                    BD.Dr.GetString(5), BD.Dr.GetString(6), BD.Dr.GetString(7),
                    System.Drawing.Image.FromFile(BD.Dr.GetString(8)), BD.Dr.GetString(8));
            }
            BD.con.Close();
        }
        private void imagen()
        {
            openFileIma.FileName = "";//borrar el nombre por default de la ventana abrir
            openFileIma.Filter = "Image Files (*.bmp,*.jpg,*.png,*.gif)|*.bmp;*.jpg;*.png;*.gif";//tipo de imagenes soportadas
            openFileIma.ShowDialog();
            ruta = openFileIma.FileName;
            pcBIMAGENPARTIDO.Image = System.Drawing.Image.FromFile(ruta);//agregar la imagen al picture box
                                                                         // MessageBox.Show("" + ruta);
            if (File.Exists(ruta))
            {
                //pictureBox1.Image = Image.FromFile(ruta);
            }
        }
        private void buscar()
        {
            dgvPARTIDOS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM partidos WHERE ClavePartido='" + txtCLAVEDELPARTIDO.Text + "' OR NomPartido='" + txtNOMBREDELPARTIDO.Text + "'";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvPARTIDOS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2),
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                   BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                   BD.Dr.GetString(11), BD.Dr.GetString(12), System.Drawing.Image.FromFile(BD.Dr.GetString(13)));
            }
            BD.con.Close();
        }
        private void limpiar()
        {
            txtAPELLIDOMATERNOVPP.Clear();
            txtAPELLIDOMPRESIDENTE.Clear();
            txtAPELLIDOPATERNOVPP.Clear();
            txtAPELLIDOPPRESIDENTE.Clear();
            txtCLAVEDELPARTIDO.Clear();
            txtNOMBREDELPARTIDO.Clear();
            txtNOMBREDELPRESIDENTE.Clear();
            txtNOMBREVICEPARTIDO.Clear();
        }
        private void generarPDF()
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Partidos políticos.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(9);
                PdfPCell Titulo = new PdfPCell(new Phrase("Catalogo de partidos"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 9;
                Table.AddCell(Titulo);
                Table.AddCell("Clave");
                Table.AddCell("Partido Politico");
                Table.AddCell("Representante");
                Table.AddCell("Apellido paterno");
                Table.AddCell("Apellido materno");
                Table.AddCell("Vicepresidente");
                Table.AddCell("Apellido paterno");
                Table.AddCell("Apellido materno");

                for (int i = 0; i < dgvPARTIDOS.Rows.Count; i++)
                {
                    Table.AddCell(dgvPARTIDOS[0, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[1, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[2, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[3, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[4, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[5, i].Value.ToString());
                    Table.AddCell(dgvPARTIDOS[6, i].Value.ToString());
                    //Table.AddCell(dgvPARTIDOS[12, i].Value.ToString());

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
            System.Diagnostics.Process.Start("Partidos políticos.pdf");
        }

        private void Partidos_Load(object sender, EventArgs e)
        {
            partidos();
        }
        private void btnAGREGAR_Click(object sender, EventArgs e)
        {
            ruta = ruta.Replace(@"\", @"\\");  
            if (p.registrarDatos(txtCLAVEDELPARTIDO.Text,txtNOMBREDELPARTIDO.Text,txtNOMBREDELPRESIDENTE.Text,
                txtAPELLIDOPPRESIDENTE.Text,txtAPELLIDOMPRESIDENTE.Text,txtNOMBREVICEPARTIDO.Text,
                txtAPELLIDOPATERNOVPP.Text,txtAPELLIDOMATERNOVPP.Text,pcBIMAGENPARTIDO.Text))
            {        
                Partidos_Load(sender, e);
                MessageBox.Show("Datos agregados!");
            }
            else { MessageBox.Show("ERROR al agregar información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }        
    }
        private void pcBIMAGENPARTIDO_Click(object sender, EventArgs e)
        {
            imagen();
        }
        private void dgvPARTIDOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCLAVEDELPARTIDO.Text = dgvPARTIDOS[0, e.RowIndex].Value.ToString();
                txtNOMBREDELPARTIDO.Text = dgvPARTIDOS[1, e.RowIndex].Value.ToString();
                txtNOMBREDELPRESIDENTE.Text = dgvPARTIDOS[2, e.RowIndex].Value.ToString();
                txtAPELLIDOPPRESIDENTE.Text = dgvPARTIDOS[3, e.RowIndex].Value.ToString();
                txtAPELLIDOMPRESIDENTE.Text = dgvPARTIDOS[4, e.RowIndex].Value.ToString();
                txtNOMBREVICEPARTIDO.Text = dgvPARTIDOS[5, e.RowIndex].Value.ToString();
                txtAPELLIDOPATERNOVPP.Text = dgvPARTIDOS[6, e.RowIndex].Value.ToString();
                txtAPELLIDOMATERNOVPP.Text = dgvPARTIDOS[7, e.RowIndex].Value.ToString();              
                try
                {
                    pcBIMAGENPARTIDO.Image = System.Drawing.Image.FromFile(dgvPARTIDOS[8, e.RowIndex].Value.ToString());
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());

                }
            }
        }
        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {
            ruta = ruta.Replace(@"\", @"\\");      
            if (p.modificarDatos(txtCLAVEDELPARTIDO.Text, txtNOMBREDELPARTIDO.Text, txtNOMBREDELPRESIDENTE.Text,
                txtAPELLIDOPPRESIDENTE.Text, txtAPELLIDOMPRESIDENTE.Text, txtNOMBREVICEPARTIDO.Text,
                txtAPELLIDOPATERNOVPP.Text, txtAPELLIDOMATERNOVPP.Text, ruta))
            {  
                Partidos_Load(sender, e);
                MessageBox.Show("Se modifico con exitó", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Error al modificar"); }
        }
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvPARTIDOS.SelectedCells[0].RowIndex;
            string pk = dgvPARTIDOS.Rows[ren].Cells[0].Value.ToString();
            if (p.eliminarDatos("partidos",pk))
            {
                Partidos_Load(sender, e);
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
            Partidos_Load(sender, e);            
        }
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            frmSesionAdministrador u = new frmSesionAdministrador();
            u.ShowDialog();
            this.Hide();
        }
        private void btnGENERARPDF_Click(object sender, EventArgs e)
        {
            generarPDF();
        }
        private void btnCANDIDATOS_Click(object sender, EventArgs e)
        {
            frmCandidatos u = new frmCandidatos();
            u.ShowDialog();
            this.Hide();
        }
    }
}
