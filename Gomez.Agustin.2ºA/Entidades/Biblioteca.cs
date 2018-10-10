using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        #region Atributos
        private int _capacidad;
        private List<Libro> _libros;
        #endregion

        #region Propiedades
        public double  PrecioManuales
        {
            get
            {
                return this.ObtenerPrecio(ELibro.Manual);
            }
        }

        public double PrecioNovelas
        {
            get
            {
                return this.ObtenerPrecio(ELibro.Novela);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(ELibro.Ambos);
            }
        }
        #endregion

        #region Constructores
        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        #region Metodos
        public static string Mostrar(Biblioteca e)
        {
            string libro;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nCapacidad de la biblioteca: {0}", e._capacidad);
            sb.AppendFormat("\nTotal por Manuales: {0:#.00}\nTotal por Novelas: {1:#.00}\nTotal: {2:#.00}", e.PrecioManuales, e.PrecioNovelas, e.PrecioTotal);
            sb.AppendLine("\n************************\nListado de Libros\n************************");
            foreach (Libro item in e._libros)
            {
                if(item is Novela)
                {
                    sb.AppendLine(((Novela)item).Mostrar());
                }
                else if(item is Manual)
                {
                    sb.AppendLine(((Manual)item).Mostrar());
                }
            }
            return sb.ToString();
        }

        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double retorno = 0;
            foreach (Libro item in this._libros)
            {
                switch (tipoLibro)
                {
                    case ELibro.Manual:
                        if(item is Manual)
                        {
                            retorno += ((Manual)item);
                        }
                        break;
                    case ELibro.Novela:
                        if (item is Novela)
                        {
                            retorno += ((Novela)item);
                        }
                        break;
                    case ELibro.Ambos:
                        if (item is Novela)
                        {
                            retorno += ((Novela)item);
                        }
                        else if(item is Manual)
                        {
                            retorno += ((Manual)item);
                        }
                        break;
                    default:
                        break;
                }
            }
            return retorno;
            
        }
        #endregion

        #region Operadores
        public static implicit operator Biblioteca(int capacidad)
        {
            Biblioteca b = new Biblioteca(capacidad);
            return b;
        }

        public static bool operator ==(Biblioteca e, Libro l)
        {
            bool retorno = false;
            foreach (Libro item in e._libros)
            {
                if(item is Novela && l is Novela)
                {
                    if(((Novela)item) == ((Novela)l))
                    {
                        retorno = true;
                    }
                }
                else if(item is Manual && l is Manual)
                {
                    if (((Manual)item) == ((Manual)l))
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Biblioteca e, Libro l)
        {
            return !(e == l);
        }

        public static Biblioteca operator +(Biblioteca e, Libro l)
        {
            if(e != l)
            {
                if(e._capacidad - e._libros.Count >= 1)
                {
                    e._libros.Add(l);
                }
                else
                {
                    Console.WriteLine("\nNo hay mas lugar en la biblioteca!!!\n");
                }
            }
            else
            {
                Console.WriteLine("\nEl libro ya está en la biblioteca!!!\n");
            }
            return e;
        }
        #endregion
    }
}
