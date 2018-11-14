using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Banana : Fruta
    {
        #region Atributos
        protected string _paisOrigen;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        public string PaisOrigen
        {
            get
            {
                return this._paisOrigen;
            }
            set
            {
                this._paisOrigen = value;
            }
        }
        #endregion

        #region Constructor
        public Banana(string color, double peso, string paisDeOrigen) : base(color,peso)
        {
            this.PaisOrigen = paisDeOrigen;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return String.Format("Nombre: {0}{1}\nTiene carozo: {2}\nPais de origen: {3}", this.Nombre,base.FrutaToString(), this.TieneCarozo, this.PaisOrigen);
        }
        #endregion
    }
}
