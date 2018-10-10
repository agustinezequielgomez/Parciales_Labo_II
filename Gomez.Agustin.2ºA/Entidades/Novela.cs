using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Libro
    {
        #region Atributos
        public EGenero genero;
        #endregion

        #region Constructor
        public Novela(string titulo, float precio, Autor autor, EGenero genero) : base (titulo,autor,precio)
        {
            this.genero = genero;
        }
        #endregion

        #region Metodos
        public string Mostrar()
        {
            string libro = (string)this;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(libro);
            sb.AppendFormat("Genero: {0}\n", this.genero);
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Novela a,Novela b)
        {
            return (a == b && a.genero == b.genero);
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }

        public static implicit operator double(Novela n)
        {
            return n._precio;
        }
        #endregion
    }
}
