using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public abstract class Fruta
    {
        #region Atributos
        protected string _color;
        protected double _peso;
        #endregion

        #region Propiedades
        abstract public bool TieneCarozo { get; }
        public string Color
        {
            get
            {
                return this._color;
            }

            set
            {
                this._color = value;
            }
        }

        public double Peso
        {
            get
            {
                return this._peso;
            }
            set
            {
                this._peso = value;
            }
        }
        #endregion

        #region Constructor
        public Fruta(string color, double peso)
        {
            this.Color = color;
            this.Peso = peso;
        }
        #endregion

        #region Metodos
        protected virtual string FrutaToString()
        {
            return String.Format("\nColor: {0}\n Peso: {1}", this._color, this._peso);
        }
        #endregion
    }
}
