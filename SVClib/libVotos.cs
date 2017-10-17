using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libVotos
    {
        //REALIZAR LA CONEXIÓN......................
         ConnectionMySql BD = new ConnectionMySql();
        //REGISTRAR DATOS.................
        public bool registroVoto(string claveelector, string tipopuesto,string idcandidato)
        {
            return BD.insertar("INSERT INTO registro_votos(idVotos,TipoPuesto,idCandidato) " +
                " VALUES ('" + claveelector+ "','" + tipopuesto + "','"+idcandidato+"');");
        } 
    }
}
