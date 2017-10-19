using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libCandidatos
    {
        ConnectionMySql bd = new ConnectionMySql();
        //AGREGAR REGISTRO.....................
        public bool registroCandidatos(string idcandidato, string nombre, string AP, string AM,
            string claveelector, string niveleleccion, string tipopuesto, string clavepartido)
        {
            return bd.insertar("partidos_candidatos","idCandidato,CandidatoNombre," +
                "CandidatoApeP,CandidatoApeM,ClaveElector,NivelEleccion,TipoPuesto,ClavePartido",
                "idCandidato="+idcandidato+",CandidatoNombre="+nombre+"," +
                "CandidatoApeP="+AP+",CandidatoApeM="+AM+",ClaveElector="+claveelector+","+
                "NivelEleccion="+niveleleccion+",TipoPuesto="+tipopuesto+",ClavePartido="+clavepartido+"");
        }
        //MODIFICAR REGISTRO..................
        public bool modificarRegistro(string idcandidato, string nombre, string AP, string AM,
            string claveelector, string niveleleccion, string tipopuesto, string clavepartido)
        {
            return bd.modificar("partidos_candidatos", "idCandidato='" + idcandidato +
                "', CandidatoNombre='" + nombre + "', CandidatoApeP='" + AP +
                "', CandidatoApeM='" + AM + "', ClaveElector='" + claveelector +
                "', nivelEleccion='" + niveleleccion +
                "',TipoPuesto='" + tipopuesto + "',ClavePartido='" + clavepartido + "'", "idCandidato='" + idcandidato + ";");
        }
        ////ELIMINAR REGISTRO...................
        public bool eliminarRegistro(string tabla, string condicion)
        {
            return bd.eliminar("partidos_candidatos", "idCandidato='" + condicion + "'");
        }
    }
}
