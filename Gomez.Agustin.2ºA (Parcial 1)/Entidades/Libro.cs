using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        #region Atributos
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;
        #endregion

        #region Propiedades
        public int CantidadDePaginas
        {
            get
            {
                if(this._cantidadDePaginas==0)
                {
                    this._cantidadDePaginas = Libro._generadorDePaginas.Next(10,580);
                }
                return this._cantidadDePaginas;
            }
        }
        #endregion

        #region Constructores
        static Libro()
        {
            Libro._generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, string nombre, string apellido) : this(titulo,new Autor(nombre,apellido),precio)
        {
        }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._autor = autor;
            this._titulo = titulo;
            this._precio = precio;
        }
        #endregion

        #region Metodos
        private static string Mostrar(Libro l)
        {
            string autor;
            autor = l._autor;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Titulo: {0}\nCantidad de Paginas: {1}\nAutor: {2}Precio: {3}", l._titulo, l.CantidadDePaginas,autor,l._precio);
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Libro a, Libro b)
        {
            return (a._titulo == b._titulo && a._autor == b._autor);
        }

        public static bool operator !=(Libro a, Libro b)     
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            return Libro.Mostrar(l);
        }
        #endregion
    }
}
