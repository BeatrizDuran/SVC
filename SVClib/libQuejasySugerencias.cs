using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;
using System.Threading;
using System.IO;

namespace SVClib
{
    public class libQuejasySugerencias
    {
        //    Semaphore sm = new Semaphore(1, 2);
        //    static object obj = new object();
        //    public bool TimeStamp(string valor)
        //    {
        //        Monitor.Enter(obj);
        //        bool status = false;
        //        using (StreamWriter sw = new StreamWriter(@"C:\HilosBaseDeDatos.txt", true))
        //        {
        //            sw.WriteLine(valor);
        //        }
        //        Monitor.Exit(obj);
        //        return status;
        //    }
        /// <summary>
        /// Conexion con MySQL
        /// </summary>
        ServidoresBD BDS = new ServidoresBD();
        ConnectionMySql mysql = new ConnectionMySql();
       //public void insertar()
       // {
       //     sm.WaitOne(10);
       //     bool nuevaQuejaMysql(string nomusuario, string descripcion, string fecha)
       //     {
       //         return mysql.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha) " +
       //             "VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "');");
       //     }
       //     TimeStamp("Fin del Hilo Mysql insertar: " + DateTime.Now.ToLocalTime().ToString());
       //     sm.Release();
       // }
       //public void eliminar()
       // {
       //     sm.WaitOne(10);
       //     bool eliminarQuejaMysql(string tablas, string condicion)
       //     {
       //         return mysql.eliminar("quejas_sugerencias", "NombreUsuario='" + condicion + "'");
       //     }
       //     TimeStamp("Fin del hilo eliminar Mysql: " + DateTime.Now.ToLocalTime().ToString());
       //     sm.Release();
       // }
       //public void insertHiloMysql()
       // {
       //     Thread mysqlhilo = new Thread(new ThreadStart(insertar));
       //     mysqlhilo.Start();
       // }
       // public void eliminarHiloMysql()
       // {
       //     Thread eliminarMysql = new Thread(new ThreadStart(eliminar));
       //     eliminarMysql.Start();
       // }
        /// <summary>
        /// Agregar quejas.....
        /// </summary>
        /// <param name="NombreUsuario">nombre del usuario</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha en la que e genero la queja</param>
        /// <returns></returns>
       public bool nuevaQuejaMysql(string nomusuario, string descripcion, string fecha)
        {
            return mysql.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha) " +
                "VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "');");
        }
        /// <summary>
        /// Eliminar queja o sugerencia
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">condicion de la cual se quiere eliminar</param>
        /// <returns></returns>
        public bool eliminarQuejaMysql(string tablas, string condicion)
        {
            return mysql.eliminar("quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        }

        /// <summary>
        /// Conexion con SQLServer
        /// </summary>
        ConnectionSQLServer sql = new ConnectionSQLServer();
        //public void insertarSQL()
        //{
        //    sm.WaitOne(10);
        //    bool nuevaQuejasql(string nomusuario, string descripcion, string fecha)
        //    {
        //        return sql.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha)" +
        //            "VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "')");
        //    }
        //    TimeStamp("Fin del hilo SQLServer eliminar: " + DateTime.Now.ToLocalTime().ToString());
        //    sm.Release();
        //}
        //public void insertHiloSQL()
        //{
        //    Thread insertsql = new Thread(new ThreadStart(insertarSQL));
        //    insertsql.Start();
        //}
        //public void eliminarSQL()
        //{
        //    sm.WaitOne(10);
        //    bool eliminarQuejasql(string tablas, string condicion)
        //    {
        //        return sql.eliminar("dbo.quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        //    }
        //    TimeStamp("Fin del hilo SQLServer eliminar: " + DateTime.Now.ToLocalTime().ToString());
        //    sm.Release();
        //}
        //public void eliminarHiloSQL()
        //{
        //    Thread deleteSQL = new Thread(new ThreadStart(eliminarSQL));
        //    deleteSQL.Start();
        //}
        /// <summary>
        /// Generar nueva queja
        /// </summary>
        /// <param name="nomusuario">nombre dle usuario ya sea anonimo o como prefiera</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha de la queja</param>
        /// <returns></returns>
        public bool nuevaQuejasql(string nomusuario, string descripcion, string fecha)
        {
            return sql.insertar("INSERT INTO quejas_sugerencias (NombreUsuario,Descripcion,Fecha)" +
                "VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "')");
        }
        /// <summary>
        /// Eliminacion de la queja
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">dato del cual se quiere eliminar</param>
        /// <returns></returns>
        public bool eliminarQuejasql(string tablas, string condicion)
        {
            return sql.eliminar("dbo.quejas_sugerencias", "NombreUsuario='" + condicion + "'");
        }

        /// <summary>
        /// Conexion con postgres
        /// </summary>
        ConnectionPostgres pg = new ConnectionPostgres();
        //public void insertpg()
        //{
        //    sm.WaitOne(10);
        //     bool nuevaQuejapg(string nomusuario, string descripcion, string fecha)
        //    {
        //        return pg.insertar("INSERT INTO quejas_sugerencias " +
        //            "VALUES ('" + nomusuario + "','" + descripcion + "','" + fecha + "')");
        //    }
        //    TimeStamp("Fin del hilo Postgres insertar : " + DateTime.Now.ToLocalTime().ToString());
        //    sm.Release();
        //}
        //public void insertHilopg()
        //{
        //    Thread hilopg = new Thread(new ThreadStart(insertpg));
        //    hilopg.Start();
        //}
        //public void eliminarpg()
        //{
        //    sm.WaitOne(10);
        //     bool eliminarQuejapg(string tablas, string condicion)
        //    {
        //        return pg.eliminar("quejas_sugerencias", "nombreusuario='" + condicion + "'");
        //    }
        //    TimeStamp("Fin del hilo Postgres eliminar: " + DateTime.Now.ToLocalTime().ToString());
        //    sm.Release();
        //}
        //public void eliminarHilopg()
        //{
        //    Thread hilopg = new Thread(new ThreadStart(eliminarpg));
        //    hilopg.Start();
        //}
        /// <summary>
        /// Agregando datos
        /// </summary>
        /// <param name="nomusuario">nombre de la persona ya sea anonima</param>
        /// <param name="descripcion">descripcion de la queja o sugerencia</param>
        /// <param name="fecha">fecha en el cual se registro</param>
        /// <returns></returns>
        public bool nuevaQuejapg(string nomusuario, string descripcion, string fecha)
        {
            return pg.insertar("INSERT INTO quejas_sugerencias "+
                "VALUES ('"+ nomusuario + "','"+descripcion+"','" + fecha+"')");
        }
        /// <summary>
        /// Eliminando registro con postgres
        /// </summary>
        /// <param name="tablas">nombre de la tabla</param>
        /// <param name="condicion">parametro el cual se desea eliminar(dato en especifico)</param>
        /// <returns></returns>
        public bool eliminarQuejapg(string tablas, string condicion)
        {
            return pg.eliminar("quejas_sugerencias", "nombreusuario='" + condicion + "'");
        }

    }
}
