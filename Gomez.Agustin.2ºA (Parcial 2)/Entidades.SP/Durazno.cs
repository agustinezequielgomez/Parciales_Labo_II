using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Durazno : Fruta
    {
        #region Atributos 
        protected int _cantPelusa;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return "Durazno";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public int CantPelusa
        {
            get
            {
                return this._cantPelusa;
            }
            set
            {
                this._cantPelusa = value;
            }
        }
        #endregion

        #region Constructor
        public Durazno(string color, double peso, int cantPelusa) : base(color,peso)
        {
            this._cantPelusa = cantPelusa;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return String.Format("Nombre:{0}{1}\nTiene carozo: {2}\nCantidad de pelusa: {3}", this.Nombre, base.FrutaToString(), this.TieneCarozo, this.CantPelusa);
        }
        #endregion
    }
}
