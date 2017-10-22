using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libCasillas
    {
        ConnectionMySql BD = new ConnectionMySql();
        //REGISTRAR LOS DATOS................
        public bool registrarCasilla(string claveCasilla, string colonia, string direccion,
            string codigoPostal, string NomPresidente, string NomSecretario, string NomPrimerEscrutador,
            string NomSegundoEscrutador, string NomPrimerSuplente, string NomSegundoSuplente, string NomTercerSuplente)
        {
            return BD.insertar("INSERT INTO casillas (ClaveCasilla, ColoniaCasilla, DireccionCasilla," +
              " CodigoPostalCasilla,NomPresidente,NomSecretario,NomPrimerEscrutador,NomSegundoEscrutador," +
              " NomPrimerSuplente,NomSegundoSuplente,NomTercerSuplente) VALUES ('"+claveCasilla+"','"+
              "'"+colonia+"','"+direccion+"','"+codigoPostal+"','"+NomPresidente+"','"+NomSecretario+"','"+
              "'"+NomPrimerEscrutador+"','"+NomSegundoEscrutador+"','" +
              "'"+NomPrimerSuplente+"','"+NomSegundoSuplente+"','"+NomTercerSuplente+"')");
        }
        //MODIFICAR LOS DATOS.............
        public bool modificarCasilla(string claveCasilla, string colonia, string direccion,
            string codigoPostal, string NomPresidente, string NomSecretario, string NomPrimerEscrutador,
            string NomSegundoEscrutador, string NomPrimerSuplente, string NomSegundoSuplente, string NomTercerSuplente)
        {
            return BD.modificar("casillas", "ClaveCasilla='" + claveCasilla + "',ColoniaCasilla='" + colonia + "',DireccionCasilla='"+ direccion + "',CodigoPostalCasilla='"
                + codigoPostal + "',NomPresidente='" + NomPresidente + "',NomSecretario='" + NomSecretario + "',NomPrimerEscrutador='" + NomPrimerEscrutador + "',NomSegundoEscrutador='"
                + NomSegundoEscrutador + "', NomPrimerSuplente='" + NomPrimerSuplente + "',NomSegundoSuplente='" + NomSegundoSuplente + "',NomTercerSuplente='"
                + NomTercerSuplente +"'","ClaveCasilla='"+claveCasilla+"';");
        }
        //ELIMINAR DATOS...............
        public bool eliminarDatos(string tabla, string condicion)
        {
            return BD.eliminar("casillas", "ClaveCasilla='" + condicion + "'");
        }
    }
}
