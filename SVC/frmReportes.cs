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
using System.IO;
using Microsoft.Reporting.WinForms;
namespace SVC
{
    public partial class frmReportes : Form
    {
        ConnectionMySql bd = new ConnectionMySql();
        public static frmReportes _instanceReportes;
        public frmReportes()
        {
            InitializeComponent();
        }
        public frmReportes instance
        {
            get
            {
                if (frmReportes._instanceReportes == null)
                {
                    frmReportes._instanceReportes = new frmReportes();
                }
                return frmReportes._instanceReportes;
            }
        }
        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.quejas_sugerencias' Puede moverla o quitarla según sea necesario.
            this.quejas_sugerenciasTableAdapter.Fill(this.dataSet1.quejas_sugerencias);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.quejas_sugerencias' Puede moverla o quitarla según sea necesario.
            this.reportViewer1.RefreshReport();
        }

        private void btnTOTALVOTANTES_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTOTALVOTOS_Click(object sender, EventArgs e)
        {
            //string path = "Reporte.html";
            //File.Delete(path);
            //using (StreamWriter SWbackup = File.CreateText(path))
            //{
            //    SWbackup.WriteLine("<html><head>");
            //    SWbackup.WriteLine("<style>{table border-collapse:collapse;}td, th {border: 1px solid #dddddd; text - align: left;padding: 8px; } ");
            //    SWbackup.WriteLine("</style>");
            //    SWbackup.WriteLine("</head><body>");
            //    SWbackup.WriteLine("<h1>Reporte de Votos</h1>");
            //    SWbackup.WriteLine("<table>");
            //    SWbackup.WriteLine("<tr><th>Total de votos</th></tr>");
            //    bd.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=svc");
            //    bd.con.Open();
            //    string query = "SELECT sum(idCandidato) FROM registro_votos";
            //    bd.comd = new MySqlCommand(query, bd.con);
            //    bd.Dr = bd.comd.ExecuteReader();
            //    while (bd.Dr.Read())
            //    {
            //        SWbackup.WriteLine("<tr><td>" + bd.Dr.GetString(0) +"</td><tr>");
            //    }
            //    bd.con.Close();
            //    SWbackup.WriteLine("</table>");
            //    SWbackup.WriteLine("</body></html>");
            //}
            //webBrowser1.Url = new Uri(Directory.GetCurrentDirectory() + "/" + path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSesionAdministrador u = new frmSesionAdministrador();
            u.ShowDialog();
            this.Hide();
        }

       
    }
}
