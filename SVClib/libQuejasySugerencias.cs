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
        //hhhhhhhhhhhhhh
        /// <summary>
        /// Conexion con MySQL
        /// </summary>
        ConnectionMySql BD = new ConnectionMySql();
        /// <summary>
        /// Agregar quejas.....
        /// </summary>
        /// <param name="NombreUsuario">nombre del usuario</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha en la que e genero la queja</param>
        /// <returns></returns>
        public bool nuevaQueja(string NombreUsuario, string descripcion, string fecha)
        {
            return BD.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha) " +
                " VALUES ('" + NombreUsuario + "','" + descripcion + "','" + fecha + "');");
        }
        /// <summary>
        /// Eliminar queja o sugerencia
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">condicion de la cual se quiere eliminar</param>
        /// <returns></returns>
        public bool eliminarQueja(string tablas, string condicion)
        {
            return BD.eliminar("quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        }

        /// <summary>
        /// Conexion con SQLServer
        /// </summary>
        ConnectionSQLServer sql = new ConnectionSQLServer();
        /// <summary>
        /// Generar nueva queja
        /// </summary>
        /// <param name="nomusuario">nombre dle usuario ya sea anonimo o como prefiera</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha de la queja</param>
        /// <returns></returns>
        public bool nuevaQuejasql(string nomusuario, string descripcion, string fecha)
        {
            return sql.insertar("INSERT INTO dbo.quejas_sugerencias (NombreUsuario,Descripcion,Fecha) " +
               " VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "');");
        }
    }
}
