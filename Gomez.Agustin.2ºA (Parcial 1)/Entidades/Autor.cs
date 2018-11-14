using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        #region Atributos
        private string nombre;
        private string apellido;
        #endregion

        #region Constructores
        public Autor(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion

        #region Operadores
        public static implicit operator string(Autor a)
        {
            return string.Format("{0} - {1}\n", a.nombre, a.apellido);
        }

        public static bool operator ==(Autor a, Autor b)
        {
            return (a.nombre == b.nombre && a.apellido == b.apellido);
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }
        #endregion
    }
}
