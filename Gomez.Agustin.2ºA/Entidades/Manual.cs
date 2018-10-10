using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manual : Libro
    {
        #region Atributos
        public ETipo tipo;
        #endregion

        #region Constructor
        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) :base(precio,titulo,nombre,apellido)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        public string Mostrar()
        {
            string libro = (string)this;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(libro);
            sb.AppendFormat("Tipo: {0}\n", this.tipo);
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Manual a, Manual b)
        {
            return (((Libro)a) == ((Libro)b) && a.tipo == b.tipo);
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

        public static implicit operator double(Manual m)
        {
            return m._precio;
        }
        #endregion
    }
}
