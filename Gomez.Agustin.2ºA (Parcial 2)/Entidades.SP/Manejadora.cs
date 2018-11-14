using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.SP
{
    public class Manejadora
    {
        public bool ManejadorEvento(string ruta, double precio)
        {
            bool retorno;
            using (StreamWriter writer = new StreamWriter(ruta, false))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}",DateTime.Now);
                sb.AppendLine();
                sb.AppendFormat("Precio del cajon: {0}", precio);
                writer.Write(sb.ToString());
                retorno = true;
            }
            return retorno;
        }
    }
}
