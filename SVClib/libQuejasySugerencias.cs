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
        
        /// <summary>
        /// Conexion con MySQL
        /// </summary>
        ConnectionMySql BD = new ConnectionMySql();
        public string error;
        /// <summary>
        /// Agregar quejas.....
        /// </summary>
        /// <param name="NombreUsuario">nombre del usuario</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha en la que e genero la queja</param>
        /// <returns></returns>
        public bool nuevaQuejaMysql(string nomusuario, string descripcion, string fecha)
        {
            return BD.insertar("quejas_sugerencias", "NombreUsuario,Descripcion,Fecha", "'" + nomusuario + "','" + descripcion + "','" + fecha + "'");
           
        }
        /// <summary>
        /// Eliminar queja o sugerencia
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">condicion de la cual se quiere eliminar</param>
        /// <returns></returns>
        public bool eliminarQuejaMysql(string tablas, string condicion)
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
            return sql.insertar("dbo.quejas_sugerencias","NombreUsuario,Descripcion,Fecha","'"+nomusuario+"','"+ descripcion+"','"+fecha+"'");
        }
        /// <summary>
        /// Eliminacion de la queja
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">dato del cual se quiere eliminar</param>
        /// <returns></returns>
        public bool eliminarQuejasql(string tablas, string condicion)
        {
            return sql.eliminar("[dbo].[quejas_sugerencias]", "NombreUsuario='" + condicion + "'");
        }

        /// <summary>
        /// Conexion con postgres
        /// </summary>
        ConnectionPostgres pg = new ConnectionPostgres();
        /// <summary>
        /// Agregando datos
        /// </summary>
        /// <param name="nomusuario">nombre de la persona ya sea anonima</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha en el cual se registro</param>
        /// <returns></returns>
        public bool nuevaQuejapg(string nomusuario, string descripcion, string fecha)
        {
            return pg.insertar("public.quejas_sugerencias", " NombreUsuario,Descripcion,fecha ", " '" + nomusuario + "','"+descripcion+"','" + fecha+"' ");
        }
        /// <summary>
        /// Eliminando registro con postgres
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">parametro el cual se desea eliminar(dato en especifico)</param>
        /// <returns></returns>
        public bool eliminarQuejapg(string tablas, string condicion)
        {
            return pg.eliminar("public.quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        }
    }
}
