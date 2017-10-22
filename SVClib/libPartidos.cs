using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConnection;

namespace SVClib
{
    public class libPartidos
    {
        ConnectionMySql BD = new ConnectionMySql();
        //AGREGAR DATOS......................
        public bool registrarDatos(string clave, string partido, string nomRepresentante,
            string APRepresentante, string AMRepresentante, string nomVPresidente,
            string APVPresidente, string AMVPresidente, string imagen)
        {
            return BD.insertar("INSERT INTO partidos (ClavePartido,NomPartido,NomRepresentante," +
               " APRepresentante, AMRepresentante, NomVicepresidente, APVicepresidente, AMVicepresidente," +
              " Imagen) VALUES ('"+clave+"','"+partido+"','"+nomRepresentante+"," +
               "'"+APRepresentante+"','"+AMRepresentante+"','" +
               "'"+nomVPresidente+"','"+APVPresidente+"','"+AMVPresidente+"','" +
              "'"+imagen+"')");

        }

        //MODIFICAR DATOS........................
        public bool modificarDatos(string clave, string partido, string nomRepresentante,
            string APRepresentante, string AMRepresentante, string nomVPresidente,
            string APVPresidente, string AMVPresidente, string imagen)
        {
            return BD.modificar("partidos", "ClavePartido='" + clave + "',NomPartido='" + partido +
                "',NomRepresentante='"+ nomRepresentante + "',APRepresentante='" + APRepresentante + 
                "',AMRepresentante='" + AMRepresentante + "',NomVicepresidente='" + nomVPresidente + 
                "',APVicepresidente='" + APVPresidente + "',AMVicepresidente='" + AMVPresidente +
                "',Imagen='"+ imagen+"'","ClavePartido='"+clave+"';");
        }
        //ELIMINAR DATOS...............
        public bool eliminarDatos(string tabla, string condicion)
        {
            return BD.eliminar("partidos", "ClavePartido='" + condicion + "'");
        }
    }
}
