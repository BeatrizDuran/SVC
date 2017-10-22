using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libUsuarios
    {
        //CREANDO OBJETO PARA UTILIZAR LA CONEXIÓN.............
        ConnectionMySql BD = new ConnectionMySql();
        //REGISTRAR USUARIO..........................
        public bool registroUsuario(string nombre, string AP, string AM, string
            claveeelector, string nac, string FeDia, string FeMes, string Feyear,
            string edad, string direccion, string tipousuario, string pass,
            string otrousuario, string passotro)
        {
            return BD.insertar("INSERT INTO usuarios (Nombre,ApellidoP,ApellidoM,ClaveElector," +
                "Nacionalidad, FechaDia,FechaMes,FechaYear,Edad,Direccion,TipoUsuario, " +
                "PasswordCiudadano, AsignarUsuario, PasswordOtro) VALUES ('"+nombre+"','"+AP+"',"+
                "'"+AM+"','"+claveeelector+"','"+nac+"','"+FeDia+"','"+FeMes+"','"+Feyear+"','"+
                "'"+edad+"','"+direccion+"','"+tipousuario+"','"+pass+"','"+otrousuario+"','"+passotro+"')");
        }
        //MODIFICAR USUARIO......................
        public bool modificarUsuario(string nombre, string AP, string AM, string
            claveeelector, string nac, string FeDia, string FeMes, string Feyear,
            string edad, string direccion, string tipousuario, string pass,
            string otrousuario, string passotro)
        {
            return BD.modificar("Usuarios","Nombre='"+nombre+
                "', ApellidoP='"+AP+"', ApellidoM='"+AM+
                "', ClaveElector='"+claveeelector+"', Nacionalidad='"+nac+
                "', FechaDia='"+FeDia+"',FechaMes='"+FeMes+ "', FechaYear='"+Feyear+
                "', Edad='"+edad+"', Direccion='"+direccion+"',TipoUsuario='"+tipousuario+
                "', PasswordCiudadano='"+pass+ "', AsignarUsuario='"+otrousuario+
                "', PasswordOtro='"+passotro+"'","ClaveElector='"+claveeelector+"';");          
        }
        //ELIMINAR USUARIO.......................
        public bool eliminarUsuario(string tabla, string condicion)
        {
            return BD.eliminar("Usuarios", "ClaveElector='" + condicion + "'");
        }
    }
}
