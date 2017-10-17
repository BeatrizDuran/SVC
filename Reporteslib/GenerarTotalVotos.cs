using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;
using System.IO;
using MySql.Data.MySqlClient;

namespace Reporteslib
{
    public class GenerarTotalVotos
    {
        LaConexion bd = new LaConexion();
        public bool GenerarTotalVotos()
        {
            string path = "Reporte.html";
            File.Delete(path);
            using (StreamWriter SWbackup = File.CreateText(path))
            {
                SWbackup.WriteLine("<html><head>");
                SWbackup.WriteLine("<style>{table border-collapse:collapse;}td, th {border: 1px solid #dddddd; text - align: left;padding: 8px; } ");
                SWbackup.WriteLine("</style>");
                SWbackup.WriteLine("</head><body>");
                SWbackup.WriteLine("<h1>Reporte de Votos</h1>");
                SWbackup.WriteLine("<table>");
                SWbackup.WriteLine("<tr><th>Total de votantes</th></tr>");
                bd.con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=siqueirosuth19;database=svc");
                bd.con.Open();
                string query = "SELECT count(idvotos) FROM registro_votos";
                bd.comd = new MySqlCommand(query, bd.con);
                bd.Dr = bd.comd.ExecuteReader();
                while (bd.Dr.Read())
                {
                    SWbackup.WriteLine("<tr><td>" + bd.Dr.GetString(2) + "</td><tr>");
                }
                bd.con.Close();
                SWbackup.WriteLine("</table>");
                SWbackup.WriteLine("</body></html>");
            }
            webBrowser1.Url = new Uri(Directory.GetCurrentDirectory() + "/" + path);
            return GenerarTotalVotos();
        }
    }
}
