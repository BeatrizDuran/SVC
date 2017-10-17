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

namespace SVC
{
    public partial class frmUsuarios : Form
    {
        LaConexion BD = new LaConexion();
        libUsuarios u =new libUsuarios();       
        public void administrador()
        {
            txtCLAVE.Enabled = true;
            cbUSUARIOOTRO.Enabled = true;
        }
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void btnSALIR_Click_1(object sender, EventArgs e)
        {
            frmSesionAdministrador u = new frmSesionAdministrador();         
            u.ShowDialog();
            this.Hide();
        }
        private void btnAGREGAR_Click(object sender, EventArgs e)
        {                       
          int edad = Convert.ToInt16(mtxtEDAD.Text);
          if (edad >= 18)
          {
                if (u.registroUsuario(txtNOMBRES.Text, txtAPELLIDOPATERNO.Text,
                txtAPELLIDOMATERNO.Text, txtCLAVEELECTOR.Text, txtNACIONALIDAD.Text,
                cbDIA.Text, cbMES.Text, mtxtYEAR.Text, mtxtEDAD.Text, txtDIRECCION.Text,
                cbTIPOUSUARIO.Text, txtPASSWORD.Text, cbUSUARIOOTRO.Text, txtCLAVE.Text))
                {
                    USUARIOS_Load(sender, e);
                    MessageBox.Show("Datos agregados!");
                }else { MessageBox.Show("Tiene que ser mayor a 18 años"); }
               
            }
            else { MessageBox.Show("Tiene que ser mayor a 18 años","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
        private void dgvUSUARIOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtNOMBRES.Text = dgvUSUARIOS[0, e.RowIndex].Value.ToString();
                txtAPELLIDOPATERNO.Text = dgvUSUARIOS[1, e.RowIndex].Value.ToString();
                txtAPELLIDOMATERNO.Text = dgvUSUARIOS[2, e.RowIndex].Value.ToString();
                txtCLAVEELECTOR.Text = dgvUSUARIOS[3, e.RowIndex].Value.ToString();
                txtNACIONALIDAD.Text = dgvUSUARIOS[4, e.RowIndex].Value.ToString();
                cbDIA.Text = dgvUSUARIOS[5, e.RowIndex].Value.ToString();
                cbMES.Text = dgvUSUARIOS[6, e.RowIndex].Value.ToString();
                mtxtYEAR.Text = dgvUSUARIOS[7, e.RowIndex].Value.ToString();
                mtxtEDAD.Text = dgvUSUARIOS[8, e.RowIndex].Value.ToString();
                txtDIRECCION.Text = dgvUSUARIOS[9, e.RowIndex].Value.ToString();
                cbTIPOUSUARIO.Text = dgvUSUARIOS[10, e.RowIndex].Value.ToString();
                cbUSUARIOOTRO.Text = dgvUSUARIOS[12, e.RowIndex].Value.ToString();
            }
        }
        private void USUARIOS_Load(object sender, EventArgs e)
        {
            dgvUSUARIOS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM usuarios";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            string usuario = null;
            string pass = null;
            while (BD.Dr.Read())
            {
                usuario = (BD.Dr.IsDBNull(12) == true ? "..." : BD.Dr.GetString(12));
                if (BD.Dr.IsDBNull(13))
                {
                    pass = (BD.Dr.IsDBNull(13) == true ? "..." : BD.Dr.GetString(13));
                    if (BD.Dr.IsDBNull(13))
                    {
                        dgvUSUARIOS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1),
                        BD.Dr.GetString(2), BD.Dr.GetString(3), BD.Dr.GetString(4),
                        BD.Dr.GetString(5), BD.Dr.GetString(6), BD.Dr.GetString(7),
                        BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                       BD.Dr.GetString(11), usuario, pass);
                    }
                }
                else
                {
                    dgvUSUARIOS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1),
                    BD.Dr.GetString(2), BD.Dr.GetString(3), BD.Dr.GetString(4),
                    BD.Dr.GetString(5), BD.Dr.GetString(6), BD.Dr.GetString(7),
                    BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                   BD.Dr.GetString(11), BD.Dr.GetString(12), BD.Dr.GetString(13));
                }
            }
            BD.con.Close();
        }
        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {         
            if (u.modificarUsuario(txtNOMBRES.Text,txtAPELLIDOPATERNO.Text,txtAPELLIDOMATERNO.Text,txtCLAVEELECTOR.Text,
               txtNACIONALIDAD.Text,cbDIA.Text,cbMES.Text,mtxtYEAR.Text,mtxtEDAD.Text,txtDIRECCION.Text,cbTIPOUSUARIO.Text,
               txtPASSWORD.Text,cbUSUARIOOTRO.Text,txtCLAVE.Text))
            {
                USUARIOS_Load(sender, e);
                MessageBox.Show("Se modifico con exitó", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Error al modificar"); }
        }
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            int ren = dgvUSUARIOS.SelectedCells[3].RowIndex;
            string pk = dgvUSUARIOS.Rows[ren].Cells[3].Value.ToString();
            if (u.eliminarUsuario("Usuarios", pk))
            {
                USUARIOS_Load(sender, e);
                MessageBox.Show("Registro Eliminado");
            }
            else { MessageBox.Show("Error al eliminar"+pk); }
        }
        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            txtCLAVE.Clear();
            txtAPELLIDOPATERNO.Clear();
            txtAPELLIDOMATERNO.Clear();
            txtCLAVEELECTOR.Clear();
            txtDIRECCION.Clear();
            txtNACIONALIDAD.Clear();
            txtNOMBRES.Clear();
            txtPASSWORD.Clear();
            mtxtEDAD.Clear();
            mtxtYEAR.Clear();
            cbDIA.Text = "";
            cbMES.Text = "";
            cbTIPOUSUARIO.Text = "";
            cbUSUARIOOTRO.Text = "";
            USUARIOS_Load(sender, e);
        }
        private void btnGENERARPDF_Click(object sender, EventArgs e)
        {
            Document pdf = new Document(PageSize.LETTER.Rotate());
            try
            {
                PdfWriter.GetInstance(pdf, new FileStream("Usuarios.pdf", FileMode.Create));
                pdf.Open();
                //Inicio de la generacion del pdfe
                PdfPTable Table = new PdfPTable(10);
                PdfPCell Titulo = new PdfPCell(new Phrase("Catalogo de usuarios"));
                Titulo.HorizontalAlignment = 1;
                Titulo.Colspan = 10;
                Table.AddCell(Titulo);
                Table.AddCell("Nombres");
                Table.AddCell("Apellido Paterno");
                Table.AddCell("Apellido Materno");
                Table.AddCell("Clave Elector");
                Table.AddCell("Nacionalidad");
                Table.AddCell("Dia Nac.");
                Table.AddCell("Mes Nac.");
                Table.AddCell("Año Nac.");
                Table.AddCell("Edad");
                Table.AddCell("Dirección");

                for (int i = 0; i < dgvUSUARIOS.Rows.Count; i++)
                {
                    Table.AddCell(dgvUSUARIOS[0, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[1, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[2, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[3, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[4, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[5, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[6, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[7, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[8, i].Value.ToString());
                    Table.AddCell(dgvUSUARIOS[9, i].Value.ToString());
                    
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
            System.Diagnostics.Process.Start("Usuarios.pdf");
        }
        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
            dgvUSUARIOS.Rows.Clear();
            BD.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            BD.con.Open();
            string query = "SELECT * FROM USUARIOS WHERE ClaveElector='"+txtCLAVEELECTOR.Text+"' OR Nombre='"+txtNOMBRES.Text+"'";
            BD.comd = new MySqlCommand(query, BD.con);
            BD.Dr = BD.comd.ExecuteReader();
            while (BD.Dr.Read())
            {
                dgvUSUARIOS.Rows.Add(BD.Dr.GetString(0), BD.Dr.GetString(1), BD.Dr.GetString(2), 
                    BD.Dr.GetString(3), BD.Dr.GetString(4), BD.Dr.GetString(5), BD.Dr.GetString(6),
                   BD.Dr.GetString(7), BD.Dr.GetString(8), BD.Dr.GetString(9), BD.Dr.GetString(10),
                    BD.Dr.GetString(11), BD.Dr.GetString(12));
            }
            BD.con.Close();
        }   
    }
}
