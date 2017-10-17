using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libMesaDirectiva
    {
        LaConexion BD = new LaConexion();
        //AGREGAR DATOS.................................
        public bool registrarDatos(string clave, string direccion, string nomPresidente, 
            string cPresidente, string nomSecretario, string cSecretario, string PEscrutador,
            string cPEscrutador, string SEcrutador, string cSEscrutador, string PSuplente, 
            string cPSuplente, string SSuplente, string cSSuplente, string TSuplente,string cTSuplente)
        {
            return BD.insertar("INSERT INTO mesa_directiva (ClaveMesa,Dirección,NomPresidente,"+
                "CPresidente,NomSecretario,CSecretario,NomPEscrutador,CPEscrutador,NomSEscrutador,"+
                "CSEscrutador,NomPSuplente,CPSuplente,NomSSuplente,CSSuplente,NomTSuplente,"+
                "CTSuplente) VALUES ('"+clave+"','"+direccion+"','"+nomPresidente+"','"+cPresidente+ "','"
                +nomSecretario+"','"+cSecretario+"','"+PEscrutador+"','"+cPEscrutador +"','"
                +SEcrutador+"','"+cSEscrutador+"','"+PSuplente+"','"+cPSuplente+"','"+SSuplente+"','"
                +cSSuplente+"','"+TSuplente+"','"+cTSuplente+"');");
        }
        //MODIFICAR DATOS....................
        public bool modificarDatos(string clave, string direccion, string nomPresidente,
            string cPresidente, string nomSecretario, string cSecretario, string PEscrutador,
            string cPEscrutador, string SEcrutador, string cSEscrutador, string PSuplente,
            string cPSuplente, string SSuplente, string cSSuplente, string TSuplente, string cTSuplente)
        {
            return BD.modificar("mesa_directiva", "ClaveMesa='"+ clave + "',Dirección='" + direccion + 
                "',NomPresidente='" + nomPresidente + "',CPresidente='" + cPresidente + 
                "',NomSecretario='" + nomSecretario + "',CSecretario='" + cSecretario + 
                "',NomPEscrutador='" + PEscrutador + "',CPEscrutador='" + cPEscrutador + 
                "',NomSEscrutador='"+ SEcrutador + "',CSEscrutador='" + cSEscrutador + 
                "',NomPSuplente='" + PSuplente + "',CPSuplente='" + cPSuplente + 
                "',NomSSuplente='" + SSuplente + "',CSSuplente='" + cSSuplente + 
                "',NomTSuplente='" + TSuplente + "',CTSuplente='"+cTSuplente+"'", "ClaveMesa='" + clave + "';");
        }
        //ELIMINAR DATOS.......................
        public bool eliminarDatos(string tabla, string condicion)
        {
            return BD.Eliminar("mesa_directiva", "ClaveMesa='" + condicion + "'");
        }
    }
}
