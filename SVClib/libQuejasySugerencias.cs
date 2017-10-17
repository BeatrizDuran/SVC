using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libQuejasySugerencias
    {
        //CREANDO OBJETO PARA USAR LA CONEXION..............
        LaConexion BD = new LaConexion();
        //NUEVA QUEJA...........................
        public bool nuevaQueja(string NombreUsuario, string descripcion, string fecha)
        {
            return BD.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha) " +
                " VALUES ('" + NombreUsuario + "','" + descripcion + "','" + fecha + "');");
        }
        //ELIMINAR QUEJA.....................
        public bool eliminarQueja(string tablas, string condicion)
        {
            return BD.Eliminar("quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        }
        
    }
}
