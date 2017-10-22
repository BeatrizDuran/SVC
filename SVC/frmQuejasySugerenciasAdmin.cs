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
using System.Data.SqlClient;
using Npgsql;
namespace SVC
{
    public partial class frmQuejasySugerenciasAdmin : Form
    {
        ConnectionPostgres pg = new ConnectionPostgres();
        ConnectionMySql c = new ConnectionMySql();
        ConnectionSQLServer sql = new ConnectionSQLServer();
        libQuejasySugerencias q = new libQuejasySugerencias();
       
        public frmQuejasySugerenciasAdmin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Métodos que permite la realizacion de las acciones en cada boton
        /// </summary>
        private void mysql_load()
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
        private void sql_load()
        {
            sql.con = new SqlConnection("Data Source=BEATRIZDURAN-PC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=SVC");
            sql.con.Open();
            string q = "SELECT * FROM quejas_sugerencias";
            sql.comd = new SqlCommand(q, sql.con);
            sql.Dr = sql.comd.ExecuteReader();
            while (sql.Dr.Read())
            {
                dgvQYS.Rows.Add(sql.Dr.GetString(0), sql.Dr.GetString(1), sql.Dr.GetString(2));
            }
            sql.con.Close();
        }
        private void mysql_eliminar()
        {
            int ren = dgvQYS.SelectedCells[0].RowIndex;
            string pk = dgvQYS.Rows[ren].Cells[0].Value.ToString();
            if (q.eliminarQuejaMysql("quejas_sugerencias", pk))
            {
                MessageBox.Show("Todo bien");
            }
            else
            {
                MessageBox.Show("Noooo");
            }
        }
        private void sql_eliminar()
        {
            int ren = dgvQYS.SelectedCells[0].RowIndex;
            string pk = dgvQYS.Rows[ren].Cells[0].Value.ToString();
            if (q.eliminarQuejasql("quejas_sugerencias", pk))
            {
                MessageBox.Show("Todo bien sql");
            }
            else
            {
                MessageBox.Show("Noooo");
            }
        }
        private void mysql_buscar()
        {
            dgvQYS.Rows.Clear();
            c.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=SVC");
            c.con.Open();
            string query = "SELECT * FROM quejas_sugerencias WHERE Fecha='" + txtFECHA.Text + "'";
            c.comd = new MySqlCommand(query, c.con);
            c.Dr = c.comd.ExecuteReader();
            while (c.Dr.Read())
            {
                dgvQYS.Rows.Add(c.Dr.GetString(0), c.Dr.GetString(1), c.Dr.GetString(2));
            }
            c.con.Close();
        }
        private void sql_buscar()
        {
            dgvQYS.Rows.Clear();
            sql.con = new SqlConnection("Data Source=BEATRIZDURAN-PC;Integrated Security=SSPI;Initial Catalog=SVC");
            sql.con.Open();
            string query1 = "SELECT * FROM quejas_sugerencias WHERE Fecha='" + txtFECHA.Text + "'";
            sql.comd = new SqlCommand(query1, sql.con);
            sql.Dr = sql.comd.ExecuteReader();
            while (sql.Dr.Read())
            {
                dgvQYS.Rows.Add(sql.Dr.GetString(0), sql.Dr.GetString(1), sql.Dr.GetString(2));
            }
            sql.con.Close();
        }
        private void pg_eliminar()
        {
            int ren = dgvQYS.SelectedCells[0].RowIndex;
            string pk = dgvQYS.Rows[ren].Cells[0].Value.ToString();
            if (q.eliminarQuejapg("quejas_sugerencias",pk))
            {
                MessageBox.Show("Todo bien");
            }
            else
            {
                MessageBox.Show("Noooo");
            }
        }
        private void pg_buscar()
        {
            dgvQYS.Rows.Clear();
            pg.con1 = new NpgsqlConnection("Server=127.0.0.1; Port=5432; User id= postgres; Password=siqueirosuth19; Database=SVC");
            pg.con1.Open();
            string quer = "SELECT * FROM public.quejas_sugerencias WHERE fecha='" + txtFECHA.Text + "';";
                pg.comd = new NpgsqlCommand(quer, pg.con1);
                pg.Dr = pg.comd.ExecuteReader();
                while (pg.Dr.Read())
                {
                    dgvQYS.Rows.Add(pg.Dr.GetValue(0).ToString(), pg.Dr.GetValue(1).ToString(), pg.Dr.GetValue(2).ToString());
                }
                pg.Dr.Close();
            
           pg.con1.Close();
        }
        private void pg_Load()
        {
            pg.con1 = new NpgsqlConnection("Server=127.0.0.1; Port=5432; User id= postgres; Password=siqueirosuth19; Database=SVC");
            pg.con1.Open();
            string quer = "SELECT * FROM quejas_sugerencias";
            pg.comd = new NpgsqlCommand(quer, pg.con1);
            pg.Dr = pg.comd.ExecuteReader();
            if (pg.Dr.HasRows == true)
            {
                while (pg.Dr.Read())
                {
                    dgvQYS.Rows.Add(pg.Dr.GetValue(0).ToString(), pg.Dr.GetValue(1).ToString(), pg.Dr.GetValue(2).ToString());
                }
            }
            pg.con1.Close();
        }

        private void QYS_Load(object sender, EventArgs e)
        {
           // mysql_load();
           // sql_load();
            pg_Load();
        }
        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
          // mysql_eliminar();
            //sql_eliminar();
          pg_eliminar();
        }
        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
          // mysql_buscar();
          //sql_buscar();
          pg_buscar();
        }
        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            txtFECHA.Clear();
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
